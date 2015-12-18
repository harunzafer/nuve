using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using Nuve.Condition;
using Nuve.Morphologic;
using Nuve.Orthographic;

namespace Nuve.Reader
{
    internal class MorphotacticsReader
    {
        private readonly Alphabet _alphabet;
        private readonly IGraph<string> _graph = new DictionaryGraph();
        private readonly IEnumerable<SuffixGroupElement> _suffixGroupElements;
        private readonly IEnumerable<TransitionSetElement> _transitionSetElements;
        private readonly XDocument _xDocument;

        private MorphotacticsReader(Stream xml, Alphabet alphabet)
        {
            _alphabet = alphabet;

            try
            {
                _xDocument = XDocument.Load(xml);
            }
            catch (XmlException ex)
            {
                throw new XmlException("Invalid morphotactics XML: " + ex.Message);
            }

            _suffixGroupElements = GetSuffixGroupElements();
            _transitionSetElements = GetTransitionSetElements();

            BuildGraph();
        }

        public static Morphotactics Read(Stream xml, Alphabet alphabet)
        {
            var reader = new MorphotacticsReader(xml, alphabet);
            return new Morphotactics(reader._graph);
        }

        private IEnumerable<TransitionSetElement> GetTransitionSetElements()
        {
            return _xDocument.Descendants("source").
                Select(ts => new TransitionSetElement
                {
                    Id = ts.Attribute("id").Value,
                    Copies = ts.Descendants("copy"),
                    TargetGroups = ts.Descendants("targetGroup"),
                    Targets = ts.Descendants("target")
                }
                );
        }

        private IEnumerable<SuffixGroupElement> GetSuffixGroupElements()
        {
            return _xDocument.Descendants("suffixGroup").
                Select(sg => new SuffixGroupElement
                {
                    Id = sg.Attribute("name").Value,
                    Suffixes = sg.Elements("suffix")
                }
                );
        }

        private void BuildGraph()
        {
            foreach (var transitionSetElement in _transitionSetElements)
            {
                AddTransitions(transitionSetElement);
            }
        }

        private void AddTransitions(TransitionSetElement transitionSetElement)
        {
            var sourceId = transitionSetElement.Id;
            //_graph.AddVertex(sourceId);

            var copyTransitions = GetCopyTransitions(sourceId, transitionSetElement.Copies);
            _graph.AddEdges(copyTransitions);

            var groupTransitions = GetGroupTransitions(sourceId,
                transitionSetElement.TargetGroups);
            _graph.AddEdges(groupTransitions);

            var singleTransitions = GetSingleTransitions(sourceId,
                transitionSetElement.Targets);
            _graph.AddEdges(singleTransitions);
        }

        private IEnumerable<Transition<string>> GetSingleTransitions(string sourceId,
            IEnumerable<XElement> singleElements)
        {
            var transitions = new List<Transition<string>>();
            foreach (var singleElement in singleElements)
            {
                var targetId = singleElement.Attribute("id").Value;
                var conditions = GetConditionContainer(singleElement);
                //_graph.AddVertex(targetId);
                transitions.Add(new Transition<string>(sourceId, targetId, conditions));
            }

            return transitions;
        }

        private ConditionContainer GetConditionContainer(XElement singleElement)
        {
            XElement conditionsElement;
            //try
            //{
            //    conditionsElement = singleElement.Descendants("conditions").First();
            //}
            //catch(Exception)
            //{
            //    return ConditionContainer.EmptyContainer();
            //}

            if (singleElement.Descendants("conditions").Any())
            {
                conditionsElement = singleElement.Descendants("conditions").First();
            }
            else
            {
                return ConditionContainer.EmptyContainer();
            }


            var flag = conditionsElement.Attribute("flag").Value;
            return new ConditionContainer(GetConditions(conditionsElement.Descendants("condition")), flag);
        }

        private IList<ConditionBase> GetConditions(IEnumerable<XElement> conditionElements)
        {
            IList<ConditionBase> conditions = new List<ConditionBase>();
            foreach (var conditionElement in conditionElements)
            {
                conditions.Add(GetCondition(conditionElement));
            }
            return conditions;
        }

        private ConditionBase GetCondition(XElement conditionElement)
        {
            var name = conditionElement.Attribute("operator").Value;
            var morphemeLocation = conditionElement.Attribute("morpheme").Value;
            var attribute = conditionElement.Attribute("operand");
            var operand = "";
            if (attribute != null)
            {
                operand = attribute.Value;
            }
            return ConditionFactory.Create(name, morphemeLocation, operand, _alphabet);
        }

        private IEnumerable<Transition<string>> GetGroupTransitions(string sourceId,
            IEnumerable<XElement> groupElements)
        {
            var transitions = new List<Transition<string>>();

            foreach (var groupElement in groupElements)
            {
                transitions.AddRange(GetGroupTransitions(sourceId, groupElement));
            }

            return transitions;
        }

        private IEnumerable<Transition<string>> GetCopyTransitions(string sourceId,
            IEnumerable<XElement> copyElements)
        {
            var transitions = new List<Transition<string>>();

            foreach (var copyElement in copyElements)
            {
                transitions.AddRange(GetCopyTransitions(sourceId, copyElement));
            }

            return transitions;
        }

        private IEnumerable<Transition<string>> GetCopyTransitions(string sourceId, XElement copyElement)
        {
            var transitions = new List<Transition<string>>();
            var copyId = copyElement.Attribute("id").Value;

            IEnumerable<Transition<string>> list;
            _graph.TryGetOutEdges(copyId, out list);

            foreach (var transition in list)
            {
                transitions.Add(new Transition<string>(sourceId, transition.Target /*, transition.Conditions*/));
            }

            var removeElements = copyElement.Descendants("removeTarget");

            foreach (var removeElement in removeElements)
            {
                var removeId = removeElement.Attribute("id").Value;
                transitions.RemoveAll(x => x.Target == removeId);
            }

            var replaceElements = copyElement.Descendants("replaceTarget");
            foreach (var replaceElement in replaceElements)
            {
                var oldId = replaceElement.Attribute("old").Value;
                var newId = replaceElement.Attribute("new").Value;
                transitions.RemoveAll(x => x.Target == oldId);
                transitions.Add(new Transition<string>(sourceId, newId));
            }

            return transitions;
        }


        private IEnumerable<Transition<string>> GetGroupTransitions(string sourceId, XElement groupElement)
        {
            var transitions = new List<Transition<string>>();
            var groupId = groupElement.Attribute("id").Value;
            var group = _suffixGroupElements.First(x => x.Id == groupId);
            foreach (var suffix in group.Suffixes)
            {
                //_graph.AddVertex(suffix.Value);
                transitions.Add(new Transition<string>(sourceId, suffix.Value));
            }

            var removeElements = groupElement.Descendants("removeTarget");

            foreach (var removeElement in removeElements)
            {
                var removeId = removeElement.Attribute("id").Value;
                transitions.RemoveAll(x => x.Target == removeId);
            }

            var replaceElements = groupElement.Descendants("replaceTarget");
            foreach (var replaceElement in replaceElements)
            {
                var oldId = replaceElement.Attribute("old").Value;
                var newId = replaceElement.Attribute("new").Value;
                transitions.RemoveAll(x => x.Target == oldId);
                transitions.Add(new Transition<string>(sourceId, newId));
            }

            //var editElements = copyElement.Descendants("edit");

            return transitions;
        }

        private class SuffixGroupElement
        {
            public string Id;
            public IEnumerable<XElement> Suffixes;
        }

        private class TransitionSetElement
        {
            public IEnumerable<XElement> Copies;
            public string Id;
            public IEnumerable<XElement> TargetGroups;
            public IEnumerable<XElement> Targets;
        }
    }
}
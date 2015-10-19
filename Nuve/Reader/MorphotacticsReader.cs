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
    internal static class MorphotacticsReader
    {
        private static IEnumerable<SuffixGroupElement> _suffixGroupElements;
        private static IEnumerable<TransitionSetElement> _transitionSetElements;
        //private static readonly AdjacencyGraph<string, Transition<string>> Graph = new AdjacencyGraph<string, Transition<string>>(false);
        //private static readonly IGraph<string> Graph = new QuickGraph<string>();
        private static readonly IGraph<string> Graph = new DictionaryGraph();
        private static Alphabet _alphabet;

        public static Morphotactics Read(Stream xml, Alphabet alphabet)
        {
            _alphabet = alphabet;
            XDocument doc;
            try
            {
                doc = XDocument.Load(xml);
            }

            catch (XmlException ex)
            {
                throw new XmlException("Invalid morphotactics XML: " + ex.Message);
            }


            _suffixGroupElements = GetSuffixGroupElements(doc);
            _transitionSetElements = GetTransitionSetElements(doc);

            BuildGraph();

            return new Morphotactics(Graph);
        }

        private static IEnumerable<TransitionSetElement> GetTransitionSetElements(XDocument doc)
        {
            return doc.Descendants("source").
                Select(ts => new TransitionSetElement
                {
                    Id = ts.Attribute("id").Value,
                    Copies = ts.Descendants("copy"),
                    TargetGroups = ts.Descendants("targetGroup"),
                    Targets = ts.Descendants("target"),
                }
                );
        }

        private static IEnumerable<SuffixGroupElement> GetSuffixGroupElements(XDocument doc)
        {
            return doc.Descendants("suffixGroup").
                Select(sg => new SuffixGroupElement
                {
                    Id = sg.Attribute("name").Value,
                    Suffixes = sg.Elements("suffix"),
                }
                );
        }

        private static void BuildGraph()
        {
            foreach (TransitionSetElement transitionSetElement in _transitionSetElements)
            {
                AddTransitions(transitionSetElement);
            }
        }

        private static void AddTransitions(TransitionSetElement transitionSetElement)
        {
            string sourceId = transitionSetElement.Id;
            //Graph.AddVertex(sourceId);

            IEnumerable<Transition<string>> copyTransitions = GetCopyTransitions(sourceId, transitionSetElement.Copies);
            Graph.AddEdges(copyTransitions);

            IEnumerable<Transition<string>> groupTransitions = GetGroupTransitions(sourceId,
                transitionSetElement.TargetGroups);
            Graph.AddEdges(groupTransitions);

            IEnumerable<Transition<string>> singleTransitions = GetSingleTransitions(sourceId,
                transitionSetElement.Targets);
            Graph.AddEdges(singleTransitions);
        }

        private static IEnumerable<Transition<string>> GetSingleTransitions(string sourceId,
            IEnumerable<XElement> singleElements)
        {
            var transitions = new List<Transition<string>>();
            foreach (XElement singleElement in singleElements)
            {
                string targetId = singleElement.Attribute("id").Value;
                ConditionContainer conditions = GetConditionContainer(singleElement);
                //Graph.AddVertex(targetId);
                transitions.Add(new Transition<string>(sourceId, targetId, conditions));
            }

            return transitions;
        }

        private static ConditionContainer GetConditionContainer(XElement singleElement)
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


            string flag = conditionsElement.Attribute("flag").Value;
            return new ConditionContainer(GetConditions(conditionsElement.Descendants("condition")), flag);
        }

        private static IList<ConditionBase> GetConditions(IEnumerable<XElement> conditionElements)
        {
            IList<ConditionBase> conditions = new List<ConditionBase>();
            foreach (XElement conditionElement in conditionElements)
            {
                conditions.Add(GetCondition(conditionElement));
            }
            return conditions;
        }

        private static ConditionBase GetCondition(XElement conditionElement)
        {
            string name = conditionElement.Attribute("operator").Value;
            string morphemeLocation = conditionElement.Attribute("morpheme").Value;
            XAttribute attribute = conditionElement.Attribute("operand");
            string operand = "";
            if (attribute != null)
            {
                operand = attribute.Value;
            }
            return ConditionFactory.Create(name, morphemeLocation, operand, _alphabet);
        }

        private static IEnumerable<Transition<string>> GetGroupTransitions(string sourceId,
            IEnumerable<XElement> groupElements)
        {
            var transitions = new List<Transition<string>>();

            foreach (XElement groupElement in groupElements)
            {
                transitions.AddRange(GetGroupTransitions(sourceId, groupElement));
            }

            return transitions;
        }

        private static IEnumerable<Transition<string>> GetCopyTransitions(string sourceId,
            IEnumerable<XElement> copyElements)
        {
            var transitions = new List<Transition<string>>();

            foreach (XElement copyElement in copyElements)
            {
                transitions.AddRange(GetCopyTransitions(sourceId, copyElement));
            }

            return transitions;
        }

        private static IEnumerable<Transition<string>> GetCopyTransitions(string sourceId, XElement copyElement)
        {
            var transitions = new List<Transition<string>>();
            string copyId = copyElement.Attribute("id").Value;

            IEnumerable<Transition<string>> list;
            Graph.TryGetOutEdges(copyId, out list);

            foreach (var transition in list)
            {
                transitions.Add(new Transition<string>(sourceId, transition.Target /*, transition.Conditions*/));
            }

            IEnumerable<XElement> removeElements = copyElement.Descendants("removeTarget");

            foreach (XElement removeElement in removeElements)
            {
                string removeId = removeElement.Attribute("id").Value;
                transitions.RemoveAll(x => x.Target == removeId);
            }

            IEnumerable<XElement> replaceElements = copyElement.Descendants("replaceTarget");
            foreach (XElement replaceElement in replaceElements)
            {
                string oldId = replaceElement.Attribute("old").Value;
                string newId = replaceElement.Attribute("new").Value;
                transitions.RemoveAll(x => x.Target == oldId);
                transitions.Add(new Transition<string>(sourceId, newId));
            }

            return transitions;
        }


        private static IEnumerable<Transition<string>> GetGroupTransitions(string sourceId, XElement groupElement)
        {
            var transitions = new List<Transition<string>>();
            string groupId = groupElement.Attribute("id").Value;
            SuffixGroupElement group = _suffixGroupElements.First(x => x.Id == groupId);
            foreach (XElement suffix in group.Suffixes)
            {
                //Graph.AddVertex(suffix.Value);
                transitions.Add(new Transition<string>(sourceId, suffix.Value));
            }

            IEnumerable<XElement> removeElements = groupElement.Descendants("removeTarget");

            foreach (XElement removeElement in removeElements)
            {
                string removeId = removeElement.Attribute("id").Value;
                transitions.RemoveAll(x => x.Target == removeId);
            }

            IEnumerable<XElement> replaceElements = groupElement.Descendants("replaceTarget");
            foreach (XElement replaceElement in replaceElements)
            {
                string oldId = replaceElement.Attribute("old").Value;
                string newId = replaceElement.Attribute("new").Value;
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
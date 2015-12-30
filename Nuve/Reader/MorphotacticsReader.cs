using System.Collections.Generic;
using System.Diagnostics;
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
        private readonly IGraph _graph = new DictionaryGraph();
        private readonly IEnumerable<SuffixGroupElement> _suffixGroupElements;
        private readonly IEnumerable<TransitionSet> _transitionSets;
        private readonly XDocument _xDocument;

        private readonly TraceSource _trace = new TraceSource("MorphotacticsReader");

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
            _transitionSets = GetTransitionSetElements();

            BuildGraph();
        }

        public static Morphotactics Read(Stream xml, Alphabet alphabet)
        {
            var reader = new MorphotacticsReader(xml, alphabet);
            return new Morphotactics(reader._graph);
        }

        //Read Suffix Group XML elements
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

        //Read source->targets XML elements
        private IEnumerable<TransitionSet> GetTransitionSetElements()
        {
            return _xDocument.Descendants("source").
                Select(ts => new TransitionSet
                {
                    SourceId = ts.Attribute("id").Value,
                    IsTerminal = !ts.Attribute("terminal")?.Value.Equals("false") ?? true,
                    Copies = ts.Descendants("copy"),
                    TargetGroups = ts.Descendants("targetGroup"),
                    Targets = ts.Descendants("target")
                }
                );
        }

        private void BuildGraph()
        {
            //Add vertices to the graph first
            foreach (var transitionSet in _transitionSets)
            {
                AddNode(transitionSet);
            }
            
            //Then Add edges
            foreach (var transitionSetElement in _transitionSets)
            {
                AddTransitions(transitionSetElement);
            }
        }

        //Each TransitionSet has exactly one source morpheme which is added as a vertex to the graph
        private void AddNode(TransitionSet transitionSet)
        {
            _graph.AddVertex(new Vertex(transitionSet.SourceId, transitionSet.IsTerminal));
        }

        //
        private void AddTransitions(TransitionSet transitionSet)
        {
            //Get the Id of the source morpheme for this set of transitions
            var sourceId = transitionSet.SourceId;

            //First add 1-1 transitions
            var singleTransitions = GetSingleTransitions(sourceId,
               transitionSet.Targets);
            _graph.AddEdges(singleTransitions);


            var groupTransitions = GetGroupTransitions(sourceId,
                transitionSet.TargetGroups);
            _graph.AddEdges(groupTransitions);

            var copyTransitions = GetCopyTransitions(sourceId, transitionSet.Copies);
            _graph.AddEdges(copyTransitions);

            

           
        }

        private IEnumerable<Transition> GetSingleTransitions(string sourceId,
            IEnumerable<XElement> singleElements)
        {
            var transitions = new List<Transition>();
            foreach (var singleElement in singleElements)
            {
                var targetId = singleElement.Attribute("id").Value;
                var isEmpty = singleElement.Attribute("empty")?.Value.Equals("true") ?? false;
                var conditions = GetConditionContainer(singleElement);
                transitions.Add(new Transition(sourceId, targetId, conditions, isEmpty));
            }

            return transitions;
        }

        private ConditionContainer GetConditionContainer(XElement singleElement)
        {
            XElement conditionsElement;          

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
            var morphemePosition = conditionElement.Attribute("morpheme").Value;
            var attribute = conditionElement.Attribute("operand");
            var operand = "";
            if (attribute != null)
            {
                operand = attribute.Value;
            }
            return ConditionFactory.Create(name, morphemePosition, operand, _alphabet);
        }

        private IEnumerable<Transition> GetGroupTransitions(string sourceId,
            IEnumerable<XElement> groupElements)
        {
            var transitions = new List<Transition>();

            foreach (var groupElement in groupElements)
            {
                transitions.AddRange(GetGroupTransitions(sourceId, groupElement));
            }

            return transitions;
        }

        private IEnumerable<Transition> GetGroupTransitions(string sourceId, XElement groupElement)
        {
            var transitions = new List<Transition>();
            var groupId = groupElement.Attribute("id").Value;
            
            var group = _suffixGroupElements.FirstOrDefault(x => x.Id == groupId);

            if (group == null)
            {
                _trace.TraceEvent(TraceEventType.Error, 1, $"Group not found: {groupId}");
                return transitions;
            }

            foreach (var suffix in group.Suffixes)
            {
                transitions.Add(new Transition(sourceId, suffix.Value, ConditionContainer.EmptyContainer()));
            }

            var removeElements = groupElement.Descendants("removeTarget");

            foreach (var removeElement in removeElements)
            {
                var removeId = removeElement.Attribute("id").Value;
                transitions.RemoveAll(x => x.Target == removeId);
            }

            //var replaceElements = groupElement.Descendants("replaceTarget");
            //foreach (var replaceElement in replaceElements)
            //{
            //    var oldId = replaceElement.Attribute("old").Value;
            //    var newId = replaceElement.Attribute("new").Value;
            //    transitions.RemoveAll(x => x.Target == oldId);
            //    transitions.Add(new Transition(sourceId, newId, ConditionContainer.EmptyContainer()));
            //}

            //var editElements = copyElement.Descendants("edit");

            return transitions;
        }

        private IEnumerable<Transition> GetCopyTransitions(string sourceId,
            IEnumerable<XElement> copyElements)
        {
            var transitions = new List<Transition>();

            foreach (var copyElement in copyElements)
            {
                transitions.AddRange(GetCopyTransitions(sourceId, copyElement));
            }

            return transitions;
        }

        private IEnumerable<Transition> GetCopyTransitions(string sourceId, XElement copyElement)
        {
            var transitions = new List<Transition>();
            var copyId = copyElement.Attribute("id").Value;
            //var empty = copyElement.Attribute("empty")?.Value.Equals("true") ?? false;

            IEnumerable<Transition> list = _graph.GetTransitions(copyId);

            //Create new copies, because sourceId is different
            foreach (var transition in list)
            {
                transitions.Add(new Transition(sourceId, transition.Target, ConditionContainer.EmptyContainer(), transition.Empty));
            }

            var removeElements = copyElement.Descendants("removeTarget");

            foreach (var removeElement in removeElements)
            {
                var removeId = removeElement.Attribute("id").Value;
                transitions.RemoveAll(x => x.Target == removeId);
            }

            //var replaceElements = copyElement.Descendants("replaceTarget");
            //foreach (var replaceElement in replaceElements)
            //{
            //    var oldId = replaceElement.Attribute("old").Value;
            //    var newId = replaceElement.Attribute("new").Value;
            //    transitions.RemoveAll(x => x.Target == oldId);
            //    transitions.Add(new Transition(sourceId, newId, ConditionContainer.EmptyContainer()));
            //}

            return transitions;
        }


    

        private class SuffixGroupElement
        {
            public string Id;
            public IEnumerable<XElement> Suffixes;
        }

        private class TransitionSet
        {
            public string SourceId;
            public bool IsTerminal;
            public IEnumerable<XElement> Copies;
            public IEnumerable<XElement> TargetGroups;
            public IEnumerable<XElement> Targets;
        }
    }
}
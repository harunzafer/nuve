using System.Collections.Generic;
using System.Diagnostics;
using Nuve.Morphologic.Structure;

namespace Nuve.Morphologic
{
    internal class DictionaryGraph : IGraph
    {
        private Dictionary<string, Vertex> Vertices { get; } = new Dictionary<string, Vertex>();

        private readonly TraceSource _trace = new TraceSource("DictionaryGraph");

        public void AddVertex(Vertex vertex)
        {
            if (Vertices.ContainsKey(vertex.Id))
            {
                _trace.TraceEvent(TraceEventType.Error, 1, $"Vertex is already in the graph: {vertex.Id}");
                return;
            }
            Vertices.Add(vertex.Id, vertex);
        }

        public void AddVertices(IEnumerable<Vertex> vertices)
        {
            foreach (Vertex vertex in vertices)
            {
                AddVertex(vertex);
            }
        }

        public void AddEdges(IEnumerable<Transition> transitions)
        {
            foreach (var transition in transitions)
            {
                AddEdge(transition);
            }
        }

        public void AddEdge(Transition transition)
        {
            if (!Vertices.ContainsKey(transition.Source))
            {
                _trace.TraceEvent(TraceEventType.Error, 1, $"Transition source not found: {transition.Source}");
                return;
            }

            if (!Vertices.ContainsKey(transition.Target))
            {
                _trace.TraceEvent(TraceEventType.Error, 1, $"Transition target not found: {transition.Target}");
                return;
            }

            Vertices[transition.Source].AddTransition(transition);
        }


        public IEnumerable<Transition> GetTransitions(string source)
        {
            if (Vertices.ContainsKey(source))
            {
                return Vertices[source].Transitions;
            }

            return new List<Transition>();
        }


        public IEnumerable<Transition> GetEmptyTransitions(string source)
        {
            if (Vertices.ContainsKey(source))
            {
                return Vertices[source].EmptyStringTransitions;
            }

            return new List<Transition>();
        }

        public bool ContainsTransition(string source, string target)
        {
            if (Vertices.ContainsKey(source))
            {
                return Vertices[source].ContainsTransition(target);
            }

            return false;
        }

        public bool TryGetTransition(string source, string target, out Transition transition)
        {
            transition = null;

            if (Vertices.ContainsKey(source) )
            {
                return Vertices[source].TryGetTransition(target, out transition);
            }

            return false;
        }

       

        public bool IsTerminal(string source)
        {
            if (Vertices.ContainsKey(source))
            {
                return Vertices[source].IsTerminal;
            }
            return false;
        }

    }
}
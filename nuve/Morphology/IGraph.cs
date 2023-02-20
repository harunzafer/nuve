using System.Collections.Generic;
using Nuve.Morphologic.Structure;

namespace Nuve.Morphologic
{
    internal interface IGraph
    {

        void AddVertex(Vertex vertex);

        void AddVertices(IEnumerable<Vertex> vertices);

        void AddEdge(Transition transition);

        void AddEdges(IEnumerable<Transition> transitions);

        bool IsTerminal(string morpheme);

        IEnumerable<Transition> GetEmptyTransitions(string source);

        bool ContainsTransition(string source, string target);

        bool TryGetTransition(string source, string target, out Transition transition);

        IEnumerable<Transition> GetTransitions(string source);

        
    }
}
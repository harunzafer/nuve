using System;
using Nuve.Morphologic.Structure;

namespace Nuve.Morphologic
{
    internal class Morphotactics
    {
        //private readonly ArrayAdjacencyGraph<string, CustomEdge<string>> _graph;
        private readonly IGraph<string> _graph;

        public Morphotactics(IGraph<string> graph)
        {
            _graph = graph;
        }

        public bool HasTransition(string previousMorphemeId, string nextMorphemeId)
        {
            return _graph.ContainsEdge(previousMorphemeId, nextMorphemeId);
        }
        
        public bool IsValid(Word word)
        {
            for (int i = 0; i < word.AllomorphCount - 1; i++)
            {
                Transition<string> transition;
                bool edgeExists = _graph.TryGetEdge(word[i].Morpheme.GraphId, word[i + 1].Morpheme.GraphId, out transition);

                if (!edgeExists)
                {
                    return false;
                }

                if (!transition.Conditions.IsTrue(word[i]))
                {
                    return false;
                }
            }
            return true;
        }


        public bool IsConditionTrue(Allomorph previous, Allomorph next)
        {
            throw new NotImplementedException();
        }
    }
}
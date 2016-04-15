using System;
using System.Collections.Generic;
using System.Linq;
using Nuve.Morphologic.Structure;

namespace Nuve.Morphologic
{
    internal class Morphotactics
    {
        private readonly IGraph _graph;

        internal Morphotactics(IGraph graph)
        {
            _graph = graph;
        }

        internal bool IsTerminal(Morpheme morpheme)
        {
            return _graph.IsTerminal(morpheme.SequenceId);
        }

        internal IEnumerable<string> GetMorphemesWithEmptyTransitions(Morpheme prev)
        {
            return _graph.GetEmptyTransitions(prev.SequenceId).Select(t => t.Target);
        }


        internal bool HasTransition(Morpheme prev, Morpheme next)
        {
            return _graph.ContainsTransition(prev.SequenceId, next.SequenceId);
        }
        
        internal bool IsValid(Word word)
        {
            for (int i = 0; i < word.AllomorphCount - 1; i++)
            {
                Transition transition;
                bool edgeExists = _graph.TryGetTransition(word[i].Morpheme.SequenceId, word[i + 1].Morpheme.SequenceId, out transition);

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
    }
}
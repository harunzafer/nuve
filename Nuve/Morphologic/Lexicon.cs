using System.Collections.Generic;
using Nuve.Morphologic.Structure;

namespace Nuve.Morphologic
{
    internal class Lexicon
    {
        private readonly Dictionary<string, Suffix> _suffixesById;

        public Lexicon(MorphemeLexicon<Root> roots, MorphemeLexicon<Suffix> suffixes,
            Dictionary<string, Suffix> suffixesById)
        {
            Roots = roots;
            Suffixes = suffixes;
            _suffixesById = suffixesById;
        }

        public MorphemeLexicon<Root> Roots { get; private set; }
        public MorphemeLexicon<Suffix> Suffixes { get; private set; }

        public Suffix GetSuffix(string id)
        {
            return _suffixesById[id];
        }
    }
}
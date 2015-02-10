using System.Collections.Generic;
using Nuve.Morphologic.Structure;

namespace Nuve.Dictionary
{
    internal class Lexicon
    {
        public Lexicon(MorphemeLexicon<Root> roots, MorphemeLexicon<Suffix> suffixes, Dictionary<string, Suffix> suffixesById)
        {
            Roots = roots;
            Suffixes = suffixes;
            this.suffixesById = suffixesById;
        }

        public MorphemeLexicon<Root> Roots { get; private set; }
        public MorphemeLexicon<Suffix> Suffixes { get; private set; }
        private readonly Dictionary<string, Suffix> suffixesById;

        public Suffix GetSuffix(string id)
        {
            return suffixesById[id];
        }


    }
}
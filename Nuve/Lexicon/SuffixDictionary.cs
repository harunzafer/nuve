using System.Collections.Generic;
using Nuve.Morphologic.Structure;

namespace Nuve.Lexicon
{
    class SuffixDictionary
    {
        private readonly IDictionary<string, Suffix> _suffixes;
        private readonly SuffixTrie _suffixTrie;

        public SuffixDictionary(IDictionary<string, Suffix> suffixes, SuffixTrie suffixTrie)
        {
            _suffixes = suffixes;
            _suffixTrie = suffixTrie;
        }

        /// <summary>
        /// Yüzeyin (surface) Eklerden en az bir tanesine ait olabilip olamayacağına bakar.
        /// </summary>
        /// <example>
        /// ContainsSuffix("ler") ve ContainsSuffix("miş") true döndürür<para/>
        /// ContainsSuffix("lermiş") ise false döndürür<para/>
        /// </example>
        public bool Contains(string surface)
        {
            return _suffixTrie.ExactMatchingSuffixExists(surface);
        }

        /// <summary>
        /// Belirtilen prefix ile başlayan bir ek olup olmadığına bakar.
        /// </summary>
        /// <example>
        /// ContainsSuffixStartsWith("le") ve ContainsSuffixStartsWith("ler") true döndürür.<para/>
        /// ContainsSuffixStartsWith("leri") ise false döndürür.
        /// </example>
        public bool ContainsSuffixStartsWith(string prefix)
        {
            return _suffixTrie.PrefixExists(prefix);
        }

        public IList<Suffix> GetSuffixes(string surface)
        {
            return _suffixTrie.GetSuffixesExactMatch(surface);
        }

        public IList<Suffix> GetSuffixesStartWith(string prefix)
        {
            return _suffixTrie.GetSuffixesStartWith(prefix);
        }

        public Suffix GetSuffix(string id)
        {
            return _suffixes[id];
        }

        //public IList<Suffix> GetSuffixesWithEmptySurface()
        //{
        //   _suffixes.
        //}

    }
}

using System.Collections.Generic;
using Nuve.Morphologic.Structure;

namespace Nuve.Client.Experimental
{
    internal class Cache
    {
        private static readonly Dictionary<string, IList<Word>> cache = new Dictionary<string, IList<Word>>();

        public static bool IsEmpty
        {
            get { return cache.Count == 0; }
        }

        public static bool TryAnalyze(string word, out IList<Word> solutions)
        {
            return cache.TryGetValue(word, out solutions);
        }

        public static void Add(string word, IList<Word> solutions)
        {
            if (!cache.ContainsKey(word))
            {
                cache.Add(word, solutions);
            }
        }

        public static int GetSize()
        {
            return cache.Count;
        }
    }
}
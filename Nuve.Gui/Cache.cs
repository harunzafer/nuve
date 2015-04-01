using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nuve.Morphologic.Structure;

namespace Nuve.Gui
{
    class Cache
    {
        public static bool TryAnalyze(string word, out IList<Word> solutions)
        {
            return cache.TryGetValue(word, out solutions);
        }

        private static readonly Dictionary<string, IList<Word>> cache = new Dictionary<string, IList<Word>>();

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

        public static bool IsEmpty
        {
            get { return cache.Count == 0; }
        }
    }
}

using System.Collections.Generic;
using System.Text;
using Nuve.Morphologic.Structure;

namespace Nuve.Lexicon
{
    class RootDictionary
    {
        private readonly IDictionary<string, List<Root>> roots;

        public RootDictionary()
        {
            roots = new Dictionary<string, List<Root>>();
        }

        public void Add(string surface, Root root) {
            if (roots.ContainsKey(surface))
            {
                roots[surface].Add(root);
                return;
            }
            
            var entry = new List<Root> {root};
            roots.Add(surface, entry);
        }

        /// <summary>
        /// Belirtilen anahtara (key:string) karşılık gelen kökleri döndürür.
        /// </summary>
        /// <example>"aç" değeri için biri sıfat ve fiil olan "aç" köklerini döndürür</example>
        /// <param name="lexicalForm">The lexical form.</param>
        /// <param name="rootSurface"> </param>
        /// <returns></returns>
        public List<Root> Get(string rootSurface)
        {
            return roots[rootSurface];
        }

        public bool Contains(string surface){
            return roots.ContainsKey(surface);
        }

        public void Save(string fileName) {
            var sb = new StringBuilder();
            foreach (var pair in roots)
            {
                sb.Append(pair.Key).Append("\t");
                foreach(var root in pair.Value){
                    sb.Append(root.ToString()).Append(",");
                }
                sb.Append("\n");
                
            }
            System.IO.File.WriteAllText(fileName, sb.ToString());
        }

    }
}

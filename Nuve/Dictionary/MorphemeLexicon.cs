using System.Collections.Generic;
using System.Text;
using Nuve.Morphologic.Structure;

namespace Nuve.Dictionary
{
    /// <summary>
    /// Contains surface forms as keys and a list for each key which contains possible Morphemes
    /// </summary>
    /// <typeparam name="T">Suffix or Root type</typeparam>
    class MorphemeLexicon<T> where T : Morpheme
    {
        private readonly IDictionary<string, List<T>> lexicon;

        public MorphemeLexicon()
        {
            lexicon = new Dictionary<string, List<T>>();
        }

        /// <summary>
        /// Adds a surface morpheme pair to the dictionary
        /// </summary>
        /// <param name="surface">surface form of the morpheme</param>
        /// <param name="morpheme">A Morpheme object having the surface form</param>
        public void Add(string surface, T morpheme) {
            if (lexicon.ContainsKey(surface))
            {
                lexicon[surface].Add(morpheme);
                return;
            }
            
            var entry = new List<T> {morpheme};
            lexicon.Add(surface, entry);
        }
        /// <summary>
        /// Belirtilen anahtara karşılık gelen kökleri out parametresine atar
        /// </summary>
        /// <param name="surface">kök yüzeyi</param>
        /// <param name="morphemes">kök yüzeyine karşılık gelen kökler</param>
        /// <returns>True if there is any morpheme for the given surface</returns>
        public bool TryGet(string surface, out List<T> morphemes)
        {
            if (lexicon.TryGetValue(surface, out morphemes))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Belirtilen anahtara (key:string) karşılık gelen kökleri döndürür.
        /// </summary>
        /// <example>"aç" değeri için biri sıfat ve fiil olan "aç" köklerini döndürür</example>
        /// <param name="lexicalForm">The lexical form.</param>
        /// <param name="surface"> </param>
        /// <returns></returns>
        public List<T> Get(string surface)
        {
            return lexicon[surface];
        }      
        
        /// <summary>
        /// Sözlükte belirtilen yüzeye sahip bir morfem var mı?
        /// </summary>
        /// <param name="surface"></param>
        /// <returns></returns>
        public bool Contains(string surface){
            return lexicon.ContainsKey(surface);
        }

        public void Save(string fileName) {
            var sb = new StringBuilder();
            foreach (var pair in lexicon)
            {
                sb.Append(pair.Key).Append("\t");
                foreach(var morpheme in pair.Value){
                    sb.Append(morpheme.ToString()).Append(",");
                }
                sb.Append("\n");
                
            }
            System.IO.File.WriteAllText(fileName, sb.ToString());
        }

    }
}

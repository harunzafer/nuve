using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Nuve.Morphologic.Structure;

namespace Nuve.Morphologic
{
    /// <summary>
    ///     Contains surface forms as keys and a list for each key which contains possible Morphemes
    /// </summary>
    /// <typeparam name="T">Suffix or Root type</typeparam>
    internal class MorphemeSurfaceDictionary<T> where T : Morpheme
    {
        private readonly IDictionary<string, List<T>> _dictionary;

        public MorphemeSurfaceDictionary()
        {
            _dictionary = new Dictionary<string, List<T>>();
        }

        private MorphemeSurfaceDictionary(IDictionary<string, List<T>> dictionary)
        {
            _dictionary = dictionary;
        }

        /// <summary>
        ///     Adds a surface morpheme pair to the dictionary
        /// </summary>
        /// <param name="surface">surface form of the morpheme</param>
        /// <param name="morpheme">A Morpheme object having the surface form</param>
        public void Add(string surface, T morpheme)
        {
            if (_dictionary.ContainsKey(surface))
            {
                _dictionary[surface].Add(morpheme);
                return;
            }

            var entry = new List<T> {morpheme};
            _dictionary.Add(surface, entry);
        }

        /// <summary>
        ///     Belirtilen anahtara karşılık gelen kökleri out parametresine atar
        /// </summary>
        /// <param name="surface">kök yüzeyi</param>
        /// <param name="morphemes">kök yüzeyine karşılık gelen kökler</param>
        /// <returns>True if there is any morpheme for the given surface</returns>
        internal IEnumerable<T> Get(string surface)
        {
            List<T> morphemes;
            if (_dictionary.TryGetValue(surface, out morphemes))
            {
                return morphemes;
            }

            return Enumerable.Empty<T>();
        }

        /// <summary>
        ///     Sözlükte belirtilen yüzeye sahip bir morfem var mı?
        /// </summary>
        /// <param name="surface"></param>
        /// <returns></returns>
        public bool Contains(string surface)
        {
            return _dictionary.ContainsKey(surface);
        }

        public void Save(string fileName)
        {
            var sb = new StringBuilder();
            foreach (var pair in _dictionary)
            {
                sb.Append(pair.Key).Append("\t");
                foreach (T morpheme in pair.Value)
                {
                    sb.Append(morpheme).Append(",");
                }
                sb.Append("\n");
            }
            File.WriteAllText(fileName, sb.ToString());
        }

        internal static MorphemeSurfaceDictionary<T> CopyOf(MorphemeSurfaceDictionary<T> dictionary)
        {
            var copy = new Dictionary<string, List<T>>(dictionary._dictionary);
            return new MorphemeSurfaceDictionary<T>(copy);
        }
    }
}
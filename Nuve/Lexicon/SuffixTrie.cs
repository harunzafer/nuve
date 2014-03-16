using System.Collections.Generic;
using System.Linq;
using Nuve.Morphologic.Structure;

namespace Nuve.Lexicon
{
    /// <summary>
    /// Suffix'lere özel bir trie veri yapısı. Her Ek'i (value) o ekin muhtemel yüzeyleri (key) ile eşleyerek tutar.<para/>
    /// Bir key (yüzey), birden fazla value'yu (Eki) gösterebileceği gibi bir value da birden fazla yüzey ile gösterilebilir.<para/>
    /// Örneğin i, ı, u, ü yüzeyleri sU (ISIM_SAHIPLIK_O_I) ekini gösterebilir.<para/>
    /// Aynı zamanda i yüzeyi hem sU (ISIM_SAHIPLIK_O_I) hem de yU (ISIM_BELIRTME_I) ekini gösterebilir.<para/>
    /// </summary>
    class SuffixTrie
    {
        readonly Trie<IList<Suffix>> trie = new Trie<IList<Suffix>>();

        /// <summary>
        /// Suffix trie'ye yeni bir eki (Morpheme) o ekin muhtemel yüzeylerinden biri (string) ile eşleyerek ekler.
        /// </summary>
        /// <param name="surface">Ekin yüzey biçimi (key)</param>
        /// <param name="suffix">Ek (value)</param>
        public void Put(string surface, Suffix suffix)
        {
            if (ExactMatchingSuffixExists(surface))
            {
                trie.Matcher.GetExactMatch().Add(suffix);
                return;
            }
            var newSuffixList = new List<Suffix>();
            newSuffixList.Add(suffix);
            trie.Put(surface, newSuffixList);
        }

        /// <summary>
        /// Trie'de prefix ile eşleşen ekler mevcut mu?
        /// </summary>
        /// <param name="prefix">Yüzey biçimleri için önek</param>
        /// <returns>
        ///   <c>true</c> Eğer belirtilen prefix ile başlayan Ek(ler) varsa; yoksa, <c>false</c>.
        /// </returns>
        public bool PrefixExists(string prefix)
        {
            trie.Matcher.ResetMatch();
            foreach (char ch in prefix)
            {
                if (!trie.Matcher.NextMatch(ch))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Trie'de key'in tam karşılığı olan bir Ek var mı?
        /// </summary>
        /// <param name="surface">Ekin muhtemel yüzey biçimi</param>
        /// <returns>
        ///   <c>true</c> Eğer belirtilen yüzeye tam karşılık gelen bir Ek varsa; yoksa, <c>false</c>.
        /// </returns>
        public bool ExactMatchingSuffixExists(string surface){
            if (PrefixExists(surface))
            {
                return trie.Matcher.IsExactMatch();
            }
            return false;
        }

        /// <summary>
        /// yüzey (surface) ile tam olarak eşleşen Ekleri döndürür. Yani muhtemel yüzey biçimlerinden biri bu yüzey olan ekler.
        /// </summary>
        /// <param name="surface">Ek yüzey biçimi</param>
        /// <returns>Mesela 'i' yüzeyi için sU ve yU ekleri</returns>
        public IList<Suffix> GetSuffixesExactMatch(string surface)
        {
            if (ExactMatchingSuffixExists(surface))
            {
                return trie.Matcher.GetExactMatch();
            }
            return  new List<Suffix>().AsReadOnly(); //return empty list
        }

        /// <summary>
        /// yüzeyi prefix ile başlayabilecek tüm ekleri döndürür.
        /// </summary>
        /// <param name="prefix">yüzey için önek</param>
        /// <returns>Mesela 'i' öneki için Um, sU ve yU ekleri</returns>
        public IList<Suffix> GetSuffixesStartWith(string prefix)
        {
            if (PrefixExists(prefix))
            {
                var listOfListOfMorphemes = trie.Matcher.GetPrefixMatches();
                return listOfListOfMorphemes.SelectMany(x => x).ToList();
            }
            return new List<Suffix>().AsReadOnly(); // return empty list
        }
    }
}

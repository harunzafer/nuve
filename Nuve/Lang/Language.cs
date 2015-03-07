using System;
using System.Collections.Generic;
using System.Diagnostics;
using Nuve.Morphologic;
using Nuve.Morphologic.Structure;
using Nuve.Orthographic;
using Nuve.Reader;

namespace Nuve.Lang
{
    /// <summary>
    /// Language sınıfı bir dile ait gerekli bilgiyi barındırır. WordAnalyzer sınıfı bu sınıftaki bilgileri 
    /// barındırdığı algoritma ile kullanarak kelimeleri analiz eder. Bu sınıfa ileride kelimelerin frekans 
    /// bilgisi gibi istatiksel veriler de eklenebilir.
    /// </summary>
    public sealed class Language
    {
        private readonly Orthography _orthography;
        private readonly Morphotactics _morphotactics;
        private readonly MorphemeSurfaceDictionary<Root> _roots;
        private readonly Suffixes _suffixes;

        internal Language(Orthography orthography, 
            Morphotactics morphotactics, 
            MorphemeSurfaceDictionary<Root> roots, 
            Suffixes suffixes)
        {
            _orthography = orthography;
            _morphotactics = morphotactics;
            _roots = roots;
            _suffixes = suffixes;
        }

        internal Morphotactics Morphotactics
        {
            get { return _morphotactics; }
        }

        public Suffix GetSuffix(string id)
        {
            Suffix suffix;
            if (_suffixes.SuffixesById.TryGetValue(id, out suffix))
            {
                return suffix;
            }

            return null;
        }

        public IEnumerable<Root> GetRoots(string surface)
        {
            return _roots.Get(surface);
        }

        public IEnumerable<Suffix> GetSuffixes(string surface)
        {
            return _suffixes.SuffixesBySurface.Get(surface);
        }

        public static readonly Language Turkish = LanguageReader.ReadInternal("Tr");
    }
}
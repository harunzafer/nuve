using System;
using System.Collections.Generic;
using System.Diagnostics;
using Nuve.Lexicon;
using Nuve.Morphologic;
using Nuve.Morphologic.Structure;
using Nuve.Orthographic;

namespace Nuve.Lang
{
    /// <summary>
    /// Language sınıfı bir dile ait gerekli bilgiyi barındırır. WordAnalyzer sınıfı bu sınıftaki bilgileri 
    /// barındırdığı algoritma ile kullanarak kelimeleri analiz eder. Bu sınıfa ileride kelimelerin frekans 
    /// bilgisi gibi istatiksel veriler de eklenebilir.
    /// </summary>
    public sealed partial class Language
    {
        private readonly Orthography _orthography;
        private readonly RootDictionary _rootDictionary;
        private readonly SuffixDictionary _suffixDictionary;
        private readonly Morphotactics _morphotactics;

        private Language(LanguageProperty languageProperty)
        {
            Stopwatch sw1 = Stopwatch.StartNew();
            _orthography = languageProperty.GetOrthography();
            _morphotactics = languageProperty.GetMorphotactics();
            _suffixDictionary = languageProperty.GetSuffixDictionary();
            _rootDictionary = languageProperty.GetRootDictionary();
            sw1.Stop();
            Console.WriteLine("Time taken for language: {0} ms", sw1.Elapsed.TotalMilliseconds);
        }

        internal Morphotactics Morphotactics
        {
            get { return _morphotactics; }
        }

        internal RootDictionary Roots
        {
            get { return _rootDictionary; }
        }

        internal SuffixDictionary Suffixes
        {
            get { return _suffixDictionary; }
        }

        public List<Root> GetRoots(string root)
        {
            return _rootDictionary.Get(root);
        }

        public Suffix GetSuffix(string id)
        {
            return _suffixDictionary.GetSuffix(id);
        }

        public static readonly Language Turkish = new Language(LanguageProperty.Tr);
    }
}
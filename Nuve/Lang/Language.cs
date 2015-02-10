using System;
using System.Collections.Generic;
using System.Diagnostics;
using Nuve.Dictionary;
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
        private readonly Lexicon lexicon;
        //private readonly SuffixDictionary _suffixTrie;
        //private readonly MorphemeLexicon<Suffix> suffixLexicon;
        private readonly Morphotactics _morphotactics;

        private Language(LanguageProperty languageProperty)
        {
            Stopwatch sw1 = Stopwatch.StartNew();
            _orthography = languageProperty.GetOrthography();
            _morphotactics = languageProperty.GetMorphotactics();
            lexicon = languageProperty.GetLexicon();
            //_suffixTrie = languageProperty.GetSuffixDictionary();
            //suffixLexicon = languageProperty.GetSuffixDictionary2();
            lexicon = languageProperty.GetLexicon();
            sw1.Stop();
            Console.WriteLine("Time taken for language: {0} ms", sw1.Elapsed.TotalMilliseconds);
        }

        internal Morphotactics Morphotactics
        {
            get { return _morphotactics; }
        }

        internal Dictionary.Lexicon Roots
        {
            get { return lexicon; }
        }

        //internal SuffixDictionary Suffixes
        //{
        //    get { return _suffixTrie; }
        //}

        internal Lexicon Lexicon
        {
            get { return lexicon; }
        }



        //public List<Root> GetRoots(string root)
        //{
        //    return lexicon.GetSuffix(root);
        //}

        //public Suffix GetSuffix(string id)
        //{          
        //    return _suffixTrie.GetSuffix(id);
        //}

        public static readonly Language Turkish = new Language(LanguageProperty.Tr);
    }
}
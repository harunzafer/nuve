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
        private readonly Lexicon _lexicon;

        internal Language(Orthography orthography, Morphotactics morphotactics, Lexicon lexicon)
        {
            _orthography = orthography;
            _morphotactics = morphotactics;
            _lexicon = lexicon;
        }

        internal Morphotactics Morphotactics
        {
            get { return _morphotactics; }
        }

        internal Lexicon Roots
        {
            get { return _lexicon; }
        }

        internal Lexicon Lexicon
        {
            get { return _lexicon; }
        }

        public static readonly Language Turkish = LanguageReader.ReadInternal("Tr");
    }
}
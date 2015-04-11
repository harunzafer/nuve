using System;
using System.Collections.Generic;
using Nuve.Morphologic;
using Nuve.Morphologic.Structure;
using Nuve.Reader;

namespace Nuve.Lang
{
    /// <summary>
    ///     Language sınıfı bir dile ait gerekli bilgiyi barındırır. WordAnalyzer sınıfı bu sınıftaki bilgileri
    ///     barındırdığı algoritma ile kullanarak kelimeleri analiz eder. Bu sınıfa ileride kelimelerin frekans
    ///     bilgisi gibi istatiksel veriler de eklenebilir.
    /// </summary>
    public sealed class Language
    {
        public static readonly Language Turkish;
        private readonly string _code;
        private readonly Morphotactics _morphotactics;
        private readonly MorphemeSurfaceDictionary<Root> _roots;
        private readonly Suffixes _suffixes;

        static Language()
        {
            try
            {
                Turkish = new LanguageReader("Tr", false).Read();
            }
            catch (InvalidLanguageFileException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        internal Language(string code,
            Morphotactics morphotactics,
            MorphemeSurfaceDictionary<Root> roots,
            Suffixes suffixes)
        {
            _code = code;
            _morphotactics = morphotactics;
            _roots = roots;
            _suffixes = suffixes;
        }

        internal Morphotactics Morphotactics
        {
            get { return _morphotactics; }
        }

        public IEnumerable<Suffix> AllSuffixes
        {
            get { return _suffixes.SuffixesById.Values; }
        }

        /// <summary>
        ///     Returns the immutable Suffix object having given id
        /// </summary>
        /// <param name="id">unique id of the Suffix</param>
        /// <returns>Returns the Suffix or null if no Suffix with the id exists</returns>
        public Suffix GetSuffix(string id)
        {
            Suffix suffix;
            if (_suffixes.SuffixesById.TryGetValue(id, out suffix))
            {
                return suffix;
            }

            return null;
        }

        /// <summary>
        ///     Returns the roots having the specified surface. For example if
        ///     the surface is "ara", for Language.Turkish this method returns
        ///     to roots, (ara ISIM) and (ara FIIL)
        /// </summary>
        /// <param name="surface"></param>
        /// <returns>Returns an empty list if no root has the specified surface</returns>
        public IEnumerable<Root> GetRootsHavingSurface(string surface)
        {
            return _roots.Get(surface);
        }


        /// <summary>
        ///     Returns the suffixes having the specified surface. For example if
        ///     the surface is "ma", for Language.Turkish this method returns
        ///     to suffixes, FIILIMSI_ISIM_mA and FY_OLUMSUZLUK_mA
        /// </summary>
        /// <param name="surface"></param>
        /// <returns>Returns an empty list if no suffix has the specified surface</returns>
        public IEnumerable<Suffix> GetSuffixesHavingSurface(string surface)
        {
            return _suffixes.SuffixesBySurface.Get(surface);
        }

        public override string ToString()
        {
            return _code;
        }
    }
}
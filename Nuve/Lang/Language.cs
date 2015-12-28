using System;
using System.Collections.Generic;
using Nuve.Morphologic;
using Nuve.Morphologic.Structure;
using Nuve.Orthographic;
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
            MorphemeContainer<Root> roots,
            MorphemeContainer<Suffix> suffixes)
        {
            Code = code;
            Morphotactics = morphotactics;
            Roots = roots;
            Suffixes = suffixes;
        }

        /// <summary>
        ///     The name is a combination of an ISO 639 two-letter lowercase culture code associated with a language and an ISO
        ///     3166 two-letter uppercase subculture code associated with a country or region.
        ///     https://msdn.microsoft.com/en-us/library/756hydy4%28v=vs.100%29.aspx
        ///     http://timtrott.co.uk/culture-codes/
        /// </summary>
        public string Code { get; }

        private MorphemeContainer<Suffix> Suffixes { get; }
        private MorphemeContainer<Root> Roots { get; }

        internal Morphotactics Morphotactics { get; }

        /// <summary>
        ///     Returns the immutable Suffix object having given id
        /// ddd
        /// </summary>
        public Suffix GetSuffix(string id)
        {
            Suffix suffix;
            if (Suffixes.ById.TryGetValue(id, out suffix))
            {
                return suffix;
            }

            return null;
        }

        public Root GetRoot(string rootId)
        {
            rootId.ThrowIfNull();
            var tokens = rootId.Split('/');
            if (tokens.Length != 2)
            {
                throw new ArgumentException($"Invalid root id \"{rootId}\". A valid root ID shoul be in the form of lex/pos. Ex: kitap/NOUN");
            }

            return GetRoot(tokens[0], tokens[1]);
        }

        public Root GetRoot(string lex, string pos)
        {
            Root root;
            var rootId = lex + "/" + pos;
            if (Roots.ById.TryGetValue(rootId, out root))
            {
                return root;
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
            return Roots.BySurface.Get(surface);
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
            return Suffixes.BySurface.Get(surface);
        }

        public override string ToString()
        {
            return Code;
        }

        public Word Generate(params string[] morphemes)
        {
            StringExtensions.ThrowIfNullAny(morphemes);

            var root = GetRoot(morphemes[0]);

            if (root == null)
            {
                return null;
            }

            var word = new Word(root);
            for (var i = 1; i < morphemes.Length; i++)
            {
                var suffix = GetSuffix(morphemes[i]);
                if (suffix == null)
                {
                    return null;
                }
                word.AddSuffix(suffix);
            }

            return word;


        }

        public Word GetWord(string analysis)
        {
            analysis.ThrowIfNull();
            analysis.ThrowIfEmpty();

            var tokens = analysis.Split(' ');

            return Generate(tokens);
        }

    }
}
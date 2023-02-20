using System;
using System.Collections.Generic;
using Nuve.Morphologic;
using Nuve.Morphologic.Structure;
using Nuve.Orthographic;

namespace Nuve.Lang
{
    /// <summary>
    ///     Enum for supported languages in Nüve.
    /// </summary>
    //public enum LanguageType
    //{
    //    Turkish
    //}

    /// <summary>
    ///     Represents a language which is supported by Nüve.
    /// </summary>
    public class Language
    {
        internal Language(LanguageType type,
            Orthography orthography,
            Morphotactics morphotactics,
            MorphemeContainer<Root> roots,
            MorphemeContainer<Suffix> suffixes)
        {
            Type = type;
            Orthography = orthography;
            Morphotactics = morphotactics;
            Roots = roots;
            Suffixes = suffixes;
            Analyzer = new WordAnalyzer(this);
        }

        /// <summary>
        ///     Type (name) of this language object.
        /// </summary>
        public LanguageType Type { get; }

        internal Orthography Orthography { get; }
        internal Morphotactics Morphotactics { get; }

        internal MorphemeContainer<Suffix> Suffixes { get; }
        internal MorphemeContainer<Root> Roots { get; }

        private WordAnalyzer Analyzer { get; }


        /// <summary>
        ///     Returns all suffixes defined in this language.
        /// </summary>
        public IEnumerable<Suffix> AllSuffixes => Suffixes.ById.Values;

        /// <summary>
        ///     Returns all roots defined in this languages
        /// </summary>
        public IEnumerable<Root> AllRoots => Roots.ById.Values;

        /// <summary>
        ///     Analyzes a token in the context of this language and returns all possible solutions.
        /// </summary>
        public IList<Word> Analyze(string token)
        {
            return Analyzer.Analyze(token);
        }

        /// <summary>
        ///     Returns the Suffix object having specified id in this language.
        ///     Returns null if the suffix is not found.
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

        /// <summary>
        ///     Returns the Root object having specified id in this language.
        ///     Id of a root is defined with its lexical form and part-of-speech tag such as "lex/POS".
        ///     Returns null if the suffix is not found.
        /// </summary>
        public Root GetRoot(string rootId)
        {
            rootId.ThrowIfNull();
            var tokens = rootId.Split('/');
            if (tokens.Length != 2)
            {
                throw new ArgumentException(
                    $"Invalid root id \"{rootId}\". A valid root ID shoul be in the form of lex/pos. Ex: kitap/NOUN");
            }

            return GetRoot(tokens[0], tokens[1]);
        }

        /// <summary>
        ///     Returns the Root object having specified lexical form and part-of-speech in this language.
        ///     lexical form and part-of-speech defines a uniqe id for a root such as "lex/POS".
        ///     Returns null if the suffix is not found.
        /// </summary>
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

        internal IEnumerable<T> GetMorphemesHavingSurface<T>(string surface) where T : Morpheme
        {
            if (typeof(T) == typeof(Root))
            {
                return Roots.BySurface.Get(surface) as IEnumerable<T>;
            }
            return Suffixes.BySurface.Get(surface) as IEnumerable<T>;
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
            return Type.CountryCode=="??" ? Type.Code : Type.CultureCode;
        }

        /// <summary>
        ///     Creates and returns a word with the specified "morpheme id" sequence
        /// </summary>
        public Word Generate(params string[] morphemes)
        {
            StringExtensions.ThrowIfNullAny(morphemes);

            var index = StringExtensions.ContainsWhitespaceAny(morphemes);

            //var index  = StringExtensions.ContainsWhitespaceAny(morphemes);

            //if (index >= 0)
            //{
            //    throw new ArgumentException($"Morpheme identifier can not contain whitespace: \"{morphemes[index]}\"");
            //}

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

        /// <summary>
        ///     Creates and returns a word with the specified string represenation of its analysis
        ///     A word object's analysis can be obtainded as a string with word.ToString() method.
        /// </summary>
        public Word GetWord(string analysis)
        {
            analysis.ThrowIfNull();
            analysis.ThrowIfEmpty();

            var tokens = analysis.Split(' ');
            return Generate(tokens);
        }
    }
}
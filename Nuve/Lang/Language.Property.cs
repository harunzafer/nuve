using System;
using System.Diagnostics;
using Nuve.Dictionary;
using Nuve.Morphologic;
using Nuve.Morphologic.Structure;
using Nuve.Orthographic;
using Nuve.Properties;
using Nuve.Reader;

namespace Nuve.Lang
{
    /// <summary>
    ///     Bir dile ait kaynak dosyaları okur ve dil nesnesine döndürür.
    /// </summary>
    partial class Language
    {
        private class LanguageProperty
        {
            internal static readonly LanguageProperty Tr = new LanguageProperty("tr");
            private readonly string _abbreviationFilename;

            private readonly string _langCode;
            private readonly string _morphotacticsFilename;
            private readonly string _nameFilename;

            private readonly Orthography _orthography;
            private readonly string _rootFilename;
            private readonly string _suffixFilename;

            private LanguageProperty(string langCode)
            {
                Stopwatch sw1 = Stopwatch.StartNew();

                _langCode = langCode;
                string orthographyFilename = InsertLangCode(Resources.Orthography);
                _morphotacticsFilename = InsertLangCode(Resources.Morphotactics);
                _suffixFilename = InsertLangCode(Resources.Suffixes);
                _rootFilename = InsertLangCode(Resources.Roots);
                _nameFilename = InsertLangCode(Resources.Names);
                _abbreviationFilename = InsertLangCode(Resources.Abbreviations);
                _orthography = OrthographyReader.Read(orthographyFilename);

                sw1.Stop();
                Console.WriteLine("Time taken for orthography: {0} ms", sw1.Elapsed.TotalMilliseconds);
            }

            private string InsertLangCode(string filename)
            {
                int index = filename.IndexOf('.');
                return filename.Substring(0, index) + "_" + _langCode + filename.Substring(index);
            }


            internal Morphotactics GetMorphotactics()
            {
                Stopwatch sw1 = Stopwatch.StartNew();
                Morphotactics morphotactics = MorphotacticsReader.Read(_morphotacticsFilename, _orthography.Alphabet);
                sw1.Stop();
                Console.WriteLine("Time taken for morphotactics: {0} ms", sw1.Elapsed.TotalMilliseconds);
                return morphotactics;
            }


            internal Orthography GetOrthography()
            {
                return _orthography;
            }

            internal Lexicon GetLexicon()
            {
                Stopwatch sw1 = Stopwatch.StartNew();

                string[] filenames = {_rootFilename, _nameFilename, _abbreviationFilename};

                var reader = new LexiconReader(_orthography);
                Lexicon lexicon = reader.Read(filenames, _suffixFilename);

                sw1.Stop();
                Console.WriteLine("Time taken for lexicon: {0} ms", sw1.Elapsed.TotalMilliseconds);
                return lexicon;
            }

        }
    }
}
using System;
using System.Diagnostics;
using Nuve.Lexicon;
using Nuve.Morphologic;
using Nuve.Orthographic;
using Nuve.Properties;
using Nuve.Reader;

namespace Nuve.Lang
{
    /// <summary>
    /// Bir dile ait kaynak dosyaları okur ve dil nesnesine döndürür.
    /// </summary>
    partial class Language
    {
        private class LanguageProperty
        {
            private const bool UseExcel = false;

            private readonly string _langCode;
            private readonly string _morphotacticsFilename;
            private readonly string _suffixFilename;
            private readonly string _rootFilename;
            private readonly string _nameFilename;
            private readonly string _abbreviationFilename;

            private readonly Orthography _orthography;

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

            internal RootDictionary GetRootDictionary()
            {
                Stopwatch sw1 = Stopwatch.StartNew();
                RootDictionary rd;

                if (UseExcel)
                {
                    string filename = Resources.ResourcesPath + Resources.RootsFile;
                    rd = ExcelRootReader.Read(filename, _orthography);
                }
                else
                {
                    string[] filenames = {_rootFilename, _nameFilename};
                    rd = TextRootReader.Read(filenames, _orthography);
                }


                sw1.Stop();
                Console.WriteLine("Time taken for roots: {0} ms", sw1.Elapsed.TotalMilliseconds);
                return rd;
            }

            internal SuffixDictionary GetSuffixDictionary()
            {
                Stopwatch sw1 = Stopwatch.StartNew();

                SuffixDictionary sd;

                if (UseExcel)
                {
                    string filename = Resources.ResourcesPath + Resources.SuffixFile;
                    sd = ExcelSuffixReader.Read(filename, _orthography);
                }
                else
                {
                    sd = TextSuffixReader.Read(_suffixFilename, _orthography);
                }


                sw1.Stop();
                Console.WriteLine("Time taken for suffixes: {0} ms", sw1.Elapsed.TotalMilliseconds);
                return sd;
            }


            internal static readonly LanguageProperty Tr = new LanguageProperty("tr");
        }
    }
}
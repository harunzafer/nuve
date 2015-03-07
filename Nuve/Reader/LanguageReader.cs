using System.Collections.Generic;
using System.Data;
using Nuve.Lang;
using Nuve.Morphologic;
using Nuve.Morphologic.Structure;
using Nuve.Orthographic;
using Nuve.Properties;

namespace Nuve.Reader
{
    public static class LanguageReader
    {
        public static Language ReadInternal(string langCode)
        {
            var orthography = ReadInternalOrthography(langCode);
            var morphotactics = ReadInternalMorphotactics(langCode, orthography.Alphabet);
            var roots = ReadInternalRoots(langCode, orthography);
            var suffixes = ReadInternalSuffixes(langCode, orthography);

            return new Language(orthography, morphotactics, roots, suffixes);
        }

        private static Orthography ReadInternalOrthography(string lang)
        {
            var path = lang + "." + Resources.Orthography;
            var xml = EmbeddedResourceReader.ReadXml(path);
            return OrthographyReader.Read(xml);
        }

        private static Morphotactics ReadInternalMorphotactics(string lang, Alphabet alphabet)
        {
            var path = lang + "." + Resources.Morphotactics;
            var xml = EmbeddedResourceReader.Read(path);
            return MorphotacticsReader.Read(xml, alphabet);
        }

        private static MorphemeSurfaceDictionary<Root> ReadInternalRoots(string lang, Orthography orthography)
        {
            var roots = new MorphemeSurfaceDictionary<Root>();
            var reader = new RootLexiconReader(orthography);

            var rootsPath = lang + "." + Resources.Roots;
            reader.AddEntries(GetAsDataSet(rootsPath), DefaultTableName, roots);

            var namesPath = lang + "." + Resources.Names;
            reader.AddEntries(GetAsDataSet(namesPath), DefaultTableName, roots);

            var abbreviationPath = lang + "." + Resources.Abbreviations;
            reader.AddEntries(GetAsDataSet(abbreviationPath), DefaultTableName, roots);

            return roots;
        }

        private static Suffixes ReadInternalSuffixes(string lang, Orthography orthography)
        {
            Dictionary<string, Suffix> suffixesById;
            MorphemeSurfaceDictionary<Suffix> suffixesBySurface;

            var path = lang + "." + Resources.Suffixes;
            var dataSet = GetAsDataSet(path);

            var reader = new SuffixLexiconReader(orthography);
            reader.Read(dataSet, DefaultTableName, out suffixesById, out suffixesBySurface);

            return new Suffixes(suffixesById, suffixesBySurface);
        }

        //if (_fromExcel)
        //    { 
        //        var connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}; " +
        //            "Extended Properties=Excel 12.0;", filename);
        //        var adapter = new OleDbDataAdapter("SELECT * FROM [" + sheetname + "$]", connectionString);
        //        ds = new DataSet();
        //        adapter.Fill(ds, "roots");
        //    }

        private const string Delimiter = "\t";

        public const string DefaultTableName = "sheet";

        private static DataSet GetAsDataSet(string path)
        {
            var textStream = EmbeddedResourceReader.Read(path);
            return TextToDataSet.Convert(textStream, DefaultTableName, Delimiter);
        }

        //1- Excelden veya Text'den dataset'ler burada oluşturulmalı
        //2- Hem suffix hem root reader ortografi, params dataset almalı ve oradan yürümeli
        //3- EmbeddedResourceReader ve TextToDataset sınıfları yalnızca buradan çağılısın
        //4- Excel dosyalarından okunacak sheet'ler burada belirtilsin


        public static Language ReadExternal(string path)
        {
            return null;
        }
        
    }
}
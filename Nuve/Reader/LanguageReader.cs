using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Xml;
using Nuve.Lang;
using Nuve.Morphologic;
using Nuve.Morphologic.Structure;
using Nuve.Orthographic;
using Nuve.Properties;

namespace Nuve.Reader
{
    public static class LanguageReader
    {

        public static Language ReadExternal(string dirPath)
        {
            var orthography = ReadExternalOrthography(dirPath);
            var morphotactics = ReadExternalMorphotactics(dirPath, orthography.Alphabet);
            var roots = ReadExternalRoots(dirPath, orthography);
            var suffixes = ReadExternalSuffixes(dirPath, orthography);

            return new Language(orthography, morphotactics, roots, suffixes);
        }

        internal static Language ReadInternal(string langCode)
        {
            var orthography = ReadInternalOrthography(langCode);
            var morphotactics = ReadInternalMorphotactics(langCode, orthography.Alphabet);
            var roots = ReadInternalRoots(langCode, orthography);
            var suffixes = ReadInternalSuffixes(langCode, orthography);

            return new Language(orthography, morphotactics, roots, suffixes);
        }

        private static Orthography ReadInternalOrthography(string lang)
        {
            var path = lang + "." + Resources.OrthographyFileName;
            var xml = EmbeddedResourceReader.ReadXml(path);
            return OrthographyReader.Read(xml);
        }

        private static Morphotactics ReadInternalMorphotactics(string lang, Alphabet alphabet)
        {
            var path = lang + "." + Resources.MorphotacticsFileName;
            var xml = EmbeddedResourceReader.Read(path);
            return MorphotacticsReader.Read(xml, alphabet);
        }

        private static MorphemeSurfaceDictionary<Root> ReadInternalRoots(string lang, Orthography orthography)
        {
            var roots = new MorphemeSurfaceDictionary<Root>();
            var reader = new RootLexiconReader(orthography);

            var rootsPath = lang + "." + Resources.InternalMainRootsPath;
            reader.AddEntries(EmbeddedTextResourceToDataSet(rootsPath), DefaultTableName, roots);

            var namesPath = lang + "." + Resources.InternalPersonNamesPath;
            reader.AddEntries(EmbeddedTextResourceToDataSet(namesPath), DefaultTableName, roots);

            var abbreviationPath = lang + "." + Resources.InternalAbbreviationsPath;
            reader.AddEntries(EmbeddedTextResourceToDataSet(abbreviationPath), DefaultTableName, roots);

            return roots;
        }

        private static Suffixes ReadInternalSuffixes(string lang, Orthography orthography)
        {
            Dictionary<string, Suffix> suffixesById;
            MorphemeSurfaceDictionary<Suffix> suffixesBySurface;

            var path = lang + "." + Resources.InternalSuffixesPath;
            var dataSet = EmbeddedTextResourceToDataSet(path);

            var reader = new SuffixLexiconReader(orthography);
            reader.Read(dataSet, DefaultTableName, out suffixesById, out suffixesBySurface);

            return new Suffixes(suffixesById, suffixesBySurface);
        }


        private const string Delimiter = "\t";

        public const string DefaultTableName = "sheet";

        private static DataSet EmbeddedTextResourceToDataSet(string path)
        {
            var textStream = EmbeddedResourceReader.Read(path);
            return TextToDataSet.Convert(textStream, DefaultTableName, Delimiter);
        }
      
        private static Orthography ReadExternalOrthography(string dirPath)
        {
            var path = dirPath + "/" + Resources.OrthographyFileName;
            var xml = new XmlDocument();
            xml.Load(path);
            return OrthographyReader.Read(xml);
        }

        private static Morphotactics ReadExternalMorphotactics(string dirPath, Alphabet alphabet)
        {
            var path = dirPath + "/" + Resources.MorphotacticsFileName;
            var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            return MorphotacticsReader.Read(stream, alphabet);
        }

        private static MorphemeSurfaceDictionary<Root> ReadExternalRoots(string dirPath, Orthography orthography)
        {
            var roots = new MorphemeSurfaceDictionary<Root>();
            var reader = new RootLexiconReader(orthography);

            var path = dirPath + "\\" + Resources.ExternalRootsFileName;


            string sheetName = Resources.SheetNameMainRoots;
            DataSet ds = GetExcelSheetAsDataSet(path, sheetName);
            reader.AddEntries(ds, sheetName, roots);


            sheetName = Resources.SheetNamePersonNames;
            ds = GetExcelSheetAsDataSet(path, sheetName);
            reader.AddEntries(ds, sheetName, roots);

            sheetName = Resources.SheetNameAbbreviations;
            ds = GetExcelSheetAsDataSet(path, sheetName);
            reader.AddEntries(ds, sheetName, roots);

            return roots;
        }

        private static Suffixes ReadExternalSuffixes(string langDir, Orthography orthography)
        {
            Dictionary<string, Suffix> suffixesById;
            MorphemeSurfaceDictionary<Suffix> suffixesBySurface;

            var path = langDir + "/" + Resources.ExternalSuffixFileName;

            string sheetName = Resources.SheetNameSuffixes;
            DataSet ds = GetExcelSheetAsDataSet(path, sheetName);
            
            var reader = new SuffixLexiconReader(orthography);
            reader.Read(ds, sheetName, out suffixesById, out suffixesBySurface);

            return new Suffixes(suffixesById, suffixesBySurface);
        }

        private static DataSet GetExcelSheetAsDataSet(string path, string sheetName)
        {
            var connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}; " +
                "Extended Properties=Excel 12.0;", path);
            var adapter = new OleDbDataAdapter("SELECT * FROM [" + sheetName + "$]", connectionString);
            var ds = new DataSet();

            try
            {
                adapter.Fill(ds, sheetName);
            }
            catch (Exception exception)
            {

                Console.WriteLine(exception.Message);
                Console.WriteLine(exception);
            }
            
            return ds;
        }
        
    }
}
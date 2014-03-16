using System;
using System.Data;
using System.Data.OleDb;
using Nuve.Lexicon;
using Nuve.Morphologic.Structure;
using Nuve.Orthographic;

namespace Nuve.Reader
{
    internal class ExcelRootReader
    {
        private static Orthography _orthography;

        private class DictionaryLine
        {
            public string Root;
            public string Surfaces;
            public string Lex;
            public string Active;
            public string Flags;
            public string Id;
            public string Rules;
        }
        
        public static RootDictionary Read(string filename, Orthography orthography)
        {
            _orthography = orthography;
            return ReadRoots(filename);
        }

        public static RootDictionary ReadRoots(string filename)
        {
            var roots = new RootDictionary();
            AddEntries(filename, "roots", roots);
            AddEntries(filename, "names", roots);
            AddEntries(filename, "abbr", roots);
            return roots;
        }

        private static void AddEntries(string filename, string sheetname, RootDictionary roots)
        {
            var connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}; " +
                                                 "Extended Properties=Excel 12.0;", filename);

            var adapter = new OleDbDataAdapter("SELECT * FROM [" + sheetname + "$]", connectionString);
            var ds = new DataSet();

            adapter.Fill(ds, "roots");
            var data = ds.Tables["roots"].AsEnumerable();
            EnumerableRowCollection<DictionaryLine> entries = data.Select(x =>
                                                          new DictionaryLine
                                                              {
                                                                  Root = x.Field<string>("root"),
                                                                  Surfaces = x.Field<string>("surfaces") ?? "",
                                                                  Lex = x.Field<string>("lex"),
                                                                  Active = x.Field<string>("active") ?? "",
                                                                  Id = x.Field<string>("Id"),
                                                                  Flags = x.Field<string>("flags") ?? "",
                                                                  Rules = x.Field<string>("rules") ?? "",
                                                              });
            foreach (var entry in entries)
            {
                if (entry.Active == "")
                {
                    AddRoots(entry, roots);
                }
            }
        }

        private static void AddRoots(DictionaryLine entry, RootDictionary roots)
        {
            string item = entry.Root;
            string[] surfaces = entry.Surfaces.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string lex = entry.Lex;
            string[] flags = entry.Flags.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string type = entry.Id;
            string[] rules = entry.Rules.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);


            if (string.IsNullOrEmpty(entry.Lex))
            {
                lex = item;
            }

            Root root;
            if (type == "KISALTMA" || type == "ALINTI" || type == "NOKTALI" || type == "HARF")
            {
                root = new Root(type, lex, LabelSet.ConvertLabelNamesToIndexes(flags), _orthography.GetRules(rules), item);
            }
            else
            {
                root = new Root(type, lex, LabelSet.ConvertLabelNamesToIndexes(flags), _orthography.GetRules(rules));
            }

            roots.Add(item, root); // kelimeyi asıl yüzeyi ile ekliyoruz

            //eğer fazladan yüzeyi var ise onunla da ekliyoruz.
            foreach(string lexicalForm in surfaces){
                roots.Add(lexicalForm, root);
            }
        }
    }
}
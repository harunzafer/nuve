using System;
using System.Data;
using System.Data.OleDb;
using Nuve.Morphologic;
using Nuve.Morphologic.Structure;
using Nuve.Orthographic;

namespace Nuve.Reader
{
    internal class RootLexiconReader
    {
        private readonly Orthography orthography;
        private readonly bool fromExcel;

        public RootLexiconReader(Orthography orthography, bool fromExcel = false)
        {
            this.orthography = orthography;
            this.fromExcel = fromExcel;
        }

        private class RootLine
        {
            public string Root;
            public string Surfaces;
            public string Lex;
            public string Active;
            public string Flags;
            public string Id;
            public string Rules;
        }

        public MorphemeLexicon<Root> Read(string[] filenames)
        {
            return ReadRoots(filenames);
        }

        public MorphemeLexicon<Root> ReadRoots(string[] filenames)
        {
            var roots = new MorphemeLexicon<Root>();
            foreach (string filename in filenames)
            {
                AddEntries(filename, filename, roots);
            }

            return roots;
        }

        private void AddEntries(string filename, string sheetname, MorphemeLexicon<Root> roots)
        {

            DataSet ds;

            if (fromExcel)
            { 
                var connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}; " +
                    "Extended Properties=Excel 12.0;", filename);
                var adapter = new OleDbDataAdapter("SELECT * FROM [" + sheetname + "$]", connectionString);
                ds = new DataSet();
                adapter.Fill(ds, "roots");
            }
            else
            {
                ds = TextToDataSet.Convert(filename, sheetname, "\t");    
            }

            


            var data = ds.Tables[sheetname].AsEnumerable();
            EnumerableRowCollection<RootLine> entries = data.Select(x =>
                                                          new RootLine
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

        private void AddRoots(RootLine entry, MorphemeLexicon<Root> roots)
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
                root = new Root(type, lex, LabelSet.ConvertLabelNamesToIndexes(flags), orthography.GetRules(rules), item);
            }
            else
            {
                root = new Root(type, lex, LabelSet.ConvertLabelNamesToIndexes(flags), orthography.GetRules(rules));
            }

            roots.Add(item, root); // kelimeyi asıl yüzeyi ile ekliyoruz

            //eğer fazladan yüzeyi var ise onunla da ekliyoruz.
            foreach (string lexicalForm in surfaces)
            {
                roots.Add(lexicalForm, root);
            }
        }
    }
}
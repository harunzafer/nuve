using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using Nuve.Lexicon;
using Nuve.Morphologic.Structure;
using Nuve.Orthographic;

namespace Nuve.Reader
{
    internal class ExcelSuffixReader
    {
        private static Orthography _orthography;

        

        private class DictionaryLine
        {
            public string Id;
            public string Lex;
            public string Type;
            public string Flags;
            public string Rules;
            public string Surfaces;
        }
        
        public static SuffixDictionary Read(string filename, Orthography orthography)
        {
            _orthography = orthography;
            return ReadRoots(filename);
        }

        public static SuffixDictionary ReadRoots(string filename)
        {
            var suffixes = new Dictionary<string, Suffix>();
            var suffixTrie = new SuffixTrie();

            var connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}; " +
                                                 "Extended Properties=Excel 12.0;", filename);

            var adapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", connectionString);
            
            var ds = new DataSet();

            adapter.Fill(ds, "suffixes");

            var data = ds.Tables["suffixes"].AsEnumerable();
            
            
            var entries = data.Select(x =>
                        new DictionaryLine
                        {
                            Id = x.Field<string>("id"),
                            Lex = x.Field<string>("lexicalForm"),
                            Type = x.Field<string>("type"),
                            Flags = x.Field<string>("flags") ?? "",
                            Rules = x.Field<string>("rules") ?? "",
                            Surfaces = x.Field<string>("surfaces"),
                        });


            foreach (var entry in entries)
            {
                AddRoots(entry, suffixTrie, suffixes);
            }

            return new SuffixDictionary(suffixes, suffixTrie);

        }
        

        private static void AddRoots(DictionaryLine entry, SuffixTrie trie, Dictionary<string, Suffix> suffixes)
        {
            //id	lexicalForm	Order	rules	surfaces

            string id = entry.Id; 
            string lex = entry.Lex;
            Morphologic.Structure.MorphemeType morphemeType;

            if (!Enum.TryParse(entry.Type, out morphemeType))
            {
                throw new ArgumentException("Invalid Morpheme Type: " + entry.Type);
            }



            string[] flags = entry.Flags.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] rulesToken = entry.Rules.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Debug.Assert(entry.Surfaces != null, "entry.Surfaces != null");
            string[] surfaces = entry.Surfaces.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            List<OrthographyRule> rules = _orthography.GetRules(rulesToken);
            var suffix = new Suffix(id, lex, morphemeType, LabelSet.ConvertLabelNamesToIndexes(flags), rules);
            suffixes.Add(id, suffix);

            foreach (var surface in surfaces)
            {
                trie.Put(surface, suffix);
            }
            
        }

        

        
        
    }
}
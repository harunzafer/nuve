using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Nuve.Lexicon;
using Nuve.Morphologic.Structure;
using Nuve.Orthographic;

namespace Nuve.Reader
{
    internal class TextSuffixReader
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
            public string EmptySurface;
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
            var ds = TextToDataSet.Convert(filename, "suffix", "\t");
            var data = ds.Tables["suffix"].AsEnumerable();
            var entries = data.Select(x =>
                        new DictionaryLine
                        {
                            Id = x.Field<string>("id"),
                            Lex = x.Field<string>("lexicalForm"),
                            Type = x.Field<string>("type"),
                            Flags = x.Field<string>("flags") ?? "",
                            Rules = x.Field<string>("rules") ?? "",
                            Surfaces = x.Field<string>("surfaces"),
                            EmptySurface = x.Field<string>("emptySurface") ?? "",
                        });


            foreach (var entry in entries)
            {
                AddSuffix(entry, suffixTrie, suffixes);
            }

            return new SuffixDictionary(suffixes, suffixTrie);

        }
        

        private static void AddSuffix(DictionaryLine entry, SuffixTrie trie, Dictionary<string, Suffix> suffixes)
        {
            //id	lexicalForm	Order	rules	surfaces

            string id = entry.Id; 
            string lex = entry.Lex;
            MorphemeType morphemeType;

            if (!Enum.TryParse(entry.Type, out morphemeType))
            {
                morphemeType = MorphemeType.O;
                Console.WriteLine("Invalid Morpheme Type: " + entry.Type);
            }

            string[] flags = entry.Flags.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] rulesToken = entry.Rules.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Debug.Assert(entry.Surfaces != null, "entry.Surfaces != null");
            var surfaces = new List<string>(entry.Surfaces.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries));

            //bool emptySurface = entry.EmptySurface == "TRUE";
            //if (emptySurface)
            //{
            //   surfaces.Add("");//Burada tam olarak ne yapmaya çalışıyoruz? Boş ek meselesini mi çözmeye çalışıyoruz?
            //}   

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
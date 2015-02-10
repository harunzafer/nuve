using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Nuve.Dictionary;
using Nuve.Morphologic.Structure;
using Nuve.Orthographic;

namespace Nuve.Reader
{
    internal class SuffixLexiconReader
    {
        private readonly Orthography orthography;

        public SuffixLexiconReader(Orthography orthography)
        {
            this.orthography = orthography;
        }

        private class SuffixDictionaryLine
        {
            public string Id;
            public string Lex;
            public string Type;
            public string Flags;
            public string Rules;
            public string Surfaces;
            public string EmptySurface;
        }
        
        public void Read(string filename, 
            out Dictionary<string, Suffix> suffixesById, 
            out MorphemeLexicon<Suffix> suffixes)
        {

            var ds = TextToDataSet.Convert(filename, "suffix", "\t");
            var data = ds.Tables["suffix"].AsEnumerable();
            var entries = data.Select(x =>
                        new SuffixDictionaryLine
                        {
                            Id = x.Field<string>("id"),
                            Lex = x.Field<string>("lexicalForm"),
                            Type = x.Field<string>("type"),
                            Flags = x.Field<string>("flags") ?? "",
                            Rules = x.Field<string>("rules") ?? "",
                            Surfaces = x.Field<string>("surfaces"),
                            EmptySurface = x.Field<string>("emptySurface") ?? "",
                        });


            suffixesById = new Dictionary<string, Suffix>();
            suffixes = new MorphemeLexicon<Suffix>();

            foreach (var entry in entries)
            {
                AddSuffix(entry,  suffixesById,  suffixes);
            }
        }
        

        private void AddSuffix(SuffixDictionaryLine entry,
             Dictionary<string, Suffix> suffixesById,
             MorphemeLexicon<Suffix> suffixes)
        {

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

            List<OrthographyRule> rules = orthography.GetRules(rulesToken);
            var suffix = new Suffix(id, lex, morphemeType, LabelSet.ConvertLabelNamesToIndexes(flags), rules);
            suffixesById.Add(id, suffix);
            
            foreach (var surface in surfaces)
            {
                suffixes.Add(surface, suffix);                
            }
           
        }

    }
}
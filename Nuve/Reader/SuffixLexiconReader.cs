using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Nuve.Morphologic;
using Nuve.Morphologic.Structure;
using Nuve.Orthographic;

namespace Nuve.Reader
{
    internal class SuffixLexiconReader
    {
        private readonly Orthography _orthography;

        public SuffixLexiconReader(Orthography orthography)
        {
            _orthography = orthography;
        }

        public void Read(DataSet ds,
            string tableName,
            out Dictionary<string, Suffix> suffixesById,
            out MorphemeSurfaceDictionary<Suffix> suffixes)
        {
            EnumerableRowCollection<DataRow> data = ds.Tables[tableName].AsEnumerable();
            EnumerableRowCollection<SuffixDictionaryLine> entries = data.Select(x =>
                new SuffixDictionaryLine
                {
                    Id = x.Field<string>("id"),
                    Lex = x.Field<string>("lexicalForm"),
                    Type = x.Field<string>("type"),
                    Flags = x.Field<string>("flags") ?? "",
                    Rules = x.Field<string>("rules") ?? "",
                    Surfaces = x.Field<string>("surfaces"),
                });


            suffixesById = new Dictionary<string, Suffix>();
            suffixes = new MorphemeSurfaceDictionary<Suffix>();

            foreach (SuffixDictionaryLine entry in entries)
            {
                AddSuffix(entry, suffixesById, suffixes);
            }
        }


        private void AddSuffix(SuffixDictionaryLine entry,
            Dictionary<string, Suffix> suffixesById,
            MorphemeSurfaceDictionary<Suffix> suffixes)
        {
            string id = entry.Id;
            string lex = entry.Lex;
            MorphemeType morphemeType;

            if (!Enum.TryParse(entry.Type, out morphemeType))
            {
                morphemeType = MorphemeType.O;
                Console.WriteLine("Invalid Morpheme Type: " + entry.Type);
            }

            string[] flags = entry.Flags.Split(new[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);
            string[] rulesToken = entry.Rules.Split(new[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);
            Debug.Assert(entry.Surfaces != null, "entry.Surfaces != null");
            var surfaces =
                new List<string>(entry.Surfaces.Split(new[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries));

            List<OrthographyRule> rules = _orthography.GetRules(rulesToken);
            var suffix = new Suffix(id, lex, morphemeType, LabelSet.ConvertLabelNamesToIndexes(flags), rules);
            suffixesById.Add(id, suffix);

            foreach (string surface in surfaces)
            {
                suffixes.Add(surface.Replace('_', ' '), suffix);
            }
        }

        private class SuffixDictionaryLine
        {
            public string Flags;
            public string Id;
            public string Lex;
            public string Rules;
            public string Surfaces;
            public string Type;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Nuve.Immutables;
using Nuve.Morphologic;
using Nuve.Morphologic.Structure;
using Nuve.Orthographic;

namespace Nuve.Reader
{
    internal class SuffixLexiconReader
    {
        private readonly Orthography _orthography;
        private static readonly TraceSource Trace = new TraceSource("SuffixLexiconReader");

        public SuffixLexiconReader(Orthography orthography)
        {
            _orthography = orthography;
        }

        public MorphemeContainer<Suffix> Read(DataSet ds,
            string tableName
            )
        {
            EnumerableRowCollection<DataRow> data = ds.Tables[tableName].AsEnumerable();
            EnumerableRowCollection<SuffixDictionaryLine> entries = data.Select(x =>
                new SuffixDictionaryLine
                {
                    Id = x.Field<string>("id")?.Trim(),
                    Lex = x.Field<string>("lexicalForm")?.Trim(),
                    Type = x.Field<string>("type")?.Trim(),
                    Labels = x.Field<string>("flags")?.Trim() ?? "",
                    Rules = x.Field<string>("rules")?.Trim() ?? "",
                    Surfaces = x.Field<string>("surfaces")?.Trim(),
                });

            var suffixesById = new Dictionary<string, Suffix>();
            var suffixesBySurface = new MorphemeSurfaceDictionary<Suffix>();

            foreach (SuffixDictionaryLine entry in entries)
            {
                AddSuffix(entry, suffixesById, suffixesBySurface);
            }

            return new MorphemeContainer<Suffix>(suffixesById, suffixesBySurface);
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
                Trace.TraceEvent(TraceEventType.Error, 0, $"Invalid Morpheme Type: {entry.Type}");
            }

            string[] labels = entry.Labels.Split(new[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);
            string[] rulesToken = entry.Rules.Split(new[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);
            Debug.Assert(entry.Surfaces != null, "entry.Surfaces != null");
            var surfaces =
                new List<string>(entry.Surfaces.Split(new[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries));

            List<OrthographyRule> rules = _orthography.GetRules(rulesToken);
            var suffix = new Suffix(id, lex, new ImmutableSortedSet<string>(surfaces), morphemeType, new ImmutableHashSet<string>(labels), rules);
            if (suffixesById.ContainsKey(id))
            {
                Trace.TraceEvent(TraceEventType.Warning, 0, $"Duplicate suffix: {id}");
            }
            else
            {
                suffixesById.Add(id, suffix);
            }

            foreach (string surface in surfaces)
            {
                suffixes.Add(surface.Replace('_', ' '), suffix);
            }
        }

        private class SuffixDictionaryLine
        {
            public string Labels;
            public string Id;
            public string Lex;
            public string Rules;
            public string Surfaces;
            public string Type;
        }
    }
}
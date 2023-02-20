using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using Nuve.Immutables;
using Nuve.Morphologic;
using Nuve.Morphologic.Structure;
using Nuve.Orthographic;

namespace Nuve.Reader
{
    internal class RootLexiconReader
    {
        private static readonly TraceSource Trace = new TraceSource("RootLexiconReader");
        private readonly Orthography _orthography;

        public RootLexiconReader(Orthography orthography)
        {
            _orthography = orthography;
        }

        public void AddEntries(DataSet ds, string tableName, Dictionary<string, Root> rootsById,
            MorphemeSurfaceDictionary<Root> rootsBySurface)
        {
            var data = ds.Tables[tableName].AsEnumerable();
            var entries = data.Select(x =>
                new RootLine
                {
                    Root = x.Field<string>("root").Trim(),
                    Surfaces = x.Field<string>("surfaces")?.Trim() ?? "",
                    Lex = x.Field<string>("lex").Trim(),
                    Active = x.Field<string>("active")?.Trim() ?? "",
                    Pos = x.Field<string>("Id")?.Trim(),
                    Labels = x.Field<string>("flags")?.Trim() ?? "",
                    Rules = x.Field<string>("rules")?.Trim() ?? ""
                });


            foreach (var entry in entries)
            {
                if (entry.Active == "")
                {
                    AddRoots(entry, rootsById, rootsBySurface);
                }
            }
        }


        private void AddRoots(RootLine entry, Dictionary<string, Root> rootsById,
            MorphemeSurfaceDictionary<Root> rootsBySurface)
        {
            var mainSurface = entry.Root;
            var surfaces = new List<string> {mainSurface};
            surfaces.AddRange(entry.Surfaces.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries));
            
            var lex = entry.Lex;
            var labels = entry.Labels.Split(new[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);
            var pos = entry.Pos;
            var rules = entry.Rules.Split(new[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries).ToList();

            if (Regex.IsMatch(lex, @"\p{L}[2-9]"))
            {
                rules.Add("DROP_ID_DIGIT");
            }

            if (string.IsNullOrEmpty(entry.Lex))
            {
                lex = mainSurface;
            }

            var root = new Root(pos, lex, 
                new ImmutableSortedSet<string>(surfaces), 
                new ImmutableHashSet<string>(labels),
                _orthography.GetRules(rules));

            var id = lex + "/" + pos;

            if (!rootsById.ContainsKey(id))
            {
                rootsById.Add(id, root);
            }
            else
            {
                Trace.TraceEvent(TraceEventType.Warning, 0, $"Duplicate root: {id}");
            }

            foreach (var lexicalForm in surfaces)
            {
                rootsBySurface.Add(lexicalForm, root);
            }
        }

        private class RootLine
        {
            public string Active;
            public string Pos;
            public string Labels;
            public string Lex;
            public string Root;
            public string Rules;
            public string Surfaces;
        }
    }
}
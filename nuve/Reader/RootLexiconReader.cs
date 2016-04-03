using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
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
                    Root = x.Field<string>("root"),
                    Surfaces = x.Field<string>("surfaces") ?? "",
                    Lex = x.Field<string>("lex"),
                    Active = x.Field<string>("active") ?? "",
                    Pos = x.Field<string>("Id"),
                    Labels = x.Field<string>("flags") ?? "",
                    Rules = x.Field<string>("rules") ?? ""
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
            var surfaces = entry.Surfaces.Split(new[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);
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

            Root root;
            if (pos == "KISALTMA" || pos == "ALINTI" || pos == "KISALTMA_NOKTALI" || pos == "HARF")
            {
                root = new Root(pos, lex, new HashSet<string>(labels), _orthography.GetRules(rules),
                    mainSurface);
            }
            else
            {
                root = new Root(pos, lex, new HashSet<string>(labels), _orthography.GetRules(rules));
            }

            var id = lex + "/" + pos;

            if (!rootsById.ContainsKey(id))
            {
                rootsById.Add(id, root);
            }
            else
            {
                Trace.TraceEvent(TraceEventType.Warning, 0, $"Duplicate root: {id}");
            }

            rootsBySurface.Add(mainSurface, root); // kelimeyi asıl yüzeyi ile ekliyoruz

            //eğer fazladan yüzeyi var ise onunla da ekliyoruz.
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
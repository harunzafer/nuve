using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
                    Id = x.Field<string>("Id"),
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
            var item = entry.Root;
            var surfaces = entry.Surfaces.Split(new[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);
            var lex = entry.Lex;
            var labels = entry.Labels.Split(new[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);
            var type = entry.Id;
            var rules = entry.Rules.Split(new[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);


            if (string.IsNullOrEmpty(entry.Lex))
            {
                lex = item;
            }

            Root root;
            if (type == "KISALTMA" || type == "ALINTI" || type == "KISALTMA_NOKTALI" || type == "HARF")
            {
                root = new Root(type, lex, new HashSet<string>(labels), _orthography.GetRules(rules),
                    item);
            }
            else
            {
                root = new Root(type, lex, new HashSet<string>(labels), _orthography.GetRules(rules));
            }

            var id = lex + "/" + type;

            if (!rootsById.ContainsKey(id))
            {
                rootsById.Add(id, root);
            }
            else
            {
                Trace.TraceEvent(TraceEventType.Warning, 0, $"Duplicate root: {id}");
            }

            rootsBySurface.Add(item, root); // kelimeyi asıl yüzeyi ile ekliyoruz

            //eğer fazladan yüzeyi var ise onunla da ekliyoruz.
            foreach (var lexicalForm in surfaces)
            {
                rootsBySurface.Add(lexicalForm, root);
            }
        }

        private class RootLine
        {
            public string Active;
            public string Id;
            public string Labels;
            public string Lex;
            public string Root;
            public string Rules;
            public string Surfaces;
        }
    }
}
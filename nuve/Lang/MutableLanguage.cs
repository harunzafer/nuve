using System.Collections.Generic;
using System.Linq;
using Nuve.Morphologic;
using Nuve.Morphologic.Structure;
using Nuve.Orthographic;

namespace Nuve.Lang
{
    public class MutableLanguage : Language
    {
        private MutableLanguage(string code,
            Orthography orthography,
            Morphotactics morphotactics,
            MorphemeContainer<Root> roots,
            MorphemeContainer<Suffix> suffixes)
            : base(code, orthography, morphotactics, roots, suffixes)
        {
        }

        public static MutableLanguage CopyFrom(Language language)
        {
            var roots = MorphemeContainer<Root>.CopyOf(language.Roots);

            return new MutableLanguage(language.Code,
                language.Orthography,
                language.Morphotactics,
                roots,
                language.Suffixes);
        }

        public bool TryAdd(RootEntry entry)
        {
            if (Roots.ById.ContainsKey(entry.Id))
            {
                return false;
            }

            Add(entry);

            return true;
        }

        private void Add(RootEntry entry)
        {
            var rules = Orthography.GetRules(entry.Rules);

            var root = new Root(entry.Pos, entry.Lex, entry.Labels, rules, entry.PrimarySurface);

            Roots.ById.Add(entry.Id, root);

            foreach (string surface in entry.Surfaces)
            {
                Roots.BySurface.Add(surface, root);
            }
        }
    }
}
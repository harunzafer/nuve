using System.Collections.Generic;

namespace Nuve.Lang
{
    public class RootEntry
    {
        public RootEntry(string lex, string pos,
            IEnumerable<string> surfaces,
            IEnumerable<string> labels,
            IEnumerable<string> rules)
        {
            Lex = lex;
            Pos = pos;
            Surfaces = new SortedSet<string>(surfaces);
            Labels = new HashSet<string>(labels);
            Rules = new HashSet<string>(rules);
            Id = lex + "/" + pos;
        }

        public string Lex { get; }
        public string Pos { get; }
        public string Id { get; }

        public ISet<string> Surfaces { get; }
        public ISet<string> Labels { get; }
        public ISet<string> Rules { get; }
    }
}
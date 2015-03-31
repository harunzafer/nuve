using System.Collections.Generic;

namespace Nuve.Morphologic
{
    internal class DictionaryGraph : IGraph<string>
    {
        private const string Delim = "+";
        private readonly Dictionary<string, Transition<string>> _dict = new Dictionary<string, Transition<string>>();

        public bool ContainsEdge(string source, string target)
        {
            string key = GetKey(source, target);
            return _dict.ContainsKey(key);
        }

        public bool TryGetEdge(string source, string target, out Transition<string> edge)
        {
            string key = GetKey(source, target);
            return _dict.TryGetValue(key, out edge);
        }

        public void AddEdge(Transition<string> edge)
        {
            string key = GetKey(edge.Source, edge.Target);

            if (!_dict.ContainsKey(key))
            {
                _dict[key] = edge;
            }
        }

        public bool TryGetOutEdges(string source, out IEnumerable<Transition<string>> outEdges)
        {
            var list = new List<Transition<string>>();
            outEdges = null;

            foreach (var d in _dict)
            {
                if (d.Key.StartsWith(source + Delim))
                {
                    list.Add(d.Value);
                }
            }

            if (list.Count > 0)
            {
                outEdges = list;
                return true;
            }

            return false;
        }

        public void AddEdges(IEnumerable<Transition<string>> edges)
        {
            foreach (var t in edges)
            {
                AddEdge(t);
            }
        }

        private string GetKey(string source, string target)
        {
            return source + Delim + target;
        }
    }
}
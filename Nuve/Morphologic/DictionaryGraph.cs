using System.Collections.Generic;
using System.Diagnostics;

namespace Nuve.Morphologic
{
    internal class DictionaryGraph : IGraph<string>
    {
        private const string Delim = "+";
        private readonly Dictionary<string, Transition<string>> _dict = new Dictionary<string, Transition<string>>();

        private readonly TraceSource _trace = new TraceSource("DictionaryGraph");

        public bool ContainsEdge(string source, string target)
        {
            var key = GetKey(source, target);
            return _dict.ContainsKey(key);
        }

        public bool TryGetEdge(string source, string target, out Transition<string> edge)
        {
            var key = GetKey(source, target);
            return _dict.TryGetValue(key, out edge);
        }

        public void AddEdge(Transition<string> edge)
        {
            var key = GetKey(edge.Source, edge.Target);

            if (!_dict.ContainsKey(key))
            {
                _dict[key] = edge;
                return;
            }

            _trace.TraceEvent(TraceEventType.Warning, 1, $"Duplicate key: {key}");
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nuve.Morphologic
{
    class DictionaryGraph: IGraph<string>
    {
        Dictionary<string, Transition<string>> dict = new Dictionary<string, Transition<string>>();
        public bool ContainsEdge(string source, string target)
        {
            return dict.ContainsKey(source + target);
        }

        public bool TryGetEdge(string source, string target, out Transition<string> edge)
        {
            return dict.TryGetValue(source + target, out edge);
        }

        public void AddEdge(Transition<string> edge)
        {
            string key = edge.Source + edge.Target;
            if (!dict.ContainsKey(key)){
                dict[key] = edge;
            }
        }

        public bool TryGetOutEdges(string source, out IEnumerable<Transition<string>> outEdges)
        {
            var list = new List<Transition<string>>();
            outEdges = null;

            foreach (var d in dict)
            {
                if (d.Key.StartsWith(source))
                {
                    list.Add(d.Value);
                }
            }

            if (list.Count > 0){
                outEdges = list;
                return true;
            }

            return false;
        }

        public void AddEdges(IEnumerable<Transition<string>> edges)
        {
            foreach (Transition<string> t in edges)
            {
                AddEdge(t);
            }
        }

    }
}

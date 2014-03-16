using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using QuickGraph;

[assembly: InternalsVisibleTo("Nuve.Test"), InternalsVisibleTo("Nuve.Gui")]

namespace Nuve
{
    public class SampleClass
    {
        public bool ReturnTrue()
        {
            return true;
        }

        internal bool InternalReturnTrue()
        {
            return true;
        }

        public static void Test()
        {
            var graph = new AdjacencyGraph<string, Edge<string>>(true);

            graph.AddVertex("A");
            graph.AddVertex("A"); graph.AddVertex("A"); graph.AddVertex("A");
            graph.AddVertex("B");
            graph.AddVertex("C");
            graph.AddVertex("D");
            graph.AddVertex("E");
            graph.AddVertex("F");
            graph.AddEdge(new Edge<string>("A", "B"));
            graph.AddEdge(new Edge<string>("A", "C"));
            graph.AddEdge(new Edge<string>("A", "D"));
            graph.AddEdge(new Edge<string>("D", "A"));
            graph.AddEdge(new Edge<string>("F", "A"));

            IEnumerable<Edge<string>> list;
            graph.TryGetOutEdges("A", out list);

            if(!graph.ContainsEdge("A", "B"))
            {
                graph.AddEdge(new Edge<string>("A", "B"));
                graph.AddEdge(new Edge<string>("A", "B"));
                graph.AddEdge(new Edge<string>("A", "B"));    
            }

            Edge<string> temp;
            graph.TryGetEdge("A", "B", out temp);

            graph.RemoveEdge(temp);

            foreach (var item in graph.Vertices)
	        {
                Console.WriteLine(item);
	        }
            
            foreach (Edge<string> edge in list)
            {
                
                graph.AddEdge(new Edge<string>("E", edge.Target));
                Console.WriteLine(edge);
            }

            

        }
    }
}

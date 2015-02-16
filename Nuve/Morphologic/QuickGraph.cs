using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickGraph;

namespace Nuve.Morphologic
{
    class QuickGraph<T> : IGraph<T>
    {
        AdjacencyGraph<T, CustomEdge<T>> graph = new AdjacencyGraph<T, CustomEdge<T>>(false);
        
        public bool ContainsEdge(T source, T target)
        {
            return graph.ContainsEdge(source,target);
        }

        public bool TryGetEdge(T source, T target, out Transition<T> edge)
        {
            CustomEdge<T> cEdge;
            if (graph.TryGetEdge(source, target, out cEdge)){
                edge = ToTransition(cEdge);
                return true;
            }
            edge = null;
            return false;
        }

        public void AddEdge(Transition<T> edge)
        {
            CustomEdge<T> cEdge = ToCustomEdge(edge);
            
            graph.AddVertex(cEdge.Source);
            graph.AddVertex(cEdge.Target);
            
            graph.AddEdge(cEdge);

        }

        public bool TryGetOutEdges(T source, out IEnumerable<Transition<T>> outEdges)
        {
            IEnumerable<CustomEdge<T>> cOutEdges;
            if (graph.TryGetOutEdges(source, out cOutEdges)){
                var list = new List<Transition<T>>();
                foreach(var cEdge in cOutEdges){
                    list.Add(ToTransition(cEdge));
                }
                outEdges = list;
                return true;

            }
            outEdges = null;
            return false;
        }
        public void AddEdges(IEnumerable<Transition<T>> edges)
        {
            
            foreach(Transition<T> t in edges){
                
                graph.AddVertex(t.Source);
                graph.AddVertex(t.Target);

                graph.AddEdge(ToCustomEdge(t));
            }
        }

        private Transition<T> ToTransition(CustomEdge<T> cEdge)
        {
            return new Transition<T>(cEdge.Source, cEdge.Target, cEdge.Conditions);
        }

        private CustomEdge<T> ToCustomEdge(Transition<T> t){
            return new CustomEdge<T>(t.Source, t.Target, t.Conditions);
        }

       
    }
}

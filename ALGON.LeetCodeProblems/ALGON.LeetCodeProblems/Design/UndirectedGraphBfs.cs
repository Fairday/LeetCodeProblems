using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.Design
{
    public class UndirectedGraphBfs : UndirectedGraphTraverse
    {
        public UndirectedGraphBfs(int startVertex, UndirectedGraph graph) : base(startVertex, graph)
        {
        }

        protected override void CreateTraverse(int startVertex, ICollection<int> items, bool[] marked, UndirectedGraph graph)
        {
            bfs(startVertex, items, marked, graph);
        }

        void bfs(int startVertex, ICollection<int> items, bool[] marked, UndirectedGraph graph) 
        {
            var queue = new Queue<int>();
            queue.Enqueue(startVertex);
            items.Add(startVertex);
            marked[startVertex] = true;

            while (queue.Count > 0) 
            {
                var vertex = queue.Dequeue();
                foreach (var w in graph.GetVertexAdjcency(vertex))
                {
                    if (!marked[w]) 
                    {
                        marked[w] = true;
                        items.Add(w);
                        _EdgeTo[w] = vertex;
                        queue.Enqueue(w);
                    }
                }
            }
        }
    }
}

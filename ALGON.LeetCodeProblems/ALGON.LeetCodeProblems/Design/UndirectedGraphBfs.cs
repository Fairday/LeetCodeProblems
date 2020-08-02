using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.Design
{
    public class UndirectedGraphBfs : UndirectedGraphTraverse
    {
        int _StartVertex;

        public UndirectedGraphBfs(int startVertex, UndirectedGraph graph) : base(graph)
        {
            _StartVertex = startVertex;

            CreateTraverse(_Items, new bool[graph.V], graph);
        }

        protected override void CreateTraverse(ICollection<int> items, bool[] marked, GraphBase graph)
        {
            bfs(_StartVertex, items, marked, graph);
        }

        void bfs(int startVertex, ICollection<int> items, bool[] marked, GraphBase graph) 
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

using System;
using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.Design
{
    public class ShortestPathToGraphVertex : UndirectedGraphTraverse
    {
        int[] _StartVertices;

        public ShortestPathToGraphVertex(UndirectedGraph graph, params int[] startVertices) : base(graph)
        {
            _StartVertices = startVertices;

            CreateTraverse(_Items, new bool[graph.V], graph);
        }

        public override IEnumerable<int> Traverse => throw new NotSupportedException("This operation isn't supported on this algorithm");

        protected override void CreateTraverse(ICollection<int> items, bool[] marked, GraphBase graph)
        {
            bfs(_StartVertices, items, marked, graph);
        }

        void bfs(int[] startVertices, ICollection<int> items, bool[] marked, GraphBase graph)
        {
            var queue = new Queue<int>();
            for (int i = 0; i < startVertices.Length; i++)
            {
                queue.Enqueue(startVertices[i]);
                marked[startVertices[i]] = true;
            }

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();
                foreach (var w in graph.GetVertexAdjcency(vertex))
                {
                    if (!marked[w])
                    {
                        marked[w] = true;
                        _EdgeTo[w] = vertex;
                        queue.Enqueue(w);
                    }
                }
            }
        }
    }
}

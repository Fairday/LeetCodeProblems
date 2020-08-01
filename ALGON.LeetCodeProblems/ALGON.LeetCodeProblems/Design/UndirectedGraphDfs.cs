using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.Design
{
    public class UndirectedGraphDfs : UndirectedGraphTraverse
    {
        public UndirectedGraphDfs(int startVertex, UndirectedGraph graph) : base(startVertex, graph)
        {
        }

        protected override void CreateTraverse(int startVertex, ICollection<int> items, bool[] marked, UndirectedGraph graph)
        {
            dfs(startVertex, items, marked, graph);
        }

        void dfs(int vertex, ICollection<int> items, bool[] marked, UndirectedGraph graph) 
        {
            if (marked[vertex])
                return;

            marked[vertex] = true;
            items.Add(vertex);

            foreach (var w in graph.GetVertexAdjcency(vertex))
            {
                if (!marked[w]) 
                {
                    dfs(w, items, marked, graph);
                    _EdgeTo[w] = vertex;
                }
            }
        }
    }
}

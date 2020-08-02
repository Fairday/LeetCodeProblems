using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.Design
{
    public class UndirectedGraphDfs : UndirectedGraphTraverse
    {
        int _StartVertex;

        public UndirectedGraphDfs(int startVertex, UndirectedGraph graph) : base(graph)
        {
            _StartVertex = startVertex;

            CreateTraverse(_Items, new bool[graph.V], graph);
        }

        protected override void CreateTraverse(ICollection<int> items, bool[] marked, GraphBase graph)
        {
            dfs(_StartVertex, items, marked, graph);
        }

        void dfs(int vertex, ICollection<int> items, bool[] marked, GraphBase graph) 
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

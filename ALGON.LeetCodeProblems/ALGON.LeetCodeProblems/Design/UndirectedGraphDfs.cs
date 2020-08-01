using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.Design
{
    public class UndirectedGraphDfs<T>
    {
        int[] _EdgeTo;
        UndirectedGraph _Graph;
        int _StartVertex;
        LinkedList<int> _Items;

        public UndirectedGraphDfs(int startVertex, UndirectedGraph graph)
        {
            _Graph = graph;
            _StartVertex = startVertex;
            _Items = new LinkedList<int>();
            _EdgeTo = new int[graph.V];
            for (int i = 0; i < graph.V; i++)
                _EdgeTo[i] = -1;
            var marked = new bool[graph.V];
            dfs(_StartVertex, _Items, marked);
        }

        public IEnumerable<int> GetPath(int endVertex) 
        {
            var ls = new List<int>();
            var curr = endVertex;
            while (curr > -1) 
            {
                ls.Add(curr);
                curr = _EdgeTo[curr];
            }
            return ls;
        }

        void dfs(int vertex, ICollection<int> items, bool[] marked) 
        {
            if (marked[vertex])
                return;

            marked[vertex] = true;
            items.Add(vertex);

            foreach (var w in _Graph.GetVertexAdjcency(vertex))
            {
                if (!marked[w]) 
                {
                    dfs(w, items, marked);
                    _EdgeTo[w] = vertex;
                }
            }
        }

        public IEnumerable<int> Traverse => _Items;
    }
}

using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.Design
{
    public abstract class UndirectedGraphTraverse
    {
        protected int _StartVertex;
        protected UndirectedGraph _Graph;
        protected LinkedList<int> _Items;
        protected int[] _EdgeTo;

        public UndirectedGraphTraverse(int startVertex, UndirectedGraph graph)
        {
            _StartVertex = startVertex;
            _Graph = graph;
            _Items = new LinkedList<int>();
            _EdgeTo = new int[graph.V];
            for (int i = 0; i < _EdgeTo.Length; i++)
                _EdgeTo[i] = -1;
            CreateTraverse(startVertex, _Items, new bool[graph.V], graph);
        }

        protected abstract void CreateTraverse(int startVertex, ICollection<int> items, bool[] marked, UndirectedGraph graph);

        public virtual IEnumerable<int> GetPath(int endVertex)
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

        public IEnumerable<int> Traverse => _Items;
    }
}

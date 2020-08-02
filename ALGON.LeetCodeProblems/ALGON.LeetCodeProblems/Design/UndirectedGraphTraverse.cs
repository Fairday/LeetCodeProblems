using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.Design
{
    public abstract class UndirectedGraphTraverse
    {
        protected GraphBase _Graph;
        protected LinkedList<int> _Items;
        protected int[] _EdgeTo;

        public UndirectedGraphTraverse(GraphBase graph)
        {
            _Graph = graph;
            _Items = new LinkedList<int>();
            _EdgeTo = new int[graph.V];
            for (int i = 0; i < _EdgeTo.Length; i++)
                _EdgeTo[i] = -1;
        }

        protected abstract void CreateTraverse(ICollection<int> items, bool[] marked, GraphBase graph);

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

        public virtual IEnumerable<int> Traverse => _Items;
    }
}

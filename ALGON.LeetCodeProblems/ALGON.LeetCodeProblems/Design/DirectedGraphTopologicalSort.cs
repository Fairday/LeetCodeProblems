using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.Design
{
    public abstract class DirectedGraphTopologicalSort
    {
        protected LinkedList<int> _Items;

        public DirectedGraphTopologicalSort(DirectedGraph graph)
        {
            _Items = new LinkedList<int>();
            Sort(graph, _Items);
        }

        protected abstract void Sort(DirectedGraph graph, ICollection<int> items);

        public IEnumerable<int> TopologicalSort => _Items;
    }
}

using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.Design
{
    public class TopologicalSortGraphViaBfsIndegrees
    {
        LinkedList<int> _Items;

        public TopologicalSortGraphViaBfsIndegrees(DirectedGraph graph)
        {
            _Items = new LinkedList<int>();
            Sort(graph, _Items);
        }

        void Sort(DirectedGraph graph, ICollection<int> items) 
        {
            var indegrees = GetIndegrees(graph);
            var queue = new Queue<int>();

            for (int i = 0; i < indegrees.Length; i++)
                if (indegrees[i] == 0) 
                {
                    queue.Enqueue(i);
                    indegrees[i] = -1;
                    items.Add(i);
                }

            while (queue.Count > 0) 
            {
                var vertex = queue.Dequeue();
                var adj = graph.GetVertexAdjcency(vertex);

                for (int i = 0; i < adj.Count; i++)
                {
                    indegrees[adj[i]]--;
                    if (indegrees[adj[i]] == 0) 
                    {
                        queue.Enqueue(adj[i]);
                        items.Add(adj[i]);
                    }
                }
            }
        }

        int[] GetIndegrees(DirectedGraph graph) 
        {
            var indegrees = new int[graph.V];

            for (int i = 0; i < graph.V; i++)
            {
                var adj = graph.GetVertexAdjcency(i);

                for (int j = 0; j < adj.Count; j++)
                    indegrees[adj[j]]++;
            }

            return indegrees;
        }

        public IEnumerable<int> TopologicalOrder => _Items;
    }
}

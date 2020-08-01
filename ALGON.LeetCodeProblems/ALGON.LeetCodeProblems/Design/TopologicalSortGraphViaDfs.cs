using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.Design
{
    public class TopologicalSortGraphViaDfs : DirectedGraphTopologicalSort
    {
        LinkedList<int> _Items;

        public TopologicalSortGraphViaDfs(DirectedGraph graph) : base(graph)
        {

        }

        public IEnumerable<int> TopologicalOrder => _Items;

        protected override void Sort(DirectedGraph graph, ICollection<int> items)
        {
            var order = new Stack<int>();
            var visited = new bool[graph.V];
            var recStack = new bool[graph.V];

            for (int i = 0; i < graph.V; i++) 
            {
                if (!dfs(i, graph, order, visited, recStack)) 
                {
                    items.Clear();
                    break;
                }
            }

            while (order.Count > 0)
                items.Add(order.Pop());
        }

        // Postorder Traversal
        bool dfs(int vertex, DirectedGraph graph, Stack<int> order, bool[] visited, bool[] recStack) 
        {
            if (visited[vertex])
                return true;

            visited[vertex] = true;
            recStack[vertex] = true;

            var adj = graph.GetVertexAdjcency(vertex);

            for (int i = 0; i < adj.Count; i++) 
            {
                if (!visited[adj[i]] && !dfs(adj[i], graph, order, visited, recStack))
                    return false;
                else if (recStack[adj[i]])
                    return false;
            }

            order.Push(vertex);
            recStack[vertex] = false;
            return true;
        }
    }
}

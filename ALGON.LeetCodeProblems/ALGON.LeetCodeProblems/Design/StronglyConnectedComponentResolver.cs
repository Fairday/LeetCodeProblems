using ALGON.LeetCodeProblems.Helpers;
using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.Design
{
    //Kosaraju's Algorithm - Strongly Connected Components
    public class StronglyConnectedComponentResolver
    {
        public StronglyConnectedComponentResolver(DirectedGraph graph)
        {
            StronglyConnectedComponents = new List<StronglyConnectedComponent>();
            Find(graph);
        }

        public IList<StronglyConnectedComponent> StronglyConnectedComponents { get; }

        void Find(DirectedGraph graph) 
        {
            //1. Postorder + stack
            //2. Reverse graph
            //3. Classic DFS

            //1. Postorder
            var stack = new Stack<int>();
            bool[] visited = new bool[graph.V];
            for (int i = 0; i < graph.V; i++)
                if (!visited[i]) 
                    PostOrder(i, stack, visited, graph);

            //2. Reverse graph
            var reversed = graph.Reverse();

            //3. Classic DFS
            visited.Fill(false);
            while (stack.Count > 0) 
            {
                var vertex = stack.Pop();

                if (!visited[vertex])
                {
                    var scc = new StronglyConnectedComponent();
                    FillStronglyConnectedComponent(vertex, visited, reversed, scc);
                    StronglyConnectedComponents.Add(scc);
                }
            }
        }

        void FillStronglyConnectedComponent(int vertex, bool[] visited, DirectedGraph graph, StronglyConnectedComponent scc)
        {
            visited[vertex] = true;
            scc.Vertices.Add(vertex);
            foreach (var adj in graph.GetVertexAdjcency(vertex))
                if (!visited[adj])
                    FillStronglyConnectedComponent(adj, visited, graph, scc);
        }

        void PostOrder(int vertex, Stack<int> stack, bool[] visited, DirectedGraph graph)
        {
            visited[vertex] = true;
            foreach (var adj in graph.GetVertexAdjcency(vertex))
                if (!visited[adj]) 
                    PostOrder(adj, stack, visited, graph);

            stack.Push(vertex);
        }
    }

    public class StronglyConnectedComponent 
    {
        public StronglyConnectedComponent()
        {
            Vertices = new List<int>();
        }

        public IList<int> Vertices { get; set; }
    }
}

using ALGON.LeetCodeProblems.Design;

namespace ALGON.LeetCodeProblemsRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new DirectedGraph(6);
            graph.AddEdge(0, 1);
            graph.AddEdge(4, 1);
            graph.AddEdge(1, 2);
            graph.AddEdge(4, 2);
            graph.AddEdge(4, 3);
            graph.AddEdge(3, 2);
            graph.AddEdge(2, 5);
            graph.AddEdge(3, 5);
            graph.AddEdge(0, 5);

            var bfs = new TopologicalSortGraphViaBfsIndegrees(graph);
            var items = bfs.TopologicalOrder;
        }
    }
}

using ALGON.LeetCodeProblems.Design;

namespace ALGON.LeetCodeProblemsRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new UndirectedGraph(6);
            graph.AddEdge(0, 1);
            graph.AddEdge(1, 2);
            graph.AddEdge(1, 4);
            graph.AddEdge(2, 4);
            graph.AddEdge(2, 3);
            graph.AddEdge(2, 5);
            graph.AddEdge(3, 5);
            graph.AddEdge(0, 5);

            var dfs = new UndirectedGraphBfs(2, graph);
            var traverse = dfs.Traverse;

            var p3 = dfs.GetPath(3);
            var p2 = dfs.GetPath(2);
            var p5 = dfs.GetPath(0);
        }
    }
}

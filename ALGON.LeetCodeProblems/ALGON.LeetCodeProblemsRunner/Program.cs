using ALGON.LeetCodeProblems.Design;

namespace ALGON.LeetCodeProblemsRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new DirectedGraph(9);
            graph.AddEdge(0, 1);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 0);
            graph.AddEdge(2, 4);
            graph.AddEdge(4, 5);
            graph.AddEdge(5, 6);
            graph.AddEdge(6, 4);
            graph.AddEdge(7, 6);
            graph.AddEdge(7, 8);

            var sccr = new StronglyConnectedComponentResolver(graph);
            var components = sccr.StronglyConnectedComponents;
        }
    }
}

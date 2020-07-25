using System.Collections.Generic;
using System.Linq;

namespace ALGON.LeetCodeProblems.Tree
{
    /*Given a directed, acyclic graph of N nodes.Find all possible paths from node 0 to node N-1, and return them in any order.

    The graph is given as follows:  the nodes are 0, 1, ..., graph.length - 1.  graph[i] is a list of all nodes j for which the edge (i, j) exists.


    Example:
    Input: [[1,2], [3], [3], []] 
    Output: [[0,1,3],[0,2,3]] 
    Explanation: The graph looks like this:
    0--->1
    |    |
    v v
    2--->3
    There are two paths: 0 -> 1 -> 3 and 0 -> 2 -> 3.
    Note:

    The number of nodes in the graph will be in the range [2, 15].
    You can print different paths in any order, but you should keep the order of nodes inside one path.*/
    public class Solution
    {
        public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
        {
            var paths = new List<IList<int>>();

            if (graph == null || graph.Length == 0)
                return paths;

            dfs(graph, paths, new List<int>(), 0);

            return paths;
        }

        void dfs(int[][] graph, IList<IList<int>> paths, IList<int> subpath, int vertex)
        {
            subpath.Add(vertex);

            if (vertex == graph.Length - 1)
            {
                paths.Add(subpath.ToList());
                return;
            }

            var adjusts = graph[vertex];

            for (int i = 0; i < adjusts.Length; i++)
            {
                dfs(graph, paths, subpath.ToList(), graph[vertex][i]);
            }
        }
    }
}

using System.Collections.Generic;
using System.Linq;

namespace ALGON.LeetCodeProblems.Backtracking
{
    //Given two integers n and k, return all possible combinations of k numbers out of 1 ... n.

    //Example:

    //Input: n = 4, k = 2
    //Output:
    //[
    //  [2,4],
    //  [3,4],
    //  [2,3],
    //  [1,2],
    //  [1,3],
    //  [1,4],
    //]
    public class Solution_77
    {
        // O(n * log(n))
        public IList<IList<int>> Combine(int n, int k)
        {
            var combinations = new List<IList<int>>();

            if (n == 0 || k == 0)
                return combinations;

            dfs(1, combinations, new List<int>(), n, k);

            return combinations;
        }

        void dfs(int start, List<IList<int>> combinations, List<int> current, int n, int k)
        {
            if (current.Count == k)
            {
                combinations.Add(current.ToList());
                return;
            }

            for (int i = start; i <= n; i++)
            {
                current.Add(i);
                dfs(i + 1, combinations, current, n, k);
                current.Remove(i);
            }
        }
    }
}

using System.Collections.Generic;
using System.Linq;

namespace Day11.RecursionBacktracking
{
    //Given two integers n and k, return all possible combinations of k numbers out of the range[1, n].

    //You may return the answer in any order.

    //Example 1:

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
    //Example 2:

    //Input: n = 1, k = 1
    //Output: [[1]]

    //Constraints:

    //1 <= n <= 20
    //1 <= k <= n
    public class Combinations_77
    {
        //TC: O(n!/(k-1)!
        //https://ru.wikipedia.org/wiki/%D0%A4%D0%B0%D0%BA%D1%82%D0%BE%D1%80%D0%B8%D0%B0%D0%BB
        //https://leetcode.com/problems/combinations/discuss/395558/Time-complexity-analysis-of-Backtracking-Java
        public IList<IList<int>> Combine(int n, int k)
        {
            var res = new List<IList<int>>();
            Dfs(res, new List<int>(), 1, n, k);
            return res;
        }

        private void Dfs(IList<IList<int>> res, IList<int> variant, int start, int n, int k)
        {
            if (variant.Count == k)
            {
                res.Add(variant);
                return;
            }

            for (int i = start; i <= n; i++)
            {
                variant.Add(i);
                Dfs(res, variant.ToList(), i + 1, n, k);
                variant.RemoveAt(variant.Count - 1);
            }
        }
    }
}
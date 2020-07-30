using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.PArray
{
    /*Find all possible combinations of k numbers that add up to a number n, given that only numbers from 1 to 9 can be used and each combination should be a unique set of numbers.

    Note:

    All numbers will be positive integers.
    The solution set must not contain duplicate combinations.
    Example 1:

    Input: k = 3, n = 7
    Output: [[1,2,4]]
    Example 2:

    Input: k = 3, n = 9
    Output: [[1,2,6], [1,3,5], [2,3,4]]*/
    public class Solution_216
    {
        public IList<IList<int>> CombinationSum3(int k, int n)
        {
            var results = new List<IList<int>>();
            Helper(results, 1, 0, new List<int>(), 0, n, k);
            return results;
        }

        void Helper(List<IList<int>> res, int start, int sum, List<int> subsum, int used, int target, int k)
        {
            if (target == sum)
            {
                if (used != k)
                    return;

                res.Add(new List<int>(subsum));
                return;
            }

            for (int i = start; i <= 9; i++)
            {
                if (sum + i <= target)
                {
                    subsum.Add(i);
                    Helper(res, i + 1, sum + i, subsum, used + 1, target, k);
                    subsum.RemoveAt(subsum.Count - 1);
                }
            }
        }
    }
}

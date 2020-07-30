using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.PArray
{
    /*Given a set of candidate numbers(candidates) (without duplicates) and a target number(target), find all unique combinations in candidates where the candidate numbers sums to target.

    The same repeated number may be chosen from candidates unlimited number of times.


    Note:


    All numbers (including target) will be positive integers.
    The solution set must not contain duplicate combinations.
    Example 1:


    Input: candidates = [2, 3, 6, 7], target = 7,
    A solution set is:
    [
      [7],
    [2,2,3]
    ]
    Example 2:

    Input: candidates = [2,3,5], target = 8,
    A solution set is:
    [
      [2,2,2,2],
      [2,3,3],
      [3,5]
    ]
 

    Constraints:

    1 <= candidates.length <= 30
    1 <= candidates[i] <= 200
    Each element of candidate is unique.
    1 <= target <= 500*/
    public class Solution_39
    {
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            var result = new List<IList<int>>();
            Helper(candidates, 0, 0, target, new List<int>(), result);
            return result;
        }

        void Helper(int[] candidates, int sum, int start, int target, List<int> subsum, IList<IList<int>> result)
        {
            if (sum == target)
            {
                result.Add(new List<int>(subsum));
                return;
            }

            for (int i = start; i < candidates.Length; i++)
            {
                if (sum + candidates[i] <= target)
                {
                    subsum.Add(candidates[i]);
                    Helper(candidates, sum + candidates[i], i, target, subsum, result);
                    subsum.RemoveAt(subsum.Count - 1);
                }
            }
        }
    }
}

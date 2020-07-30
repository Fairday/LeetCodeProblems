using System;
using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.PArray
{
    /*Given a collection of candidate numbers(candidates) and a target number(target), find all unique combinations in candidates where the candidate numbers sums to target.

    Each number in candidates may only be used once in the combination.


    Note:


    All numbers (including target) will be positive integers.
    The solution set must not contain duplicate combinations.
    Example 1:


    Input: candidates = [10, 1, 2, 7, 6, 1, 5], target = 8,
    A solution set is:
    [
      [1, 7],
    [1, 2, 5],
    [2, 6],
    [1, 1, 6]
    ]
    Example 2:

    Input: candidates = [2,5,2,1,2], target = 5,
    A solution set is:
    [
      [1,2,2],
      [5]
    ]*/
    public class Solution_40
    {
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            Array.Sort(candidates);
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
                if (i > start && candidates[i] == candidates[i - 1])
                    continue;
                if (sum + candidates[i] <= target)
                {
                    subsum.Add(candidates[i]);
                    Helper(candidates, sum + candidates[i], i + 1, target, subsum, result);
                    subsum.RemoveAt(subsum.Count - 1);
                }
            }
        }
    }
}

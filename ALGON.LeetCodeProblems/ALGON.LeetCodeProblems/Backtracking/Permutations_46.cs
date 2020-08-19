using System.Collections.Generic;
using System.Linq;

namespace ALGON.LeetCodeProblems.Backtracking
{
    public class Solution_46
    {
        public IList<IList<int>> Permute1(int[] nums)
        {
            var results = new List<IList<int>>();

            if (nums.Length == 0)
                return results;

            helper1(results, new HashSet<int>(), new List<int>(), nums);

            return results;
        }

        void helper1(IList<IList<int>> permutes, HashSet<int> visited, List<int> variant, int[] nums)
        {
            if (nums.Length == variant.Count)
            {
                permutes.Add(variant.ToList());
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                var num = nums[i];

                if (!visited.Contains(num))
                {
                    visited.Add(num);
                    variant.Add(num);
                    helper1(permutes, visited, variant, nums);
                    visited.Remove(num);
                    variant.Remove(num);
                }
            }
        }

        // O(n!)
        //https://medium.com/@davidmasse8/exploring-permutations-time-complexity-recursion-trees-and-e-31ab899e90e2#:~:text=Time%20complexity%20and%20number%20of,when%20N%20is%20large.
        public IList<IList<int>> Permute(int[] nums)
        {
            var results = new List<IList<int>>();

            if (nums.Length == 0)
                return results;

            helper(results, 0, nums.Length - 1, nums);

            return results;
        }

        void Swap(int[] arr, int i, int j)
        {
            var temp = arr[j];
            arr[j] = arr[i];
            arr[i] = temp;
        }

        void helper(IList<IList<int>> permutes, int start, int end, int[] nums)
        {
            if (start == end)
            {
                var variant = new List<int>(nums.Length);
                for (int i = 0; i < nums.Length; i++)
                    variant.Add(nums[i]);
                permutes.Add(variant);
            }

            for (int i = start; i <= end; i++)
            {
                Swap(nums, start, i);
                helper(permutes, start + 1, end, nums);
                Swap(nums, start, i);
            }
        }
    }
}

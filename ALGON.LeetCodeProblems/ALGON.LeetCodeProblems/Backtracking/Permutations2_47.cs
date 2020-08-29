using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.Backtracking
{
    //Given a collection of numbers that might contain duplicates, return all possible unique permutations.

    //Example:

    //Input: [1,1,2]
    //Output:
    //[
    //  [1,1,2],
    //  [1,2,1],
    //  [2,1,1]
    //]
    public class Solution_47
    {
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            var results = new List<IList<int>>();

            if (nums.Length == 0)
                return results;

            helper(results, 0, nums.Length - 1, nums);

            return results;
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

            var usedStarts = new HashSet<int>();

            for (int i = start; i <= end; i++)
            {
                Swap(nums, start, i);
                if (!usedStarts.Contains(nums[start]))
                {
                    helper(permutes, start + 1, end, nums);
                    usedStarts.Add(nums[start]);
                }
                Swap(nums, start, i);
            }
        }

        void Swap(int[] arr, int i, int j)
        {
            var temp = arr[j];
            arr[j] = arr[i];
            arr[i] = temp;
        }
    }
}

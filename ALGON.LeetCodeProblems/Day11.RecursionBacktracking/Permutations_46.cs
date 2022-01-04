using System.Collections.Generic;
using System.Linq;

namespace Day11.RecursionBacktracking
{
    //Given an array nums of distinct integers, return all the possible permutations.You can return the answer in any order.

    //Example 1:

    //Input: nums = [1, 2, 3]
    //Output: [[1,2,3], [1,3,2], [2,1,3], [2,3,1], [3,1,2], [3,2,1]]
    //Example 2:

    //Input: nums = [0,1]
    //    Output: [[0,1],[1,0]]
    //Example 3:

    //Input: nums = [1]
    //    Output: [[1]]
 
    //Constraints:

    //1 <= nums.length <= 6
    //-10 <= nums[i] <= 10
    //All the integers of nums are unique.
    public class Permutations_46
    {
        //TC: O(n!), where n = nums.Length
        //SC: O(n) - call stack depth
        public IList<IList<int>> Permute(int[] nums)
        {
            string s = "";
            s.Substring(0, 5);

            var res = new List<IList<int>>();
            Dfs(res, nums, 0);
            return res;
        }

        private void Dfs(IList<IList<int>> res, int[] nums, int start)
        {
            if (start == nums.Length)
                res.Add(nums.ToList());

            for (int i = start; i < nums.Length; i++)
            {
                Swap(nums, start, i);
                Dfs(res, nums, start + 1);
                Swap(nums, start, i);
            }
        }

        private void Swap(int[] nums, int i, int j)
        {
            var temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }
}
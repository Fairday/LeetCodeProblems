using System;

namespace ALGON.LeetCodeProblems.DynamicProgramming
{
    /*Given an integer array nums, find the contiguous subarray(containing at least one number) which has the largest sum and return its sum.

    Example:

    Input: [-2,1,-3,4,-1,2,1,-5,4],
    Output: 6
    Explanation: [4,-1,2,1] has the largest sum = 6.
    Follow up:


    If you have figured out the O(n) solution, try coding another solution using the divide and conquer approach, which is more subtle.*/
    public class Solution_53
    {
        public int MaxSubArray1(int[] nums)
        {
            var cur_sum = nums[0];
            var best_sum = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                cur_sum = Math.Max(nums[i], cur_sum + nums[i]);
                best_sum = Math.Max(best_sum, cur_sum);
            }

            return best_sum;
        }

        //Testing
        public int MaxSubArray(int[] nums)
        {
            var dp = new int[nums.Length];
            dp[0] = nums[0];
            var best_sum = dp[0];

            for (int i = 1; i < nums.Length; i++)
            {
                dp[i] = Math.Max(nums[i], nums[i] + dp[i - 1]);
                best_sum = Math.Max(best_sum, dp[i]);
            }

            return best_sum;
        }
    }
}

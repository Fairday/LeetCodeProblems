namespace ALGON.LeetCodeProblems.DynamicProgramming
{
    /*Given an integer array nums, find the sum of the elements between indices i and j(i ≤ j), inclusive.

    Example:
    Given nums = [-2, 0, 3, -5, 2, -1]

    sumRange(0, 2) -> 1
    sumRange(2, 5) -> -1
    sumRange(0, 5) -> -3
    Note:
    You may assume that the array does not change.
    There are many calls to sumRange function.*/
    public class NumArray
    {

        int[] dp;
        int[] nums;

        public NumArray(int[] nums)
        {
            this.nums = nums;
            dp = new int[nums.Length];

            if (nums.Length > 0)
            {
                dp[0] = nums[0];
                for (int i = 1; i < nums.Length; i++)
                {
                    dp[i] = nums[i] + dp[i - 1];
                }
            }
        }

        public int SumRange(int i, int j)
        {
            if (i == 0)
                return dp[j];
            else
                return dp[j] - dp[i] + nums[i];
        }
    }
}

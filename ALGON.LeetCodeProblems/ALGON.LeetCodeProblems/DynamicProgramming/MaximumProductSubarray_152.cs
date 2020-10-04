using System;
using System.Linq;

namespace ALGON.LeetCodeProblems.DynamicProgramming
{
    //Given an integer array nums, find the contiguous subarray within an array(containing at least one number) which has the largest product.

    //Example 1:

    //Input: [2,3,-2,4]
    //    Output: 6
    //Explanation: [2,3] has the largest product 6.
    //Example 2:

    //Input: [-2,0,-1]
    //    Output: 0
    //Explanation: The result cannot be 2, because[-2, -1] is not a subarray.
    public class Solution_152
    {
        //TC: O(N^2)
        //SC: O(1)
        public int MaxProduct1(int[] nums)
        {
            var max = Int32.MinValue;
            for (int i = 0; i < nums.Length; i++)
            {
                var product = 1;
                for (int j = i; j < nums.Length; j++)
                {
                    product *= nums[j];
                    max = Math.Max(product, max);
                }
            }
            return max;
        }

        //TC: O(N)
        //SC: O(1)
        public int MaxProduct(int[] nums)
        {
            var max_curr = nums[0];
            var min_curr = nums[0];
            var res = nums[0];

            foreach (var num in nums.Skip(1))
            {
                var c1 = max_curr * num;
                var c2 = min_curr * num;
                //maintaining maximum of current product here
                max_curr = Math.Max(num, Math.Max(c2, c1));
                //maintaining minimum of current product here (because we can have negative numbers in nums)
                min_curr = Math.Min(num, Math.Min(c1, c2));
                res = Math.Max(res, max_curr);
            }

            return res;
        }
    }
}

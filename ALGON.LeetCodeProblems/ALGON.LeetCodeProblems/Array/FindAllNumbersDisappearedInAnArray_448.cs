using System;
using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.Array
{
    //Given an array of integers where 1 ≤ a[i] ≤ n(n = size of array), some elements appear twice and others appear once.

    //Find all the elements of [1, n] inclusive that do not appear in this array.

    //Could you do it without extra space and in O(n) runtime? You may assume the returned list does not count as extra space.

    //Example:

    //Input:
    //[4,3,2,7,8,2,3,1]

    //Output:
    //[5,6]
    public class Solution_448
    {
        //TC: O(N)
        //SC: O(1)
        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            var len = nums.Length;
            //for (int i = 0; i < nums.Length; i++)
            //if (nums[i] > len)
            //nums[i] = -nums[i];

            var ans = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var num = nums[i];
                var index = Math.Abs(num) - 1;
                if (nums[index] > 0)
                    nums[index] = -nums[index];
            }

            for (int i = 0; i < len; i++)
                if (nums[i] > 0)
                    ans.Add(i + 1);

            return ans;
        }
    }
}

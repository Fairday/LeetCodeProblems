using System;
using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.PArray
{
    //Given a non-empty array of integers, return the third maximum number in this array.If it does not exist, return the maximum number.The time complexity must be in O(n).

    //Example 1:
    //Input: [3, 2, 1]

    //Output: 1

    //Explanation: The third maximum is 1.
    //Example 2:
    //Input: [1, 2]

    //Output: 2

    //Explanation: The third maximum does not exist, so the maximum (2) is returned instead.
    //Example 3:
    //Input: [2, 2, 3, 1]

    //    Output: 1

    //Explanation: Note that the third maximum here means the third maximum distinct number.
    //Both numbers with value 2 are both considered as second maximum.
    public class Solution_414
    {
        //TC: O(N)
        //SC: O(1)
        public int ThirdMax(int[] nums)
        {
            var hs = new HashSet<int>();
            var max1 = Int32.MinValue;
            var max2 = Int32.MinValue;
            var max3 = Int32.MinValue;

            foreach (var num in nums)
                hs.Add(num);

            foreach (var num in nums)
                if (num > max1)
                    max1 = num;

            if (hs.Count < 3)
                return max1;

            for (int i = 0; i < nums.Length; i++)
            {
                var num = nums[i];
                if (num > max2 && num < max1)
                {
                    max2 = num;
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                var num = nums[i];
                if (num > max3 && num < max2)
                {
                    max3 = num;
                }
            }

            return max3;
        }
    }
}

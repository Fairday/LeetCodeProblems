using System;
using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.PArray
{
    //Given an unsorted integer array, find the smallest missing positive integer.

    //Example 1:

    //Input: [1,2,0]
    //Output: 3
    //Example 2:

    //Input: [3,4,-1,1]
    //Output: 2
    //Example 3:

    //Input: [7,8,9,11,12]
    //Output: 1
    //Follow up:

    //Your algorithm should run in O(n) time and uses constant extra space.
    public class Solution_41
    {
        //TC: O(N)
        //SC: O(1)
        public int FirstMissingPositive(int[] nums)
        {
            var len = nums.Length;
            //Mark nums less or equal than zero to avoid them in future
            for (int i = 0; i < len; i++)
                if (nums[i] <= 0)
                    nums[i] = len + 1;

            for (int i = 0; i < len; i++)
            {
                //To index
                var index = Math.Abs(nums[i]) - 1;
                if (index < len)
                    //Mark that visited
                    nums[index] = -Math.Abs(nums[index]);
            }

            //finding first unvisited
            for (int i = 0; i < len; i++)
                if (nums[i] > 0)
                    return i + 1;

            //all visited
            return len + 1;
        }

        //TC: O(N)
        //SC: O(N)
        public int FirstMissingPositive1(int[] nums)
        {
            var min = Int32.MaxValue;
            var max = Int32.MinValue;

            var positives = new HashSet<int>();

            foreach (int num in nums)
            {
                if (num > max)
                    max = num;
                if (num < min && num > 0)
                    min = num;

                if (num > 0)
                    positives.Add(num);
            }

            //no positive
            //-1 -3 -2
            if (min == Int32.MaxValue)
                return 1;

            //min positive more than 1
            //7, 8, 9
            if (min - 1 > 0)
                return 1;

            //max and min closer
            //1,2
            if (max - min == 1)
                return max + 1;

            //max and min equals
            //1, 1
            if (max == min)
                return max + 1;

            //missing in [min, max]
            //1, 2, 4
            for (int i = min; i <= max; i++)
            {
                if (!positives.Contains(i))
                    return i;
            }

            //not missing
            //1, 2, 3
            return max + 1;
        }
    }
}

using System;
using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.PArray
{
    //Given an integer array of size n, find all elements that appear more than ⌊ n/3 ⌋ times.

    //Note: The algorithm should run in linear time and in O(1) space.

    //Example 1:

    //Input: [3,2,3]
    //    Output: [3]
    //    Example 2:

    //Input: [1,1,1,3,3,2,2,2]
    //    Output: [1,2]
    public class Solution_229
    {
        //TC: O(N)
        //SC: O(N)
        public IList<int> MajorityElement(int[] nums)
        {
            //We need to find numbers that occurs in nums more then (>) n/3 times.
            //It means that we can have only 1 or 2 numbers in answer
            //7/3 -> 2, numbers that occurs > 2 
            //8/3 -> 2, numbers that occurs > 2 
            //9/ 3 -> 3, numbers that occurs > 3
            //Algorithm
            //1. Find 2 most frequently numbers in array
            //2. Sum how many times they occurs in array
            //3. Check and push to answer

            var number1 = Int32.MinValue;
            var number2 = Int32.MinValue;
            var occurs1 = 0;
            var occurs2 = 0;

            //Example: 11133222
            //votes for 1 (1)
            //votes for 1 (2)
            //votes for 1 (3)
            //votes for 3 (1)
            //votes for 3 (2)
            //votes for 2 (2 votes of number 3 minus 1 = 1, 3 votes of number 1 minus 1 = 2)
            //votes for 2 (1 votes of number 3 minus 1 = 0, 2 votes of number 1 minus 1 = 1)
            //votes for 2 (1 because no votes for number 3)
            foreach (var num in nums)
            {
                //vote first number
                if (number1 == num)
                    occurs1++;
                //vote second number
                else if (number2 == num)
                    occurs2++;
                //no votes on first number
                else if (occurs1 == 0)
                {
                    number1 = num;
                    occurs1 = 1;
                }
                //no votes on second number
                else if (occurs2 == 0)
                {
                    number2 = num;
                    occurs2 = 1;
                }
                //votes for another number (no first and second)
                else
                {
                    occurs1--;
                    occurs2--;
                }
            }

            occurs1 = 0;
            occurs2 = 0;

            foreach (var num in nums)
            {
                if (num == number1)
                    occurs1++;
                else if (num == number2)
                    occurs2++;
            }

            var ans = new List<int>();
            if (occurs1 > nums.Length / 3)
                ans.Add(number1);
            if (occurs2 > nums.Length / 3)
                ans.Add(number2);
            return ans;
        }
    }
}

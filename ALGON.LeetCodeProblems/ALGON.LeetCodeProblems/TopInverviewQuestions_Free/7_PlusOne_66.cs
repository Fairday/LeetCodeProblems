using System;

namespace ALGON.LeetCodeProblems.TopInverviewQuestions_Free
{
    //Given a non-empty array of digits representing a non-negative integer, increment one to the integer.

    //The digits are stored such that the most significant digit is at the head of the list, and each element in the array contains a single digit.

    //You may assume the integer does not contain any leading zero, except the number 0 itself.

    //Example 1:

    //Input: digits = [1, 2, 3]
    //Output: [1,2,4]
    //Explanation: The array represents the integer 123.
    //Example 2:

    //Input: digits = [4, 3, 2, 1]
    //Output: [4,3,2,2]
    //Explanation: The array represents the integer 4321.
    //Example 3:

    //Input: digits = [0]
    //Output: [1]


    //Constraints:

    //1 <= digits.length <= 100
    //0 <= digits[i] <= 9
    public class Solution_66
    {
        //TC: O(N)
        //SC: O(N)
        public int[] PlusOne(int[] digits)
        {
            var l = digits.Length;

            var remaining = 0;
            digits[l - 1]++;
            for (int i = l - 1; i >= 0; i--)
            {
                var num = digits[i] + remaining;
                if (num > 9)
                {
                    remaining = 1;
                    num -= 10;
                }
                else
                    remaining = 0;

                digits[i] = num;
            }

            if (remaining == 1)
            {
                int[] newArray = new int[l + 1];
                newArray[0] = 1;
                Array.Copy(digits, 0, newArray, 1, l);
                return newArray;
            }

            return digits;
        }
    }
}

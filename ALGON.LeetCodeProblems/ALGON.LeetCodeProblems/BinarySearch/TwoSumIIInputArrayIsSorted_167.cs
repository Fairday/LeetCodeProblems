using System;

namespace ALGON.LeetCodeProblems.BinarySearch
{
    //Given an array of integers that is already sorted in ascending order, find two numbers such that they add up to a specific target number.

    //The function twoSum should return indices of the two numbers such that they add up to the target, where index1 must be less than index2.

    //Note:

    //Your returned answers (both index1 and index2) are not zero-based.
    //You may assume that each input would have exactly one solution and you may not use the same element twice.


    //Example 1:

    //Input: numbers = [2, 7, 11, 15], target = 9
    //Output: [1,2]
    //Explanation: The sum of 2 and 7 is 9. Therefore index1 = 1, index2 = 2.
    //Example 2:

    //Input: numbers = [2, 3, 4], target = 6
    //Output: [1,3]
    //Example 3:

    //Input: numbers = [-1, 0], target = -1
    //Output: [1,2]


    //Constraints:

    //2 <= nums.length <= 3 * 104
    //-1000 <= nums[i] <= 1000
    //nums is sorted in increasing order.
    //-1000 <= target <= 1000
    public class Solution_167
    {
        //TC: O(n Logn)
        //SC: O(1)
        public int[] TwoSum1(int[] numbers, int target)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                var lo = i + 1;
                var hi = numbers.Length - 1;
                var num1 = numbers[i];
                var find = target - num1;

                while (lo <= hi)
                {
                    var mid = lo + (hi - lo) / 2;
                    if (numbers[mid] == find)
                        return new int[] { i + 1, mid + 1 };
                    else if (numbers[mid] > find)
                        hi = mid - 1;
                    else
                        lo = mid + 1;
                }
            }

            throw new Exception("Bad input, You may assume that each input would have exactly one solution and you may not use the same element twice.");
        }

        //TC: O(N)
        //SC: O(1)
        public int[] TwoSum(int[] numbers, int target)
        {
            var lo = 0;
            var hi = numbers.Length - 1;

            while (lo < hi)
            {
                var sum = numbers[lo] + numbers[hi];
                if (sum == target)
                    return new int[] { lo + 1, hi + 1 };
                else if (sum > target)
                    hi--;
                else
                    lo++;
            }

            throw new Exception("Bad input, You may assume that each input would have exactly one solution and you may not use the same element twice.");
        }
    }
}

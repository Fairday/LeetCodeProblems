using System;

namespace ALGON.LeetCodeProblems.BinarySearch
{
    /*Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand.

    (i.e., [0,1,2,4,5,6,7] might become  [4,5,6,7,0,1,2]).

    Find the minimum element.

    You may assume no duplicate exists in the array.

    Example 1:

    Input: [3,4,5,1,2]
    Output: 1
    Example 2:

    Input: [4,5,6,7,0,1,2]
    Output: 0*/
    public class Solution_153
    {
        // O(N)
        public int FindMin1(int[] nums)
        {
            if (nums.Length == 0)
                return -1;
            else if (nums.Length == 1)
                return nums[0];

            var min = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                min = Math.Min(min, nums[i]);
                var diff = nums[i] - nums[i - 1];
                if (diff < 0)
                    return nums[i];
            }

            return min;
        }

        // O(logN) - Binary Search
        public int FindMin(int[] nums)
        {
            if (nums.Length == 1)
                return nums[0];

            var left = 0;
            var right = nums.Length - 1;

            if (nums[right] > nums[left])
                return nums[0];
            else
            {
                while (left <= right)
                {
                    var mid = left + (right - left) / 2;

                    if (nums[mid] > nums[mid + 1])
                        return nums[mid + 1];

                    if (nums[mid] < nums[mid - 1])
                        return nums[mid];

                    if (nums[mid] > nums[0])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
            }

            return -1;
        }
    }
}

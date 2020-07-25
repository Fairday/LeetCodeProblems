﻿namespace ALGON.LeetCodeProblems.BinarySearch
{
    /*Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand.

    (i.e., [0,1,2,4,5,6,7] might become  [4,5,6,7,0,1,2]).

    Find the minimum element.

    The array may contain duplicates.

    Example 1:

    Input: [1,3,5]
    Output: 1
    Example 2:

    Input: [2,2,2,0,1]
    Output: 0
    Note:

    This is a follow up problem to Find Minimum in Rotated Sorted Array.
    Would allow duplicates affect the run-time complexity? How and why?*/
    public class Solution_154
    {
        public int FindMin(int[] nums)
        {
            if (nums.Length == 1)
                return nums[0];

            var left = 0;
            var right = nums.Length - 1;

            while (left <= right)
            {
                while (left < right && nums[left] == nums[right])
                    left++;

                if (nums[left] <= nums[right])
                    return nums[left];

                var mid = (right + left) / 2;

                if (nums[mid] >= nums[left])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            return -1;
        }
    }
}

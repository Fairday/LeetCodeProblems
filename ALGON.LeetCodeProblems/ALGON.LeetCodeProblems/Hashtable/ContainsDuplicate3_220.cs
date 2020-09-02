using System;
using System.Collections.Generic;
using System.Linq;

namespace ALGON.LeetCodeProblems.Hashtable
{
    //Given an array of integers, find out whether there are two distinct indices i and j in the array such that the absolute difference between nums[i] and nums[j] is at most t and the absolute difference between i and j is at most k.

    //Example 1:

    //Input: nums = [1,2,3,1], k = 3, t = 0
    //Output: true
    //Example 2:

    //Input: nums = [1,0,1,1], k = 1, t = 2
    //Output: true
    //Example 3:

    //Input: nums = [1,5,9,1,5,9], k = 2, t = 3
    //Output: false
    public class Solution_220
    {
        //TC: O(n^2)
        //SC: O(1)
        public bool ContainsNearbyAlmostDuplicate1(int[] nums, int k, int t)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (Math.Abs((double)nums[i] - (double)nums[j]) <= (double)t && Math.Abs(i - j) <= k)
                        return true;
                }
            }
            return false;
        }

        //TC: O(n logn)
        //SC: O(n)
        public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t)
        {
            if (k < 0 || t < 0)
                return false;

            var sortedSet = new SortedSet<long>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (sortedSet.GetViewBetween((long)nums[i] - t, (long)nums[i] + t).Any())
                    return true;

                sortedSet.Add(nums[i]);

                if (i >= k)
                    sortedSet.Remove(nums[i - k]);
            }

            return false;
        }
    }
}

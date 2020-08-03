using System;
using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.Hashtable
{
    /*Given an array of integers and an integer k, find out whether there are two distinct indices i and j in the array such that nums[i] = nums[j] and the absolute difference between i and j is at most k.

    Example 1:

    Input: nums = [1,2,3,1], k = 3
    Output: true
    Example 2:

    Input: nums = [1,0,1,1], k = 1
    Output: true
    Example 3:

    Input: nums = [1,2,3,1,2,3], k = 2
    Output: false*/
    public class Solution_219
    {
        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            var map = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (map.ContainsKey(nums[i]))
                {
                    var diff = Math.Abs(map[nums[i]] - i);
                    if (diff <= k)
                        return true;
                    else if (diff > k)
                        map[nums[i]] = i;
                }
                else
                {
                    map[nums[i]] = i;
                }
            }

            return false;
        }
    }
}

using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.PArray
{
    //Given two arrays, write a function to compute their intersection.

    //Example 1:

    //Input: nums1 = [1,2,2,1], nums2 = [2,2]
    //    Output: [2]
    //    Example 2:

    //Input: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
    //    Output: [9,4]
    //    Note:

    //Each element in the result must be unique.
    //The result can be in any order.
    public class Solution_349
    {
        // TC: O(N)
        // SC: O(N)
        //https://leetcode.com/problems/intersection-of-two-arrays/solution/, if we need O(1) SC: Sort array
        //And use two pointers and skip duplicates in each array.
        //1 1 2 2 3
        //2 2 3
        //1 1 [2] 2 3
        //[2] 2 3 -> add(2)
        //1 1 2 2 [3]
        //2 2 [3] -> add(3)
        public int[] Intersection(int[] nums1, int[] nums2)
        {
            var nums1Map = new Dictionary<int, int>();

            foreach (var num in nums1)
            {
                if (!nums1Map.ContainsKey(num))
                    nums1Map[num] = 1;
            }

            var intersection = new List<int>();

            foreach (var num in nums2)
            {
                if (nums1Map.ContainsKey(num) && nums1Map[num] > 0)
                {
                    nums1Map[num]--;
                    intersection.Add(num);
                }
            }

            return intersection.ToArray();
        }
    }
}

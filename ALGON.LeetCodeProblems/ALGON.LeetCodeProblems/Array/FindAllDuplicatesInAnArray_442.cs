using System;
using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.PArray
{
    /*Given an array of integers, 1 ≤ a[i] ≤ n(n = size of array), some elements appear twice and others appear once.

    Find all the elements that appear twice in this array.

    Could you do it without extra space and in O(n) runtime?


    Example:
    Input:
    [4,3,2,7,8,2,3,1]

    Output:
    [2,3]*/
    public class Solution_442
    {
        //O(N) + O(N) space
        public IList<int> FindDuplicates1(int[] nums)
        {
            var duplicates = new List<int>();
            var hash = new HashSet<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (!hash.Add(nums[i]))
                    duplicates.Add(nums[i]);
            }

            return duplicates;
        }

        //O(N) + O(1) space
        //https://leetcode.com/problems/find-all-duplicates-in-an-array/discuss/775738/Python-2-solutions-with-O(n)-timeO(1)-space-explained
        public IList<int> FindDuplicates(int[] nums)
        {
            var duplicates = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var index = Math.Abs(nums[i]) - 1;
                if (nums[index] < 0)
                    duplicates.Add(Math.Abs(nums[i]));
                else
                    nums[index] = -nums[index];
            }

            return duplicates;
        }
    }
}

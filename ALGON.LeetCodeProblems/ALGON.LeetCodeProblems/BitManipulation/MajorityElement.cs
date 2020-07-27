namespace ALGON.LeetCodeProblems.BitManipulation
{
    /*Given an array of size n, find the majority element.The majority element is the element that appears more than ⌊ n/2 ⌋ times.

    You may assume that the array is non-empty and the majority element always exist in the array.

    Example 1:

    Input: [3,2,3]
    Output: 3
    Example 2:


    Input: [2,2,1,1,1,2,2]
    Output: 2*/
    public class Solution_169
    {
        // Time complexity O(n), space complexity O(1).
        // Different implementation.
        // https://discuss.leetcode.com/topic/28601/java-solutions-sorting-hashmap-moore-voting-bit-manipulation
        // https://en.wikipedia.org/wiki/Boyer%E2%80%93Moore_majority_vote_algorithm - Boyer–Moore majority vote algorithm
        public int MajorityElement(int[] nums)
        {
            var count = 0;
            var candidate = nums[0];
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == candidate)
                    count++;
                else
                {
                    if (count == 0)
                        candidate = nums[i];
                    else
                        count--;
                }
            }
            return candidate;
        }
    }
}

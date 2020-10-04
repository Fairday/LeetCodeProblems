using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.PArray
{
    //Given an array of integers and an integer k, you need to find the total number of continuous subarrays whose sum equals to k.

    //Example 1:

    //Input:nums = [1,1,1], k = 2
    //Output: 2


    //Constraints:

    //The length of the array is in range[1, 20, 000].
    //The range of numbers in the array is [-1000, 1000] and the range of the integer k is [-1e7, 1e7].
    public class Solution_560
    {
        //TC: O(N^2)
        //SC: O(1)
        public int SubarraySum1(int[] nums, int k)
        {
            var ans = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                var sum = 0;
                for (int j = i; j < nums.Length; j++)
                {
                    sum += nums[j];
                    if (sum == k)
                        ans++;
                }
            }
            return ans;
        }

        //TC: O(N)
        //SC: O(N)
        //https://leetcode.com/problems/subarray-sum-equals-k/solution/
        public int SubarraySum(int[] nums, int k)
        {
            var map = new Dictionary<int, int>();
            var ans = 0;
            var sum = 0;
            map[0] = 1;
            //moving sum approach
            //cumulative sum
            foreach (var num in nums)
            {
                sum += num;
                if (map.ContainsKey(sum - k))
                    ans += map[sum - k];
                if (map.ContainsKey(sum))
                    map[sum]++;
                else
                    map[sum] = 1;
            }
            return ans;
        }
    }
}

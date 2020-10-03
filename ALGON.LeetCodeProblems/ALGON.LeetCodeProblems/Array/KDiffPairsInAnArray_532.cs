using System;
using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.PArray
{
    //Given an array of integers nums and an integer k, return the number of unique k-diff pairs in the array.

    //A k-diff pair is an integer pair (nums[i], nums[j]), where the following are true:

    //0 <= i, j<nums.length
    //i != j
    //a <= b
    //b - a == k

    //Example 1:

    //Input: nums = [3, 1, 4, 1, 5], k = 2
    //Output: 2
    //Explanation: There are two 2-diff pairs in the array, (1, 3) and(3, 5).
    //Although we have two 1s in the input, we should only return the number of unique pairs.
    //Example 2:

    //Input: nums = [1,2,3,4,5], k = 1
    //Output: 4
    //Explanation: There are four 1-diff pairs in the array, (1, 2), (2, 3), (3, 4) and(4, 5).
    //Example 3:

    //Input: nums = [1,3,1,5,4], k = 0
    //Output: 1
    //Explanation: There is one 0-diff pair in the array, (1, 1).
    //Example 4:

    //Input: nums = [1,2,4,4,3,3,0,9,2,3], k = 3
    //Output: 2
    //Example 5:

    //Input: nums = [-1,-2,-3], k = 1
    //Output: 2
 

    //Constraints:

    //1 <= nums.length <= 104
    //-107 <= nums[i] <= 107
    //0 <= k <= 107
    public class Solution_532
    {
        //TC: O(2N) -> O(N)
        //SC: O(N^2)
        public int FindPairs1(int[] nums, int k)
        {
            if (nums == null || nums.Length <= 1)
                return 0;

            var pairs = new Dictionary<int, HashSet<int>>();
            var ans = 0;

            for (int i = 0; i < nums.Length - 1; i++)
            {
                var baseNum = nums[i];

                for (int j = i + 1; j < nums.Length; j++)
                {
                    var targetNum = nums[j];

                    if (Math.Abs(baseNum - targetNum) == k)
                    {
                        //this pair already used
                        if (pairs.ContainsKey(baseNum) && pairs[baseNum].Contains(targetNum))
                            continue;
                        if (!pairs.ContainsKey(baseNum))
                            pairs[baseNum] = new HashSet<int>();
                        if (!pairs.ContainsKey(targetNum))
                            pairs[targetNum] = new HashSet<int>();
                        pairs[baseNum].Add(targetNum);
                        pairs[targetNum].Add(baseNum);
                        ans++;
                    }
                }
            }

            return ans;
        }

        //TC: O(N)
        //SC: O(N)
        public int FindPairs(int[] nums, int k)
        {
            var map = new Dictionary<int, int>();
            //Find all unique keys with their repetitions
            //3 1 4 3 5 1
            //3 - 2
            //1 - 2
            //4 - 1
            //5 - 1
            foreach (var num in nums)
            {
                if (map.ContainsKey(num))
                    map[num]++;
                else
                    map[num] = 1;
            }
            var pairs = 0;
            foreach (var key in map.Keys)
            {
                //if k == 0, then we need to find key pair as self
                if (k > 0 && map.ContainsKey(key + k) || k == 0 && map[key] > 1)
                    pairs++;
            }
            return pairs;
        }
    }
}

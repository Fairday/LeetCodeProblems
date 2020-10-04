namespace ALGON.LeetCodeProblems.BinarySearch
{
    //Given a sorted(in ascending order) integer array nums of n elements and a target value, write a function to search target in nums.If target exists, then return its index, otherwise return -1.

    //Example 1:

    //Input: nums = [-1,0,3,5,9,12], target = 9
    //Output: 4
    //Explanation: 9 exists in nums and its index is 4

    //Example 2:

    //Input: nums = [-1,0,3,5,9,12], target = 2
    //Output: -1
    //Explanation: 2 does not exist in nums so return -1
 
    //Note:

    //You may assume that all elements in nums are unique.
    //n will be in the range[1, 10000].
    //The value of each element in nums will be in the range[-9999, 9999].
    public class Solution_704
    {
        //TC: O(logn)
        //SC: O(1)
        public int Search(int[] nums, int target)
        {
            var lo = 0;
            var hi = nums.Length - 1;
            while (lo <= hi)
            {
                var mid = lo + (hi - lo) / 2;
                var num = nums[mid];
                if (num == target)
                    return mid;
                else if (num > target)
                    hi = mid - 1;
                else
                    lo = mid + 1;
            }

            return -1;
        }
    }
}

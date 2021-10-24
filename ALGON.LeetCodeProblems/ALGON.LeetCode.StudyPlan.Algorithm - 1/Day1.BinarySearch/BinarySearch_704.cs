using System;

namespace Day1.BinarySearch
{
    //Given an array of integers nums which is sorted in ascending order, and an integer target, write a function to search target in nums. If target exists, then return its index. Otherwise, return -1.

    //You must write an algorithm with O(log n) runtime complexity.

    //Example 1:

    //Input: nums = [-1,0,3,5,9,12], target = 9
    //Output: 4
    //Explanation: 9 exists in nums and its index is 4
    //Example 2:

    //Input: nums = [-1,0,3,5,9,12], target = 2
    //Output: -1
    //Explanation: 2 does not exist in nums so return -1

    //Constraints:

    //1 <= nums.length <= 104
    //-104 < nums[i], target < 104
    //All the integers in nums are unique.
    //nums is sorted in ascending order.
    public class BinarySearch_704
    {
        //TC: O(log N)
        //SC: O(1)
        public int Search(int[] nums, int target) 
        {
            if (nums == null || nums.Length == 0)
                return -1;
            int lo = 0;
            int hi = nums.Length - 1;
            while (lo <= hi) 
            {
                int mid = lo + (hi - lo) / 2;
                int num = nums[mid];
                if (target == num)
                    return num;
                else if (target > num)
                    lo = mid + 1;
                else
                    hi = mid - 1;
            }

            return -1;
        }

        //TC: O(log N)
        //SC: O(1)
        public int Search_1(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
                return -1;
            var index = Array.BinarySearch(nums, target);
            //https://stackoverflow.com/questions/40972974/c-sharp-binary-search-returns-negative-indexes
            return index < 0 ? -1 : index;
        }
    }
}
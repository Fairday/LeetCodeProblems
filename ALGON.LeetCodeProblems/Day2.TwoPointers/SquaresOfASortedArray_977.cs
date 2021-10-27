using System;

namespace Day2.TwoPointers
{
    //Given an integer array nums sorted in non-decreasing order, return an array of the squares of each number sorted in non-decreasing order.
    //Example 1:

    //Input: nums = [-4,-1,0,3,10]
    //Output: [0,1,9,16,100]
    //Explanation: After squaring, the array becomes [16,1,0,9,100].
    //After sorting, it becomes [0,1,9,16,100].
    //Example 2:

    //Input: nums = [-7,-3,2,3,11]
    //Output: [4,9,9,49,121]
 
    //Constraints:

    //1 <= nums.length <= 104
    //-104 <= nums[i] <= 104
    //nums is sorted in non-decreasing order.
 
    //Follow up: Squaring each element and sorting the new array is very trivial, could you find an O(n) solution using a different approach?
    public sealed class SquaresOfASortedArray_977
    {    //TC: O(N log N)
         //SC: O(N log N)
        public int[] SortedSquares_NaiveApproach(int[] nums)
        {
            if (nums == null)
                throw new Exception("nums cannot be null");

            for (int i = 0; i < nums.Length; i++)
                nums[i] = nums[i] * nums[i];

            Array.Sort(nums);

            return nums;
        }

        //TC: O(N)
        //SC: O(N)
        public int[] SortedSquares(int[] nums)
        {
            if (nums == null)
                throw new Exception("nums cannt ne null");

            int left = 0;
            int right = nums.Length - 1;
            int[] result = new int[nums.Length];

            for (int p = right; p >= 0; p--)
            {
                if (Math.Abs(nums[left]) > Math.Abs(nums[right]))
                {
                    result[p] = nums[left] * nums[left];
                    left++;
                }
                else
                {
                    result[p] = nums[right] * nums[right];
                    right--;
                }
            }

            return result;
        }
    }
}
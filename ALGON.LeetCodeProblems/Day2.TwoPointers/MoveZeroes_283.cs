using System;

namespace Day2.TwoPointers
{
    //Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.
    //Note that you must do this in-place without making a copy of the array.

    //Example 1:

    //Input: nums = [0,1,0,3,12]
    //Output: [1,3,12,0,0]
    //Example 2:

    //Input: nums = [0]
    //Output: [0]

    //Constraints:

    //1 <= nums.length <= 104
    //-231 <= nums[i] <= 231 - 1

    //Follow up: Could you minimize the total number of operations done?
    public class MoveZeroes_283
    {
        //TC: O(N)
        //SC: O(N)
        public void MoveZeroes_NaiveApproach(int[] nums)
        {
            //You should use additional array with non zero numbers and insert them from start
        }

        //TC: O(N)
        //SC: O(1)
        public void MoveZeroes(int[] nums)
        {
            if (nums == null)
                throw new Exception("nums cannot be null");

            if (nums.Length < 2)
                return;

            int i = 0;
            int j = 0;

            while (j < nums.Length)
            {
                if (nums[j] == 0)
                {
                    j++;
                }
                else
                {
                    Swap(nums, i, j);
                    i++;
                    j++;
                }
            }
        }

        private void Swap(int[] nums, int i, int j)
        {
            int tmp = nums[i];
            nums[i] = nums[j];
            nums[j] = tmp;
        }
    }
}
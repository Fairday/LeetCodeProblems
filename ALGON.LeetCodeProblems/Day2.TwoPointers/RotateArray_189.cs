using System;

namespace Day2.TwoPointers
{
    //{Given an array, rotate the array to the right by k steps, where k is non-negative.

    //Example 1:

    //Input: nums = [1,2,3,4,5,6,7], k = 3
    //Output: [5,6,7,1,2,3,4]
    //Explanation:
    //rotate 1 steps to the right: [7,1,2,3,4,5,6]
    //rotate 2 steps to the right: [6,7,1,2,3,4,5]
    //rotate 3 steps to the right: [5,6,7,1,2,3,4]
    //Example 2:

    //Input: nums = [-1,-100,3,99], k = 2
    //Output: [3,99,-1,-100]
    //Explanation: 
    //rotate 1 steps to the right: [99,-1,-100,3]
    //rotate 2 steps to the right: [3,99,-1,-100]
 
    //Constraints:

    //1 <= nums.length <= 105
    //-231 <= nums[i] <= 231 - 1
    //0 <= k <= 105

    //Follow up:

    //Try to come up with as many solutions as you can. There are at least three different ways to solve this problem.
    //Could you do it in-place with O(1) extra space?
    public class RotateArray_189
    {
        //TC: O(N^2)
        //SC: O(1)
        //Time Limit Exceeded
        public void Rotate_NaiveApproach(int[] nums, int k)
        {
            if (nums == null)
                throw new Exception("nums cannot be null");

            if (k == 0)
                return;

            if (nums.Length < 2)
                return;

            for (int i = 0; i < k; i++)
            {
                var last = nums[nums.Length - 1];
                for (int j = 0; j < nums.Length - 1; j++)
                {
                    nums[nums.Length - 1 - j] = nums[nums.Length - 2 - j];
                }
                nums[0] = last;
            }
        }

        //TC: O(N)
        //SC: O(N)
        public void Rotate_NaiveApproach_2(int[] nums, int k)
        {
            if (nums == null)
                throw new Exception("nums cannot be null");

            if (k == 0)
                return;

            if (nums.Length < 2)
                return;

            int[] buffer = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                int newPos = (i + k) % nums.Length;
                buffer[newPos] = nums[i];
            }

            for (int i = 0; i < buffer.Length; i++)
                nums[i] = buffer[i];
        }

        //TC: O(N)
        //SC: O(1)
        public void Rotate(int[] nums, int k)
        {
            if (nums == null)
                throw new Exception("nums cannot be null");

            if (k == 0)
                return;

            if (nums.Length < 2)
                return;

            k = k % nums.Length;
            Reverse(nums, 0, nums.Length - k - 1);
            Reverse(nums, nums.Length - k, nums.Length - 1);
            Reverse(nums, 0, nums.Length - 1);


            void Reverse(int[] arr, int lo, int hi)
            {
                int tmp;
                while (lo < hi)
                {
                    tmp = arr[lo];
                    arr[lo] = nums[hi];
                    arr[hi] = tmp;
                    lo++;
                    hi--;
                }
            }
        }
    }
}
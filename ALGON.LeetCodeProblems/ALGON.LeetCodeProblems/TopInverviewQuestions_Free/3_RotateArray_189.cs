namespace ALGON.LeetCodeProblems.TopInverviewQuestions_Free
{
    //Given an array, rotate the array to the right by k steps, where k is non-negative.

    //Follow up:

    //Try to come up as many solutions as you can, there are at least 3 different ways to solve this problem.
    //Could you do it in-place with O(1) extra space?


    //Example 1:

    //Input: nums = [1,2,3,4,5,6,7], k = 3
    //Output: [5,6,7,1,2,3,4]
    //    Explanation:
    //rotate 1 steps to the right: [7,1,2,3,4,5,6]
    //    rotate 2 steps to the right: [6,7,1,2,3,4,5]
    //    rotate 3 steps to the right: [5,6,7,1,2,3,4]
    //    Example 2:

    //Input: nums = [-1,-100,3,99], k = 2
    //Output: [3,99,-1,-100]
    //    Explanation: 
    //rotate 1 steps to the right: [99,-1,-100,3]
    //    rotate 2 steps to the right: [3,99,-1,-100]


    //    Constraints:

    //1 <= nums.length <= 2 * 10^4
    //It's guaranteed that nums[i] fits in a 32 bit-signed integer.
    //k >= 0
    public class Solution_189
    {
        //TC: O(n^2)
        //SC: O(1)
        public void Rotate1(int[] nums, int k)
        {
            k %= nums.Length;
            int temp, previous = 0;
            for (int i = 0; i < k; i++)
            {
                previous = nums[nums.Length - 1];
                for (int j = 0; j < nums.Length; j++)
                {
                    temp = nums[j];
                    nums[j] = previous;
                    previous = temp;
                }
            }
        }

        //TC: O(n)
        //SC: O(n)
        public void Rotate2(int[] nums, int k)
        {
            int[] a = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
                a[(i + k) % nums.Length] = nums[i];
            for (int i = 0; i < nums.Length; i++)
                nums[i] = a[i];
        }

        //TC: O(n)
        //SC: O(1)   
        public void Rotate(int[] nums, int k)
        {
            k %= nums.Length;
            Reverse(nums, 0, nums.Length - 1);
            Reverse(nums, 0, k - 1);
            Reverse(nums, k, nums.Length - 1);
        }

        //TC: O(n)
        //SC: O(1) 
        void Reverse(int[] nums, int start, int end)
        {
            while (start < end)
            {
                int temp = nums[start];
                nums[start] = nums[end];
                nums[end] = temp;
                start++;
                end--;
            }
        }
    }
}

namespace ALGON.LeetCodeProblems.PArray
{
    //Given an array nums with n integers, your task is to check if it could become non-decreasing by modifying at most 1 element.
    //We define an array is non-decreasing if nums[i] <= nums[i + 1] holds for every i(0-based) such that(0 <= i <= n - 2).

    //Example 1:

    //Input: nums = [4,2,3]
    //    Output: true
    //Explanation: You could modify the first 4 to 1 to get a non-decreasing array.
    //Example 2:

    //Input: nums = [4, 2, 1]
    //Output: false
    //Explanation: You can't get a non-decreasing array by modify at most one element.

    //Constraints:

    //1 <= n <= 10 ^ 4
    //- 10 ^ 5 <= nums[i] <= 10 ^ 5
    public class Solution_665
    {
        //TC: O(N)
        //SC: O(1)
        public bool CheckPossibility(int[] nums)
        {
            if (nums == null || nums.Length == 0 || nums.Length == 1)
                return true;

            var needModifications = 0;

            var p = -1;

            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] > nums[i + 1])
                {
                    needModifications++;
                    p = i;
                }

                if (needModifications > 1)
                    return false;
            }


            //p <= 0, p = -1 or p == 0 => no change or change first
            //p == nums.Length - 2 => 5 6 9 1 [change 1]
            //nums[p - 1] <= nums[p + 1] => 3 4 2 3, if we change 4, first 3 will be more than 2 then ans is false
            //nums[p] <= nums[p + 2] => 5 7 1 8, we can change 1, because 7 is less than last (8)

            return p <= 0 || p == nums.Length - 2 || nums[p - 1] <= nums[p + 1] || nums[p] <= nums[p + 2];
        }
    }
}


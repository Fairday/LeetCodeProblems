namespace ALGON.LeetCodeProblems.TopInverviewQuestions_Free
{
    //Given an array nums, write a function to move all 0's to the end of it while maintaining the relative order of the non-zero elements.

    //Example:

    //Input: [0,1,0,3,12]
    //    Output: [1,3,12,0,0]
    //    Note:

    //You must do this in-place without making a copy of the array.
    //Minimize the total number of operations.
    public class Solution_283
    {
        //TC: O(N)
        //SC: O(1)
        public void MoveZeroes(int[] nums)
        {
            if (nums != null)
            {
                var j = -1;
                for (int i = 0; i < nums.Length; i++)
                {
                    var num = nums[i];
                    if (num != 0 && j >= 0)
                    {
                        nums[j] = num;
                        nums[i] = 0;
                        j++;
                    }
                    else if (j < 0 && num == 0)
                        j = i;
                }
            }
        }
    }
}

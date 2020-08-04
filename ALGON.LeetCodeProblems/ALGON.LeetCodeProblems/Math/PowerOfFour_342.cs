namespace ALGON.LeetCodeProblems.PMath
{
    /*Given an integer(signed 32 bits), write a function to check whether it is a power of 4.

    Example 1:

    Input: 16
    Output: true
    Example 2:

    Input: 5
    Output: false
    Follow up: Could you solve it without loops/recursion?*/
    public class Solution_342
    {
        //More interesting solutions - https://www.programcreek.com/2015/04/leetcode-power-of-four-java/
        public bool IsPowerOfFour(int num)
        {
            while (num > 0)
            {
                if (num == 1)
                    return true;

                if (num % 4 != 0)
                {
                    return false;
                }
                else
                {
                    num /= 4;
                }
            }

            return false;
        }
    }
}

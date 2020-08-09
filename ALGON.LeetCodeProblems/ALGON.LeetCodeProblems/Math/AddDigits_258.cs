namespace ALGON.LeetCodeProblems.PMath
{
    /*Given a non-negative integer num, repeatedly add all its digits until the result has only one digit.

    Example:

    Input: 38
    Output: 2 
    Explanation: The process is like: 3 + 8 = 11, 1 + 1 = 2. 
                 Since 2 has only one digit, return it.
    Follow up:
    Could you do it without any loop/recursion in O(1) runtime?*/
    public class Solution_258
    {
        // O(N)
        public int AddDigits1(int num)
        {
            int sum = 0;

            while (num > 0 || sum > 9)
            {
                if (num == 0)
                {
                    num = sum;
                    sum = 0;
                }

                sum += num % 10;
                num /= 10;
            }

            return sum;
        }

        // O(1)
        // https://www.geeksforgeeks.org/finding-sum-of-digits-of-a-number-until-sum-becomes-single-digit/
        public int AddDigits(int num)
        {
            if (num == 0)
                return 0;

            return (num % 9) == 0 ? 9 : num % 9;
        }
    }
}

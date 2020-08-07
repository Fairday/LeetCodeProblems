namespace ALGON.LeetCodeProblems.Math
{
    /*Given a non-negative integer n, count all numbers with unique digits, x, where 0 ≤ x< 10n.

    Example:

    Input: 2
    Output: 91 
    Explanation: The answer should be the total numbers in the range of 0 ≤ x< 100,
                 excluding 11,22,33,44,55,66,77,88,99

    Constraints:

    0 <= n <= 8*/
    public class Solution_357
    {
        public int CountNumbersWithUniqueDigits(int n)
        {
            if (n == 0)
                return 1;

            int[] dp = new int[n];
            dp[0] = 10;
            var remaining = 9;

            for (int i = 1; i < n; i++)
            {
                if (i == 1)
                    dp[i] = (dp[i - 1] - 1) * remaining + dp[i - 1];
                else
                    dp[i] = (dp[i - 1] - dp[i - 2]) * remaining + dp[i - 1];

                remaining--;
            }

            return dp[n - 1];
        }
    }
}

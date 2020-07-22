using System;

namespace ALGON.LeetCodeProblems.DynamicProgramming
{
    /*Given a positive integer n, find the least number of perfect square numbers(for example, 1, 4, 9, 16, ...) which sum to n.

    Example 1:

    Input: n = 12
    Output: 3 
    Explanation: 12 = 4 + 4 + 4.
    Example 2:


    Input: n = 13
    Output: 2
    Explanation: 13 = 4 + 9.*/
    public class Solution
    {
        //Good explanation
        //https://www.youtube.com/watch?v=dOOzOsfj31I
        public int NumSquares(int n)
        {
            var dp = new int[n + 1];
            for (int i = 1; i < dp.Length; i++)
                dp[i] = int.MaxValue;
            var max = (int)Math.Sqrt(n);
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= max; j++)
                {
                    if (i == j * j)
                        dp[i] = 1;
                    else if (i > j * j)
                        dp[i] = Math.Min(dp[i], dp[i - j * j] + 1);
                }
            }
            return dp[n];
        }
    }
}

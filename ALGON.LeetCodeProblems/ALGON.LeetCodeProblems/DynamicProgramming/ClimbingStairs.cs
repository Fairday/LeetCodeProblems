namespace ALGON.LeetCodeProblems.DynamicProgramming
{
    /*You are climbing a stair case. It takes n steps to reach to the top.

    Each time you can either climb 1 or 2 steps.In how many distinct ways can you climb to the top?

    Example 1:

    Input: 2
    Output: 2
    Explanation: There are two ways to climb to the top.
    1. 1 step + 1 step
    2. 2 steps
    Example 2:

    Input: 3
    Output: 3
    Explanation: There are three ways to climb to the top.
    1. 1 step + 1 step + 1 step
    2. 1 step + 2 steps
    3. 2 steps + 1 step


    Constraints:

    1 <= n <= 45*/
    public class Solution_70
    {
        public int ClimbStairs1(int n)
        {
            var cache = new int[n];
            return vars(0, n, cache);
        }

        int vars(int i, int n, int[] cache)
        {
            if (i > n)
                return 0;
            if (i == n)
                return 1;
            if (cache[i] > 0)
                return cache[i];
            cache[i] = vars(i + 1, n, cache) + vars(i + 2, n, cache);
            return cache[i];
        }

        public int ClimbStairs(int n)
        {
            if (n == 1)
                return 1;

            var dp = new int[n];
            dp[0] = 1;
            dp[1] = dp[0] + 1;

            for (int i = 2; i < n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }

            return dp[n - 1];
        }
    }
}

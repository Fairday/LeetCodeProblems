using System;

namespace ALGON.LeetCodeProblems.DynamicProgramming
{
    /*You are given coins of different denominations and a total amount of money amount.Write a function to compute the fewest number of coins that you need to make up that amount.If that amount of money cannot be made up by any combination of the coins, return -1.

    Example 1:

    Input: coins = [1, 2, 5], amount = 11
    Output: 3 
    Explanation: 11 = 5 + 5 + 1
    Example 2:

    Input: coins = [2], amount = 3
    Output: -1
    Note:
    You may assume that you have an infinite number of each kind of coin.*/
    public class Solution_322
    {
        // Bottom -> Up solution
        // O(coins.Length * amount)
        public int CoinChange1(int[] coins, int amount)
        {
            var max = amount + 1;
            var dp = new int[amount + 1];
            for (int i = 1; i <= amount; i++)
                dp[i] = max;
            dp[0] = 0;
            for (int i = 1; i <= amount; i++)
            {
                for (int j = 0; j < coins.Length; j++)
                {
                    if (coins[j] <= i)
                    {
                        var prev = i - coins[j];
                        dp[i] = Math.Min(dp[i], dp[prev] + 1);
                    }
                }
            }

            return dp[amount] > amount ? -1 : dp[amount];
        }

        // Recursive Top Down
        // O(coins.Length * amount)
        //Example: amount = 11, coins = [1, 3, 5]
        //Solution: f(11) = 1 + Min(f(11 - 1), f(11 - 3), f(11 - 5))
        public int CoinChange(int[] coins, int amount)
        {
            if (amount < 1)
                return 0;
            return CoinChange1_Helper(coins, amount, new int[amount]);
        }

        public int CoinChange1_Helper(int[] coins, int rem, int[] cache)
        {
            if (rem < 0)
                return -1;
            if (rem == 0)
                return 0;
            if (cache[rem - 1] != 0)
                return cache[rem - 1];
            var min = int.MaxValue;
            for (int i = 0; i < coins.Length; i++)
            {
                var res = CoinChange1_Helper(coins, rem - coins[i], cache);
                if (res >= 0 && res < min)
                    min = res + 1;
            }
            cache[rem - 1] = (min == int.MaxValue) ? -1 : min;
            return cache[rem - 1];
        }
    }
}

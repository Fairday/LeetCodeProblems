using System;

namespace ALGON.LeetCodeProblems.DynamicProgramming
{
    //Say you have an array for which the ith element is the price of a given stock on day i.
    //Design an algorithm to find the maximum profit.You may complete at most two transactions.

    //Note: You may not engage in multiple transactions at the same time (i.e., you must sell the stock before you buy again).

    //Example 1:

    //Input: [3,3,5,0,0,3,1,4]
    //    Output: 6
    //Explanation: Buy on day 4 (price = 0) and sell on day 6 (price = 3), profit = 3-0 = 3.
    //             Then buy on day 7 (price = 1) and sell on day 8 (price = 4), profit = 4-1 = 3.
    //Example 2:

    //Input: [1,2,3,4,5]
    //    Output: 4
    //Explanation: Buy on day 1 (price = 1) and sell on day 5 (price = 5), profit = 5-1 = 4.
    //             Note that you cannot buy on day 1, buy on day 2 and sell them later, as you are
    //             engaging multiple transactions at the same time.You must sell before buying again.
    //Example 3:

    //Input: [7,6,4,3,1]
    //Output: 0
    //Explanation: In this case, no transaction is done, i.e.max profit = 0.
    public class Solution_123
    {
        //TC: O(n), SC: O(1)
        public int MaxProfit(int[] prices)
        {
            ///four states solution

            if (prices.Length <= 1)
                return 0;

            // buying first share
            var b1 = -prices[0];
            // selling first share
            var s1 = Int32.MinValue;
            // buying second share
            var b2 = Int32.MinValue;
            // selling second share
            var s2 = Int32.MinValue;

            for (int i = 1; i < prices.Length; i++)
            {
                // Spend money for first buy or skip
                b1 = Math.Max(b1, -prices[i]);
                // Sell first share, earn profit or skip
                s1 = Math.Max(s1, b1 + prices[i]);
                // Spend money for second buy
                b2 = Math.Max(b2, s1 - prices[i]);
                //  Sell second share, earn profit or skip
                s2 = Math.Max(s2, b2 + prices[i]);
            }

            return Math.Max(0, s2);
        }
    }
}

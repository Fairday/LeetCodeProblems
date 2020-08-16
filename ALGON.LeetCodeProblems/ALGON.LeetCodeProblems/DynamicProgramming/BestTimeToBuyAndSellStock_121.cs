using System;
using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.DynamicProgramming
{
    //Say you have an array for which the ith element is the price of a given stock on day i.

    //If you were only permitted to complete at most one transaction(i.e., buy one and sell one share of the stock), design an algorithm to find the maximum profit.

    //Note that you cannot sell a stock before you buy one.


    //Example 1:


    //Input: [7,1,5,3,6,4]
    //Output: 5
    //Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
    //             Not 7-1 = 6, as selling price needs to be larger than buying price.
    //Example 2:

    //Input: [7,6,4,3,1]
    //Output: 0
    //Explanation: In this case, no transaction is done, i.e.max profit = 0.
    public class Solution_121
    {
        public int MaxProfit(int[] prices)
        {
            if (prices.Length == 0) return 0;

            int maxProfit = 0;
            var stock = prices[0];
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] > stock)
                    maxProfit = Math.Max(maxProfit, -stock + prices[i]);
                else
                    stock = prices[i];
            }

            return maxProfit;
        }
    }
}

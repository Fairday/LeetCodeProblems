using System;

namespace ALGON.LeetCodeProblems.DynamicProgramming
{
    /*Say you have an array for which the ith element is the price of a given stock on day i.

    Design an algorithm to find the maximum profit.You may complete as many transactions as you like (ie, buy one and sell one share of the stock multiple times) with the following restrictions:

    You may not engage in multiple transactions at the same time(ie, you must sell the stock before you buy again).
    After you sell your stock, you cannot buy stock on next day. (ie, cooldown 1 day)
    Example:

    Input: [1,2,3,0,2]
        Output: 3 
    Explanation: transactions = [buy, sell, cooldown, buy, sell]*/
    public class Solution_309
    {
        public int MaxProfit(int[] prices)
        {
            if (prices.Length == 0 || prices.Length <= 1)
                return 0;

            var buy = new int[prices.Length];
            var sell = new int[prices.Length];

            buy[0] = -prices[0]; // the profit after buy a price[i] or cooldown
            sell[0] = 0;
            buy[1] = Math.Max(buy[0], -prices[1]); // when better to buy
            sell[1] = Math.Max(sell[0], buy[0] + prices[1]); // when better to sell

            for (int i = 2; i < prices.Length; i++)
            {
                //when better to buy: buy on prev. (now we can sell) or sell->cooldown>now buy            
                buy[i] = Math.Max(buy[i - 1], sell[i - 2] - prices[i]);
                //when better to sell: sell on prev. (now is cooldown) or buy prev and sell now            
                sell[i] = Math.Max(sell[i - 1], buy[i - 1] + prices[i]);
            }

            return sell[prices.Length - 1];
        }
    }
}

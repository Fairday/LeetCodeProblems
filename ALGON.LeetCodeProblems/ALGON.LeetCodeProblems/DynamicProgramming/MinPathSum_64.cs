using System;

namespace ALGON.LeetCodeProblems.DynamicProgramming
{
    /*Given a m x n grid filled with non-negative numbers, find a path from top left to bottom right which minimizes the sum of all numbers along its path.

    Note: You can only move either down or right at any point in time.

    Example:

    Input:
    [
      [1,3,1],
      [1,5,1],
      [4,2,1]
    ]
    Output: 7
    Explanation: Because the path 1→3→1→1→1 minimizes the sum.*/
    public class Solution_64
    {
        public int MinPathSum(int[][] grid)
        {
            var m = grid[0].Length;
            var n = grid.Length;

            var dp = new int[n, m];
            dp[0, 0] = grid[0][0];

            for (int col = 1; col < m; col++)
            {
                dp[0, col] = dp[0, col - 1] + grid[0][col];
            }

            for (int row = 1; row < n; row++)
            {
                dp[row, 0] = dp[row - 1, 0] + grid[row][0];
            }

            for (int row = 1; row < n; row++)
            {
                for (int col = 1; col < m; col++)
                {
                    dp[row, col] = Math.Min(dp[row, col - 1], dp[row - 1, col]) + grid[row][col];
                }
            }

            return dp[n - 1, m - 1];
        }
    }
}

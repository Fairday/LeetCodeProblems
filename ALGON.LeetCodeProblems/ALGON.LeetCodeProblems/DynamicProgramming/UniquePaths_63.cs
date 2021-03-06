﻿namespace ALGON.LeetCodeProblems.DynamicProgramming
{
    /*A robot is located at the top-left corner of a m x n grid(marked 'Start' in the diagram below).

    The robot can only move either down or right at any point in time.The robot is trying to reach the bottom-right corner of the grid(marked 'Finish' in the diagram below).

    Now consider if some obstacles are added to the grids.How many unique paths would there be?



    An obstacle and empty space is marked as 1 and 0 respectively in the grid.

    Note: m and n will be at most 100.


    Example 1:


    Input:
    [
      [0,0,0],
     [0,1,0],
     [0,0,0]
    ]
    Output: 2
    Explanation:
    There is one obstacle in the middle of the 3x3 grid above.
    There are two ways to reach the bottom-right corner:
    1. Right -> Right -> Down -> Down
    2. Down -> Down -> Right -> Right*/
    public class Solution_63
    {
        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            var n = obstacleGrid.Length;
            var m = obstacleGrid[0].Length;

            var dp = new int[n, m];

            for (int i = 0; i < m; i++)
            {
                if (obstacleGrid[0][i] == 1)
                    break;
                else
                    dp[0, i] = 1;
            }

            for (int i = 0; i < n; i++)
            {
                if (obstacleGrid[i][0] == 1)
                    break;
                else
                    dp[i, 0] = 1;
            }

            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    var up = obstacleGrid[i - 1][j] == 1 ? 0 : dp[i - 1, j];
                    var left = obstacleGrid[i][j - 1] == 1 ? 0 : dp[i, j - 1];
                    dp[i, j] = up + left;
                }
            }

            return obstacleGrid[n - 1][m - 1] == 1 ? 0 : dp[n - 1, m - 1];
        }
    }
}

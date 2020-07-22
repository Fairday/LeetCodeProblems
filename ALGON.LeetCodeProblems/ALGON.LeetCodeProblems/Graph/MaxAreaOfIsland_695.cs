using System;

namespace ALGON.LeetCodeProblems.Graph
{
    /*Given a non-empty 2D array grid of 0's and 1's, an island is a group of 1's (representing land) connected 4-directionally (horizontal or vertical.) You may assume all four edges of the grid are surrounded by water.

    Find the maximum area of an island in the given 2D array. (If there is no island, the maximum area is 0.)

    Example 1:

    [[0,0,1,0,0,0,0,1,0,0,0,0,0],
     [0,0,0,0,0,0,0,1,1,1,0,0,0],
     [0,1,1,0,1,0,0,0,0,0,0,0,0],
     [0,1,0,0,1,1,0,0,1,0,1,0,0],
     [0,1,0,0,1,1,0,0,1,1,1,0,0],
     [0,0,0,0,0,0,0,0,0,0,1,0,0],
     [0,0,0,0,0,0,0,1,1,1,0,0,0],
     [0,0,0,0,0,0,0,1,1,0,0,0,0]]
    Given the above grid, return 6. Note the answer is not 11, because the island must be connected 4-directionally.
    Example 2:

    [[0,0,0,0,0,0,0,0]]
    Given the above grid, return 0.
    Note: The length of each dimension in the given grid does not exceed 50.*/
    public class Solution_695
    {
        public int MaxAreaOfIsland(int[][] grid)
        {
            if (grid.Length == 0)
                return 0;

            var rows = grid.Length;
            var cols = grid[0].Length;

            var count = 0;
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (grid[r][c] == 1)
                    {
                        count = Math.Max(dfs(grid, r, c), count);
                    }
                }
            }
            return count;
        }

        public int dfs(int[][] grid, int r, int c)
        {
            var rows = grid.Length;
            var cols = grid[0].Length;

            if (r < 0 || c < 0 || r >= rows || c >= cols || grid[r][c] == 0)
                return 0;

            grid[r][c] = 0;
            return 1 + dfs(grid, r - 1, c) + dfs(grid, r + 1, c) + dfs(grid, r, c - 1) + dfs(grid, r, c + 1);
        }
    }
}

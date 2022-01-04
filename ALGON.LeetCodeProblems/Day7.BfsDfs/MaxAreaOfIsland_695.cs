using System;

namespace Day7.BfsDfs
{
    //You are given an m x n binary matrix grid. An island is a group of 1's (representing land) connected 4-directionally (horizontal or vertical.) You may assume all four edges of the grid are surrounded by water.

    //The area of an island is the number of cells with a value 1 in the island.

    //Return the maximum area of an island in grid. If there is no island, return 0.



    //Example 1:


    //Input: grid = [[0,0,1,0,0,0,0,1,0,0,0,0,0],[0,0,0,0,0,0,0,1,1,1,0,0,0],[0,1,1,0,1,0,0,0,0,0,0,0,0],[0,1,0,0,1,1,0,0,1,0,1,0,0],[0,1,0,0,1,1,0,0,1,1,1,0,0],[0,0,0,0,0,0,0,0,0,0,1,0,0],[0,0,0,0,0,0,0,1,1,1,0,0,0],[0,0,0,0,0,0,0,1,1,0,0,0,0]]
    //Output: 6
    //Explanation: The answer is not 11, because the island must be connected 4-directionally.
    //Example 2:

    //Input: grid = [[0,0,0,0,0,0,0,0]]
    //Output: 0


    //Constraints:

    //m == grid.length
    //n == grid[i].length
    //1 <= m, n <= 50
    //grid[i][j] is either 0 or 1.
    public class MaxAreaOfIsland_695
    {   
        //TC: O(R * C)
        //SC: O(R * C) - only for call stack
        public int MaxAreaOfIsland(int[][] grid)
        {
            if (grid == null)
                throw new Exception("grid cannot be null");

            if (grid.Length == 0)
                return 0;

            int count = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        count = Math.Max(Dfs(grid, i, j), count);
                    }
                }
            }

            return count;
        }

        private int Dfs(int[][] grid, int r, int c)
        {
            var rows = grid.Length;
            var cols = grid[0].Length;

            if (r < 0 || c < 0 || r >= rows || c >= cols || grid[r][c] == 0)
                return 0;

            //visited
            grid[r][c] = 0;
            return 1 + Dfs(grid, r - 1, c) + Dfs(grid, r + 1, c) + Dfs(grid, r, c - 1) + Dfs(grid, r, c + 1);
        }
    }
}
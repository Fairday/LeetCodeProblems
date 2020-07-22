namespace ALGON.LeetCodeProblems.Graph
{
    /*Given a 2d grid map of '1's(land) and '0's(water), count the number of islands.An island is surrounded by water
      and is formed by connecting adjacent lands horizontally or vertically.You may assume all four edges of the grid are all surrounded by water.

    Example 1:


    Input: grid = [

    ["1", "1", "1", "1", "0"],
    ["1","1","0","1","0"],
    ["1","1","0","0","0"],
    ["0","0","0","0","0"]
    ]
    Output: 1
    Example 2:

    Input: grid = [
      ["1","1","0","0","0"],
      ["1","1","0","0","0"],
      ["0","0","1","0","0"],
      ["0","0","0","1","1"]
    ]
    Output: 3*/
    public class Solution_200
    {
        public int NumIslands(char[][] grid)
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
                    if (grid[r][c] == '1')
                    {
                        count++;
                        dfs(grid, r, c);
                    }
                }
            }
            return count;
        }

        public void dfs(char[][] grid, int r, int c)
        {
            var rows = grid.Length;
            var cols = grid[0].Length;

            if (r < 0 || c < 0 || r >= rows || c >= cols || grid[r][c] == '0')
                return;

            grid[r][c] = '0';
            dfs(grid, r - 1, c);
            dfs(grid, r + 1, c);
            dfs(grid, r, c - 1);
            dfs(grid, r, c + 1);
        }
    }
}

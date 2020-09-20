namespace ALGON.LeetCodeProblems.Backtracking
{
    //On a 2-dimensional grid, there are 4 types of squares:

    //1 represents the starting square.There is exactly one starting square.
    //2 represents the ending square.  There is exactly one ending square.
    //0 represents empty squares we can walk over.
    //-1 represents obstacles that we cannot walk over.
    //Return the number of 4-directional walks from the starting square to the ending square, that walk over every non-obstacle square exactly once.

    //Example 1:

    //Input: [[1,0,0,0], [0,0,0,0], [0,0,2,-1]]
    //Output: 2
    //Explanation: We have the following two paths: 
    //1. (0,0),(0,1),(0,2),(0,3),(1,3),(1,2),(1,1),(1,0),(2,0),(2,1),(2,2)
    //2. (0,0),(1,0),(2,0),(2,1),(1,1),(0,1),(0,2),(0,3),(1,3),(1,2),(2,2)
    //Example 2:

    //Input: [[1,0,0,0],[0,0,0,0],[0,0,0,2]]
    //Output: 4
    //Explanation: We have the following four paths: 
    //1. (0,0),(0,1),(0,2),(0,3),(1,3),(1,2),(1,1),(1,0),(2,0),(2,1),(2,2),(2,3)
    //2. (0,0),(0,1),(1,1),(1,0),(2,0),(2,1),(2,2),(1,2),(0,2),(0,3),(1,3),(2,3)
    //3. (0,0),(1,0),(2,0),(2,1),(2,2),(1,2),(1,1),(0,1),(0,2),(0,3),(1,3),(2,3)
    //4. (0,0),(1,0),(2,0),(2,1),(1,1),(0,1),(0,2),(0,3),(1,3),(1,2),(2,2),(2,3)
    //Example 3:

    //Input: [[0,1],[2,0]]
    //Output: 0
    //Explanation: 
    //There is no path that walks over every empty square exactly once.
    //Note that the starting and ending square can be anywhere in the grid.


    //Note:

    //1 <= grid.length* grid[0].length <= 20
    public class Solution_980
    {
        int paths = 0;

        //TC: O(3^N) - only 3 new directions on each cell
        //SC: O(N) - recursive stack
        //https://leetcode.com/problems/unique-paths-iii/
        public int UniquePathsIII(int[][] grid)
        {
            if (grid == null || grid.Length == 0)
                return paths;

            var rows = grid.Length;
            var cols = grid[0].Length;

            var startRow = 0;
            var startCol = 0;

            var non_obstacles = 0;

            //find all cells to be visited
            for (int row = 0; row < rows; row++)
                for (int col = 0; col < cols; col++)
                {
                    var cell = grid[row][col];
                    if (cell >= 0)
                        non_obstacles++;
                    if (cell == 1)
                    {
                        startRow = row;
                        startCol = col;
                    }
                }

            dfs(startRow, startCol, grid, non_obstacles);

            return paths;
        }

        void dfs(int row, int col, int[][] grid, int remain)
        {
            var cell = grid[row][col];

            if (cell == 2 && remain == 1)
            {
                paths++;
                return;
            }

            //Mark that we visit this cell
            var temp = grid[row][col];
            grid[row][col] = -100;
            remain--;

            //Check 4 directions: left, right, up, down, 
            int[] rowOffsets = new int[] { 0, 0, 1, -1 };
            int[] colOffsets = new int[] { 1, -1, 0, 0 };

            for (int i = 0; i < 4; i++)
            {
                var nextRow = row + rowOffsets[i];
                var nextCol = col + colOffsets[i];

                //invalid coordinate
                if (nextRow < 0 || nextRow >= grid.Length || nextCol < 0 || nextCol >= grid[0].Length)
                    continue;

                //already visited or obstacle
                if (grid[nextRow][nextCol] < 0)
                    continue;

                dfs(nextRow, nextCol, grid, remain);
            }

            grid[row][col] = temp;
        }
    }
}

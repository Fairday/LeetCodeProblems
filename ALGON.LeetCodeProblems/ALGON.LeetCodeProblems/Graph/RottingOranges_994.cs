using System;
using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.Graph
{
    //In a given grid, each cell can have one of three values:

    //the value 0 representing an empty cell;
    //    the value 1 representing a fresh orange;
    //    the value 2 representing a rotten orange.
    //    Every minute, any fresh orange that is adjacent (4-directionally) to a rotten orange becomes rotten.

    //    Return the minimum number of minutes that must elapse until no cell has a fresh orange.If this is impossible, return -1 instead.



    //    Example 1:




    //    Input: [[2,1,1], [1,1,0], [0,1,1]]
    //Output: 4
    //Example 2:

    //Input: [[2,1,1],[0,1,1],[1,0,1]]
    //Output: -1
    //Explanation:  The orange in the bottom left corner(row 2, column 0) is never rotten, because rotting only happens 4-directionally.
    //Example 3:

    //Input: [[0,2]]
    //Output: 0
    //Explanation:  Since there are already no fresh oranges at minute 0, the answer is just 0.
 

    //Note:

    //1 <= grid.length <= 10
    //1 <= grid[0].length <= 10
    //grid[i][j] is only 0, 1, or 2.
    public class Solution_994
    {
        public int OrangesRotting(int[][] grid)
        {
            if (grid == null || grid.Length == 0)
                return 0;

            var rows = grid.Length;
            var cols = grid[0].Length;

            var freshOranges = 0;
            var rottenOranges = 0;
            var queue = new Queue<Tuple<int, int>>();

            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                {
                    if (grid[r][c] == 1)
                        freshOranges++;
                    else if (grid[r][c] == 2)
                    {
                        rottenOranges++;
                        queue.Enqueue(Tuple.Create(r, c));
                    }
                }

            if (freshOranges == 0)
                return 0;
            else if (rottenOranges == 0)
                return -1;

            var minutes = -1;

            while (queue.Count > 0)
            {
                var positions = queue.Count;

                minutes++;

                while (positions > 0)
                {
                    var position = queue.Dequeue();

                    var row = position.Item1;
                    var col = position.Item2;

                    if (row - 1 >= 0)
                    {
                        if (grid[row - 1][col] == 1)
                        {
                            freshOranges--;
                            queue.Enqueue(Tuple.Create(row - 1, col));
                            grid[row - 1][col] = 2;
                        }
                    }

                    if (row + 1 < rows)
                    {
                        if (grid[row + 1][col] == 1)
                        {
                            freshOranges--;
                            queue.Enqueue(Tuple.Create(row + 1, col));
                            grid[row + 1][col] = 2;
                        }
                    }

                    if (col - 1 >= 0)
                    {
                        if (grid[row][col - 1] == 1)
                        {

                            freshOranges--;
                            queue.Enqueue(Tuple.Create(row, col - 1));
                            grid[row][col - 1] = 2;
                        }
                    }

                    if (col + 1 < cols)
                    {
                        if (grid[row][col + 1] == 1)
                        {
                            freshOranges--;
                            queue.Enqueue(Tuple.Create(row, col + 1));
                            grid[row][col + 1] = 2;
                        }
                    }

                    positions--;
                }
            }

            return freshOranges == 0 ? minutes : -1;
        }
    }
}

using System.Collections.Generic;

namespace Day9.BdfDfs
{
    //You are given an m x n grid where each cell can have one of three values:

    //0 representing an empty cell,
    //1 representing a fresh orange, or
    //2 representing a rotten orange.
    //Every minute, any fresh orange that is 4-directionally adjacent to a rotten orange becomes rotten.

    //Return the minimum number of minutes that must elapse until no cell has a fresh orange. If this is impossible, return -1.

    //Example 1:

    //Input: grid = [[2, 1, 1], [1,1,0], [0,1,1]]
    //Output: 4
    //Example 2:

    //Input: grid = [[2,1,1],[0,1,1],[1,0,1]]
    //Output: -1
    //Explanation: The orange in the bottom left corner(row 2, column 0) is never rotten, because rotting only happens 4-directionally.
    //Example 3:

    //Input: grid = [[0,2]]
    //Output: 0
    //Explanation: Since there are already no fresh oranges at minute 0, the answer is just 0.

    //Constraints:

    //m == grid.length
    //n == grid[i].length
    //1 <= m, n <= 10
    //grid[i][j] is 0, 1, or 2.
    public class RottingOranges_994
    {
        public struct Point
        {
            public Point(int r, int c)
            {
                this.r = r;
                this.c = c;
            }

            public int r;
            public int c;
        }

        private Point[] dirs = new Point[] { new Point(1, 0), new Point(-1, 0), new Point(0, 1), new Point(0, -1) };

        //TC: O(N), where N = r * c
        //SC: O(N), where N = r * c
        public int OrangesRotting(int[][] grid)
        {
            int fresh = 0;
            var queue = new Queue<Point>();
            for (int i = 0; i < grid.Length; i++)
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 2)
                        queue.Enqueue(new Point(i, j));
                    else if (grid[i][j] == 1)
                        fresh++;
                }

            if (fresh == 0)
                return 0;

            var time = -1;
            while (queue.Count != 0)
            {
                var count = queue.Count;
                time++;
                for (int i = 0; i < count; i++)
                {
                    var point = queue.Dequeue();
                    foreach (var dir in dirs)
                    {
                        var rr = point.r + dir.r;
                        var cc = point.c + dir.c;

                        if (InGrid(grid, rr, cc))
                        {
                            if (grid[rr][cc] == 1)
                            {
                                grid[rr][cc] = 2;
                                fresh--;
                                queue.Enqueue(new Point(rr, cc));
                            }
                        }
                    }
                }
            }

            return fresh == 0 ? time : -1;
        }

        private bool InGrid(int[][] grid, int r, int c)
        {
            if (r < 0 || c < 0 || r >= grid.Length || c >= grid[0].Length)
                return false;

            return true;
        }
    }
}
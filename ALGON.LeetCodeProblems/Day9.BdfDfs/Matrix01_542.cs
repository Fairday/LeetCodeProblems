using System;
using System.Collections.Generic;

namespace Day9.BdfDfs
{
    //Given an m x n binary matrix mat, return the distance of the nearest 0 for each cell.

    //The distance between two adjacent cells is 1.

    //Example 1:

    //Input: mat = [[0,0,0],[0,1,0],[0,0,0]]
    //Output: [[0,0,0],[0,1,0],[0,0,0]]
    //Example 2:

    //Input: mat = [[0,0,0],[0,1,0],[1,1,1]]
    //Output: [[0,0,0],[0,1,0],[1,2,1]]

    //Constraints:

    //m == mat.length
    //n == mat[i].length
    //1 <= m, n <= 104
    //1 <= m * n <= 104
    //mat[i][j] is either 0 or 1.
    //There is at least one 0 in mat.
    public class Matrix01_542
    {
        public int[][] UpdateMatrix_DP(int[][] mat)
        {
            throw new NotImplementedException();
        }

        public int[][] UpdateMatrix_BruteForce(int[][] mat)
        {
            throw new NotImplementedException();
        }

        //BFS

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
        public int[][] UpdateMatrix_Bfs(int[][] mat)
        {
            var queue = new Queue<Point>();
            for (int i = 0; i < mat.Length; i++)
                for (int j = 0; j < mat[0].Length; j++)
                {
                    if (mat[i][j] == 1)
                        mat[i][j] = -1;
                    else
                        queue.Enqueue(new Point(i, j));
                }


            int length = 0;
            while (queue.Count != 0)
            {
                var count = queue.Count;
                length++;
                for (int i = 0; i < count; i++)
                {
                    var point = queue.Dequeue();
                    foreach (var dir in dirs)
                    {
                        var rr = point.r + dir.r;
                        var cc = point.c + dir.c;

                        if (InMatrix(mat, rr, cc))
                        {
                            if (mat[rr][cc] == -1)
                            {
                                mat[rr][cc] = length;
                                queue.Enqueue(new Point(rr, cc));
                            }
                        }
                    }
                }
            }

            return mat;
        }

        private bool InMatrix(int[][] mat, int r, int c)
        {
            if (r < 0 || c < 0 || r >= mat.Length || c >= mat[0].Length)
                return false;

            return true;
        }

        //DFS

        const int maxMatrixSize = 10000;

        //TC: O(N^2)
        //SC: O(1) for additional memory (one place) + O(N) dfs call stack
        //Time limit exceeded
        public int[][] UpdateMatrix_Dfs(int[][] mat)
        {
            if (mat == null)
                return new int[0][];

            for (int i = 0; i < mat.Length; i++)
                for (int j = 0; j < mat[0].Length; j++)
                    if (mat[i][j] == 1)
                        mat[i][j] = maxMatrixSize;

            var rows = mat.Length;
            var cols = mat[0].Length;

            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                    FindNearestZeroDistance(mat, r, c);

            return mat;
        }

        private int FindNearestZeroDistance(int[][] mat, int r, int c)
        {
            //use -2 as visited
            if (r < 0 || c < 0 || r >= mat.Length || c >= mat[0].Length || mat[r][c] == -2)
                return maxMatrixSize;

            if (mat[r][c] == 0 || mat[r][c] == 1)
                return mat[r][c];

            var dist = mat[r][c];
            mat[r][c] = -2;

            //up
            dist = Math.Min(dist, FindNearestZeroDistance(mat, r - 1, c) + 1);
            //down
            dist = Math.Min(dist, FindNearestZeroDistance(mat, r + 1, c) + 1);
            //left
            dist = Math.Min(dist, FindNearestZeroDistance(mat, r, c - 1) + 1);
            //right
            dist = Math.Min(dist, FindNearestZeroDistance(mat, r, c + 1) + 1);

            mat[r][c] = dist;
            return dist;
        }
    }
}
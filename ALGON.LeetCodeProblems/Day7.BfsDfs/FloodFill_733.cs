using System.Collections;

namespace Day7.BfsDfs
{
    //An image is represented by an m x n integer grid image where image[i][j] represents the pixel value of the image.

    //You are also given three integers sr, sc, and newColor. You should perform a flood fill on the image starting from the pixel image[sr][sc].

    //To perform a flood fill, consider the starting pixel, plus any pixels connected 4-directionally to the starting pixel of the same color as the starting pixel, plus any pixels connected 4-directionally to those pixels (also with the same color), and so on.Replace the color of all of the aforementioned pixels with newColor.

    //Return the modified image after performing the flood fill.

    //Example 1:

    //Input: image = [[1,1,1],[1,1,0],[1,0,1]], sr = 1, sc = 1, newColor = 2
    //Output: [[2,2,2],[2,2,0],[2,0,1]]
    //Explanation: From the center of the image with position(sr, sc) = (1, 1) (i.e., the red pixel), all pixels connected by a path of the same color as the starting pixel(i.e., the blue pixels) are colored with the new color.
    //Note the bottom corner is not colored 2, because it is not 4-directionally connected to the starting pixel.
    //Example 2:

    //Input: image = [[0, 0, 0], [0,0,0]], sr = 0, sc = 0, newColor = 2
    //Output: [[2,2,2],[2,2,2]]
 
    //Constraints:

    //m == image.length
    //n == image[i].length
    //1 <= m, n <= 50
    //0 <= image[i][j], newColor< 216
    //0 <= sr<m
    //0 <= sc<n
    public class FloodFill_733
    {
        //TC: O(N)
        //SC: O(N) - only call stack
        public int[][] FloodFill_Optimized(int[][] image, int sr, int sc, int newColor)
        {
            Stack

            if (image[sr][sc] != newColor)
                Dfs_Simplified(image[sr][sc], image, sr, sc, newColor);
            return image;
        }

        private void Dfs_Simplified(int startColor, int[][] image, int sr, int sc, int newColor)
        {
            int rows = image.Length;
            int cols = image[0].Length;

            if (image[sr][sc] == startColor)
            {
                image[sr][sc] = newColor;
                //up
                if (sr >= 1)
                    Dfs_Simplified(startColor, image, sr - 1, sc, newColor);
                //left
                if (sc >= 1)
                    Dfs_Simplified(startColor, image, sr, sc - 1, newColor);
                //down
                if (sr + 1 < rows)
                    Dfs_Simplified(startColor, image, sr + 1, sc, newColor);
                //right
                if (sc + 1 < cols)
                    Dfs_Simplified(startColor, image, sr, sc + 1, newColor);
            }
        }

        private bool[][] visited;

        //TC: O(N)
        //SC: O(N) of visited + O(N) of call stack when calling dfs
        public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            visited = new bool[image.Length][];
            for (int i = 0; i < image.Length; i++)
                visited[i] = new bool[image[0].Length];
            Dfs(image[sr][sc], image, sr, sc, newColor);
            return image;
        }

        private void Dfs(int startColor, int[][] image, int sr, int sc, int newColor)
        {
            //Console.WriteLine("sr: " + sr + " sc: " + sc);

            int rows = image.Length;
            int cols = image[0].Length;

            if (sr > rows - 1 || sr < 0)
                return;
            if (sc > cols - 1 || sc < 0)
                return;

            var pixel = image[sr][sc];
            if (pixel != startColor || visited[sr][sc] == true)
                return;
            else
            {
                image[sr][sc] = newColor;
                visited[sr][sc] = true;
                //up
                Dfs(startColor, image, sr - 1, sc, newColor);
                //down
                Dfs(startColor, image, sr + 1, sc, newColor);
                //left
                Dfs(startColor, image, sr, sc - 1, newColor);
                //right
                Dfs(startColor, image, sr, sc + 1, newColor);
            }
        }
    }
}
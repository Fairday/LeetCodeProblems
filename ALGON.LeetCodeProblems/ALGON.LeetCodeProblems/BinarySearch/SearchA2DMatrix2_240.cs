namespace ALGON.LeetCodeProblems.BinarySearch
{
    /*Write an efficient algorithm that searches for a value in an m x n matrix.This matrix has the following properties:

    Integers in each row are sorted in ascending from left to right.
    Integers in each column are sorted in ascending from top to bottom.
    Example:

    Consider the following matrix:

    [
      [1,   4,  7, 11, 15],
      [2,   5,  8, 12, 19],
      [3,   6,  9, 16, 22],
      [10, 13, 14, 17, 24],
      [18, 21, 23, 26, 30]
    ]
    Given target = 5, return true.

    Given target = 20, return false.*/
    public class Solution_240
    {
        public bool SearchMatrix(int[,] matrix, int target)
        {
            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);

            var r = 0;
            var c = cols - 1;

            //starting from like right bottom (BST idea)
            //O(m + n)
            while (r < rows && c >= 0)
            {
                var cell = matrix[r, c];
                if (cell == target)
                    return true;
                else if (cell > target)
                    c--;
                else
                    r++;
            }

            return false;
        }
    }
}

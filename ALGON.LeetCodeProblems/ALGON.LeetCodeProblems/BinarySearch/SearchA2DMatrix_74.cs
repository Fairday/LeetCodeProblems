namespace ALGON.LeetCodeProblems.BinarySearch
{
    /*Write an efficient algorithm that searches for a value in an m x n matrix.This matrix has the following properties:

    Integers in each row are sorted from left to right.
    The first integer of each row is greater than the last integer of the previous row.
    Example 1:

    Input:
    matrix = [
      [1, 3, 5, 7],
      [10, 11, 16, 20],
      [23, 30, 34, 50]
    ]
    target = 3
    Output: true
    Example 2:

    Input:
    matrix = [
      [1,   3,  5,  7],
      [10, 11, 16, 20],
      [23, 30, 34, 50]
    ]
    target = 13
    Output: false*/
    // Efficient approach
    // https://discuss.leetcode.com/topic/4846/binary-search-on-an-ordered-matrix
    // https://discuss.leetcode.com/topic/3227/don-t-treat-it-as-a-2d-matrix-just-treat-it-as-a-sorted-list
    public class Solution_74
    {
        public bool SearchMatrix(int[][] matrix, int target)
        {
            var rows = matrix.Length;

            if (rows == 0)
                return false;

            var cols = matrix[0].Length;

            if (cols == 0)
                return false;

            if (target > matrix[rows - 1][cols - 1])
                return false;
            else if (target < matrix[0][0])
                return false;

            var left = 0;
            var right = rows * 2;

            while (right - left > 1)
            {
                var mid = left + (right - left) / 2;

                if (matrix[mid / 2][mid % 2 == 0 ? 0 : cols - 1] > target)
                    right = mid;
                else
                    left = mid;
            }

            left = 0;
            var row = matrix[(right - 1) / 2];
            right = cols - 1;

            if (right == 0)
                return row[right] == target;

            while (left <= right)
            {
                var mid = left + (right - left) / 2;

                if (row[mid] == target)
                    return true;
                else if (row[mid] > target)
                    right = mid - 1;
                else
                    left = mid + 1;
            }

            return row[right] == target;
        }
    }
}

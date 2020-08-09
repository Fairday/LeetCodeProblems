using ALGON.LeetCodeProblems.Model;
using System;

namespace ALGON.LeetCodeProblems.Backtracking
{
    /*Given a 2D board and a word, find if the word exists in the grid.
      The word can be constructed from letters of sequentially adjacent cell, where "adjacent" cells are those horizontally or vertically neighboring.The same letter cell may not be used more than once.
      board =
      [
          ['A','B','C','E'],
          ['S','F','C','S'],
          ['A','D','E','E']
        ]

      Given word = "ABCCED", return true.
      Given word = "SEE", return true.
      Given word = "ABCB", return false.
      Constraints:
      1. board and word consists only of lowercase and uppercase English letters.
      2. 1 <= board.length <= 200
      3. 1 <= board[i].length <= 200
      4. 1 <= word.length <= 10^3*/
    public class Solution_79 : SolutionBase
    {
        /// <summary>
        /// Complexity: m * n * 4^K, K - word.Length
        /// </summary>
        /// <param name="board"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool Exist(char[][] board, string word)
        {
            var rows = board.Length;
            var cols = board[0].Length;

            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                    if (dfs(board, r, c, word, 0)) 
                        return true;

            return false;
        }

        bool dfs(char[][] board, int row, int col, string word, int k) 
        {
            var rows = board.Length;
            var cols = board[0].Length;

            if (row < 0 || col < 0 || row >= rows || cols >= col)
                return false;

            if (word[k] == board[row][col]) 
            {
                var temp = board[row][col];
                board[row][col] = '#';
                if (word.Length == k)
                    return true;
                else if (dfs(board, row - 1, col, word, k + 1) ||
                         dfs(board, row + 1, col, word, k + 1) ||
                         dfs(board, row, col + 1, word, k + 1) ||
                         dfs(board, row, col - 1, word, k + 1))
                    return true;
                board[row][col] = temp;
            }

            return false;
        }

        public override bool SolveMe()
        {
            throw new NotImplementedException();
        }
    }
}

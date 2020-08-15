using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.Backtracking
{
    //Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent.

    //A mapping of digit to letters(just like on the telephone buttons) is given below.Note that 1 does not map to any letters.

    //Example:


    //Input: "23"
    //Output: ["ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"].
    //Note:


    //Although the above answer is in lexicographical order, your answer could be in any order you want.
    public class Solution_17
    {
        Dictionary<int, List<char>> map;
        IList<string> result;

        // Time: O(N * 4 ^ N) or O(3^N * 4^M), N digits of 3 letters (2, 3, 4, 5, 6, 8), M - digits of 4 letters (7, 9)
        // Space:
        public IList<string> LetterCombinations(string digits)
        {
            result = new List<string>();

            if (string.IsNullOrEmpty(digits))
                return result;

            map = new Dictionary<int, List<char>>();
            map[2] = new List<char>() { 'a', 'b', 'c' };
            map[3] = new List<char>() { 'd', 'e', 'f' };
            map[4] = new List<char>() { 'g', 'h', 'i' };
            map[5] = new List<char>() { 'j', 'k', 'l' };
            map[6] = new List<char>() { 'm', 'n', 'o' };
            map[7] = new List<char>() { 'p', 'q', 'r', 's' };
            map[8] = new List<char>() { 't', 'u', 'v' };
            map[9] = new List<char>() { 'w', 'x', 'y', 'z' };

            dfs("", 0, digits);

            return result;
        }

        void dfs(string variant, int start, string digits)
        {
            if (variant.Length == digits.Length)
            {
                result.Add(variant);
                return;
            }

            for (int i = start; i < digits.Length; i++)
            {
                var ch = digits[i];
                var letters = map[int.Parse(ch.ToString())];
                for (int j = 0; j < letters.Count; j++)
                {
                    var letter = letters[j];
                    dfs(variant + letter, i + 1, digits);
                }
            }
        }
    }
}

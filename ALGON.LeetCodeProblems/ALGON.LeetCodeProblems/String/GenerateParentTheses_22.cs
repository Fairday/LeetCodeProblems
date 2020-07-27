using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.PString
{
    /*Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.

    For example, given n = 3, a solution set is:

    [
      "((()))",
      "(()())",
      "(())()",
      "()(())",
      "()()()"
    ]*/
    public class Solution_22
    {
        public IList<string> GenerateParenthesis(int n)
        {
            var variants = new List<string>();

            if (n == 0)
                return variants;

            dfs(variants, "(", 1, 1, n * 2);

            return variants;
        }

        void dfs(List<string> variants, string variant, int open, int curr, int n)
        {
            if (curr == n)
            {
                variants.Add(variant);
                return;
            }

            if (open * 2 < n && curr + open < n)
            {
                dfs(variants, variant + "(", open + 1, curr + 1, n);
            }

            if (curr < n && open > 0)
            {
                dfs(variants, variant + ")", open - 1, curr + 1, n);
            }
        }
    }
}

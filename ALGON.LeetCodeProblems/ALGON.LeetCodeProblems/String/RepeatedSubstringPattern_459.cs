using System.Text;

namespace ALGON.LeetCodeProblems.PString
{
    public class Solution_469
    {
        //https://www.geeksforgeeks.org/kmp-algorithm-for-pattern-searching/
        //https://leetcode.com/problems/repeated-substring-pattern/discuss/826251/Java-4-Solutions-or-1-liner-RegEx-or-Two-Pointer-or-twice-s-or-Detailed-Steps
        //Brute force.
        //TC: O(n ^ 2)
        //SC: O(n ^ 2)
        public bool RepeatedSubstringPattern(string s)
        {
            var l = s.Length;

            //O(N / 2) -> O(n)
            for (int i = 1; i <= l / 2; i++)
            {
                if (l % i == 0)
                {
                    var maxRepeats = l / i;
                    string chunk = s.Substring(0, i);
                    var sb = new StringBuilder();

                    // O(n)
                    for (int j = 0; j < maxRepeats; j++)
                        sb.Append(chunk);

                    if (sb.ToString().Equals(s))
                        return true;
                }
            }

            return false;
        }
    }
}

using System.Collections.Generic;
using System.Text;

namespace ALGON.LeetCodeProblems.PString
{
    /*You are given a license key represented as a string S which consists only alphanumeric character and dashes.The string is separated into N+1 groups by N dashes.

    Given a number K, we would want to reformat the strings such that each group contains exactly K characters, except for the first group which could be shorter than K, but still must contain at least one character. Furthermore, there must be a dash inserted between two groups and all lowercase letters should be converted to uppercase.


    Given a non-empty string S and a number K, format the string according to the rules described above.

    Example 1:
    Input: S = "5F3Z-2e-9-w", K = 4


    Output: "5F3Z-2E9W"


    Explanation: The string S has been split into two parts, each part has 4 characters.
    Note that the two extra dashes are not needed and can be removed.
    Example 2:
    Input: S = "2-5g-3-J", K = 2


    Output: "2-5G-3J"


    Explanation: The string S has been split into three parts, each part has 2 characters except the first part as it could be shorter as mentioned above.
    Note:
    The length of string S will not exceed 12,000, and K is a positive integer.
    String S consists only of alphanumerical characters (a-z and/or A-Z and/or 0-9) and dashes(-).
    String S is non-empty.*/
    public class Solution_482
    {
        public string LicenseKeyFormatting1(string S, int K)
        {
            var sb = new StringBuilder();
            var count = K;

            for (int i = S.Length - 1; i >= 0; i--)
            {
                var c = S[i];
                if (c == '-')
                    continue;
                if (count == 0)
                {
                    sb.Insert(0, '-');
                    count = K;
                }
                sb.Insert(0, char.ToUpper(c));
                count--;
            }

            return sb.ToString();
        }

        // O(N), Faster than insert approach in StringBuilder
        public string LicenseKeyFormatting(string S, int K)
        {
            var ld = new List<char>();

            int i = 0;
            for (; i < S.Length; i++)
            {
                if (char.IsLetterOrDigit(S[i]))
                    ld.Add(char.ToUpper(S[i]));
            }

            if (ld.Count == 0)
                return string.Empty;

            var firstGroupLength = (ld.Count % K) == 0 ? K : ld.Count % K;

            i = 0;
            var formatted = new StringBuilder();
            while (i < firstGroupLength)
                formatted.Append(ld[i++]);

            if (i < ld.Count - 1)
                formatted.Append("-");

            int j = 0;
            while (i < ld.Count)
            {
                formatted.Append(ld[i++]);
                j++;

                if (j == K)
                {
                    if (i < ld.Count)
                        formatted.Append("-");
                    j = 0;

                }
            }

            return formatted.ToString();
        }
    }
}

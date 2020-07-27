using System;

namespace ALGON.LeetCodeProblems.String
{
    /*Give a string s, count the number of non-empty(contiguous) substrings that have the same number of 0's and 1's, and all the 0's and all the 1's in these substrings are grouped consecutively.

    Substrings that occur multiple times are counted the number of times they occur.

    Example 1:
    Input: "00110011"
    Output: 6
    Explanation: There are 6 substrings that have equal number of consecutive 1's and 0's: "0011", "01", "1100", "10", "0011", and "01".

    Notice that some of these substrings repeat and are counted the number of times they occur.

    Also, "00110011" is not a valid substring because all the 0's (and 1's) are not grouped together.
    Example 2:
    Input: "10101"
    Output: 4
    Explanation: There are 4 substrings: "10", "01", "10", "01" that have equal number of consecutive 1's and 0's.
    Note:

    s.length will be between 1 and 50,000.
    s will only consist of "0" or "1" characters.*/
    public class Solution_696
    {
        // O(N)
        public int CountBinarySubstrings(string s)
        {
            var groups = new int[s.Length];
            int t = 0;
            groups[0] = 1;

            for (int i = 1; i < s.Length; i++)
            {
                if (s[i - 1] != s[i])
                {
                    //starting new consecutive substring
                    groups[++t] = 1;
                }
                else
                {
                    groups[t]++;
                }
            }

            int ans = 0;
            for (int i = 1; i < groups.Length; i++)
            {
                //Minimum of consecituve, ex: 00110
                //gr[0] = 2
                //gr[1] = 2
                //gr[2] = 1
                ans += Math.Min(groups[i - 1], groups[i]);
            }

            return ans;
        }

        // O(N^2)
        public int CountBinarySubstrings1(string s)
        {
            var start = 0;
            var count = 0;
            while (start <= s.Length - 2)
            {
                var consZeros = 0;
                var consOnes = 0;
                for (int i = start; i < s.Length; i++)
                {
                    if (s[i] == '0')
                    {
                        if (i > 0 && s[i - 1] == '0')
                        {
                            consZeros++;
                        }
                        else if (i > 0 && s[i - 1] == '1' && consZeros > 0)
                        {
                            break;
                        }
                        else
                        {
                            consZeros++;
                        }
                    }
                    else if (s[i] == '1')
                    {
                        if (i > 0 && s[i - 1] == '1')
                        {
                            consOnes++;
                        }
                        else if (i > 0 && s[i - 1] == '0' && consOnes > 0)
                        {
                            break;
                        }
                        else
                        {
                            consOnes++;
                        }
                    }
                    if (consZeros == consOnes)
                        count++;
                }
                start++;
            }
            return count;
        }
    }
}

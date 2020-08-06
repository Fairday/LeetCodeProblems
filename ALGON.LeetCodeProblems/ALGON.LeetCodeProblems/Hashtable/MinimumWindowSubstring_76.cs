using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.Hashtable
{
    /*Given a string S and a string T, find the minimum window in S which will contain all the characters in T in complexity O(n).

    Example:

    Input: S = "ADOBECODEBANC", T = "ABC"
    Output: "BANC"
    Note:

    If there is no such window in S that covers all characters in T, return the empty string "".
    If there is such window, you are guaranteed that there will always be only one unique minimum window in S.*/
    public class Solution_76
    {
        public string MinWindow(string s, string t)
        {
            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t))
                return "";

            var map = new Dictionary<char, int>();

            for (int i = 0; i < t.Length; i++)
            {
                if (map.ContainsKey(t[i]))
                    map[t[i]]++;
                else
                    map[t[i]] = 1;
            }
            var left = 0;
            var minLeft = 0;
            var minLen = s.Length + 1;
            var count = 0;
            // move right bound every time
            // decrease char counter from the map, if current char exists in t.
            for (int r = 0; r < s.Length; r++)
            {
                var c = s[r];
                if (map.ContainsKey(c))
                {
                    // we should update the counter of char in any case
                    // map[c] - it could be less then 0, and this is ok.
                    // Because we could found the same char more then one time in the sliding window.
                    map[c]--;
                    if (map[c] >= 0) count++;
                }

                // if we found all the chars from t, start moving left till we lost some of the chars from t.
                // In this moment we leave the "while" loop and continue moving the right bound till we get all the
                // chars from t again.
                while (count == t.Length)
                {
                    if (r - left + 1 < minLen)
                    {
                        minLeft = left;
                        minLen = r - left + 1;
                    }

                    if (map.ContainsKey(s[left]))
                    {
                        map[s[left]]++;
                        if (map[s[left]] > 0) count--;
                    }

                    left++;
                }
            }

            //a
            //aa
            //case
            if (minLen > s.Length)
                return "";

            return s.Substring(minLeft, minLen);
        }
    }
}

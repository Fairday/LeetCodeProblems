using System;
using System.Collections.Generic;

namespace Day6.SlidingWindow
{
    //Given a string s, find the length of the longest substring without repeating characters.

    //Example 1:

    //Input: s = "abcabcbb"
    //Output: 3
    //Explanation: The answer is "abc", with the length of 3.
    //Example 2:

    //Input: s = "bbbbb"
    //Output: 1
    //Explanation: The answer is "b", with the length of 1.
    //Example 3:

    //Input: s = "pwwkew"
    //Output: 3
    //Explanation: The answer is "wke", with the length of 3.
    //Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
    //Example 4:

    //Input: s = ""
    //Output: 0
 
    //Constraints:

    //0 <= s.length <= 5 * 104
    //s consists of English letters, digits, symbols and spaces.
    public class LongestSubstringWithoutRepeatingCharacters_3
    {
        //TC: O(N^2)
        //SC: O(N^2)
        public int LengthOfLongestSubstring_NaiveApproach(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;

            int max = 0;
            for (int i = 0; i < s.Length; i++)
            {
                HashSet<char> chars = new HashSet<char>();

                for (int j = i; j < s.Length; j++)
                {
                    if (!chars.Add(s[j]))
                        break;
                }
                max = Math.Max(max, chars.Count);
            }

            return max;
        }

        //TC: O(N)
        //SC: O(1)
        public int LengthOfLongestSubstring(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;

            HashSet<char> set = new HashSet<char>();

            int i = 0;
            int j = 0;
            int max = 0;
            while (j < s.Length)
            {
                char c = s[j];
                if (!set.Contains(c))
                {
                    set.Add(c);
                    //move right
                    j++;
                    max = Math.Max(max, set.Count);
                }
                else
                {
                    //move left to unique start
                    set.Remove(s[i]);
                    i++;
                }

            }

            return max;
        }
    }
}
using System;
using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.Backtracking
{
    public class Solution_139
    {
        public bool WordBreak(string s, IList<string> wordDict)
        {
            if (string.IsNullOrEmpty(s) || wordDict == null)
                return false;

            var validStarts = new bool[s.Length + 1];
            validStarts[0] = true;

            var maxLen = 0;
            var wordSet = new HashSet<string>();

            //find max word len
            for (int i = 0; i < wordDict.Count; i++)
            {
                wordSet.Add(wordDict[i]);
                maxLen = Math.Max(maxLen, wordDict[i].Length);
            }

            //find all starts with valid end
            //leetcode, 'leet' 'code'
            //l
            //le
            //lee
            //leet
            //c
            //co
            //cod
            //code
            for (int i = 1; i <= s.Length; i++)
            {
                for (int j = i - 1; j >= i - maxLen && j >= 0; j--)
                {
                    if (!validStarts[j]) continue;
                    var word = s.Substring(j, i - j);
                    if (wordSet.Contains(word))
                    {
                        validStarts[i] = true;
                    }
                }
            }

            return validStarts[s.Length];
        }
    }
}

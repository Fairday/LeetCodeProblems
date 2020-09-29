using System;
using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.Backtracking
{
    //Given a non-empty string s and a dictionary wordDict containing a list of non-empty words, determine if s can be segmented into a space-separated sequence of one or more dictionary words.
    //Note:

    //The same word in the dictionary may be reused multiple times in the segmentation.
    //You may assume the dictionary does not contain duplicate words.
    //Example 1:

    //Input: s = "leetcode", wordDict = ["leet", "code"]
    //Output: true
    //Explanation: Return true because "leetcode" can be segmented as "leet code".
    //Example 2:

    //Input: s = "applepenapple", wordDict = ["apple", "pen"]
    //Output: true
    //Explanation: Return true because "applepenapple" can be segmented as "apple pen apple".
    //             Note that you are allowed to reuse a dictionary word.
    //Example 3:

    //Input: s = "catsandog", wordDict = ["cats", "dog", "sand", "and", "cat"]
    //Output: false
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

            //starts
            for (int i = 1; i <= s.Length; i++)
            {
            	//ends
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

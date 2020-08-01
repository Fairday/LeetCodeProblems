using System;
using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.Backtracking
{
    /// <summary>
    /// Time complexity: O(n * m) + O(n * number of solutions), n - s.Length, m - maxLen
    /// </summary>
    public class Solution_140
    {
        //DP + DFS
        public IList<string> WordBreak(string s, IList<string> wordDict)
        {
            var sentences = new List<string>();
            if (string.IsNullOrEmpty(s) || wordDict == null)
                return sentences;

            var maxLen = 0;
            var wordSet = new HashSet<string>();
            //valid starts
            List<int>[] validStartPositions = new List<int>[s.Length + 1]; 
            validStartPositions[0] = new List<int>();

            //find max word len
            for (int i = 0; i < wordDict.Count; i++)
            {
                wordSet.Add(wordDict[i]);
                maxLen = Math.Max(maxLen, wordDict[i].Length);
            }

            //create start end table, example:
            //catsanddog (end + 1)
            //0 - 3 cat
            //0 - 4 cats
            //3 - 7 sand
            //4 - 7 and
            //7 - 10 - dog
            for (int i = 1; i <= s.Length; i++)
            {
                for (int j = i - 1; j >= i - maxLen && j >= 0; j--)
                {
                    if (validStartPositions[j] == null) continue;
                    var word = s.Substring(j, i - j);
                    if (wordSet.Contains(word))
                    {
                        if (validStartPositions[i] == null)
                        {
                            validStartPositions[i] = new List<int>();
                        }
                        validStartPositions[i].Add(j);
                    }
                }
            }

            //no valid breakable end
            if (validStartPositions[s.Length] == null)
                return sentences;

            //concat all variants
            //10 -> 7 -> 4 -> 0
            //10 -> 7 -> 3 -> 0
            dfs(sentences, s, validStartPositions, "", s.Length);

            return sentences;
        }

        void dfs(IList<string> sentences, string s, List<int>[] validStarts, string path, int end)
        {
            if (end == 0) 
            {
                sentences.Add(path.Substring(1));
                return;
            }

            foreach (var start in validStarts[end])
            {
                string word = s.Substring(start, end - start);
                dfs(sentences, s, validStarts, " " + word + path, start);
            }
        }
    }
}

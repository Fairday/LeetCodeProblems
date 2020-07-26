using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.BinarySearch
{
    /*Given string S and a dictionary of words words, find the number of words[i] that is a subsequence of S.

    Example :
    Input: 
    S = "abcde"
    words = ["a", "bb", "acd", "ace"]
    Output: 3
    Explanation: There are three words in words that are a subsequence of S: "a", "acd", "ace".
    Note:

    All words in words and S will only consists of lowercase letters.
    The length of S will be in the range of[1, 50000].
    The length of words will be in the range of[1, 5000].
    The length of words[i] will be in the range of[1, 50].*/
    public class Solution_792
    {
        public int NumMatchingSubseq(string S, string[] words)
        {
            var charMap = new Dictionary<char, List<int>>();

            for (int i = 0; i < S.Length; i++)
            {
                if (!charMap.ContainsKey(S[i]))
                    charMap[S[i]] = new List<int>();
                charMap[S[i]].Add(i);
            }

            var subsequenceWords = 0;

            for (int i = 0; i < words.Length; i++)
                if (IsSubsequence(charMap, words[i], S))
                    subsequenceWords++;
            return subsequenceWords;
        }

        public bool IsSubsequence(Dictionary<char, List<int>> map, string word, string source)
        {
            if (word.Length > source.Length)
                return false;

            var prevIndex = -1;
            for (int i = 0; i < word.Length; i++)
            {
                if (!map.ContainsKey(word[i]))
                    return false;
                var nextIndex = BinarySearch(map[word[i]], prevIndex);
                if (nextIndex < prevIndex) return false;
                prevIndex = nextIndex;
            }
            return true;
        }

        // Use binary search to find the smallest index of current char
        // Which is greater then index of prev char.
        // We can use binary search because of each list in scanRes is sorted.   
        int BinarySearch(List<int> charPosList, int prevCharIndex)
        {
            int lo = 0;
            int hi = charPosList.Count - 1;
            while (lo <= hi)
            {
                var mid = lo + (hi - lo) / 2;
                if (charPosList[mid] == prevCharIndex)
                {
                    //if mid is a last index in list, that greater index -> return -1; otherwise return next index after mid
                    return mid == charPosList.Count - 1 ? -1 : charPosList[mid + 1];
                }
                if (charPosList[mid] > prevCharIndex)
                {
                    hi = mid - 1;
                }
                else
                {
                    lo = mid + 1;
                }
            }
            if (hi != -1 && charPosList[hi] > prevCharIndex)
                return charPosList[hi];
            else if (hi < charPosList.Count - 1)
                return charPosList[hi + 1];
            else
                return -1;

        }
    }
}

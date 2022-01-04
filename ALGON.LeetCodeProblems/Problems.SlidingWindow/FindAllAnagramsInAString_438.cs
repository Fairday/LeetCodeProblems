using System.Collections.Generic;

namespace Problems.SlidingWindow
{
    //Given two strings s and p, return an array of all the start indices of p's anagrams in s. You may return the answer in any order.

    //An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.

    //Example 1:

    //Input: s = "cbaebabacd", p = "abc"
    //Output: [0,6]
    //    Explanation:
    //The substring with start index = 0 is "cba", which is an anagram of "abc".
    //The substring with start index = 6 is "bac", which is an anagram of "abc".
    //Example 2:

    //Input: s = "abab", p = "ab"
    //Output: [0,1,2]
    //    Explanation:
    //The substring with start index = 0 is "ab", which is an anagram of "ab".
    //The substring with start index = 1 is "ba", which is an anagram of "ab".
    //The substring with start index = 2 is "ab", which is an anagram of "ab".
 
    //Constraints:

    //1 <= s.length, p.length <= 3 * 104
    //s and p consist of lowercase English letters.
    public class FindAllAnagramsInAString_438
    {
        public IList<int> FindAnagrams(string s, string p)
        {
            if (p.Length > s.Length)
                return new List<int>();

            var smap = new int[26];
            var pmap = new int[26];
            for (int i = 0; i < p.Length; i++)
            {
                pmap[p[i] - 'a']++;
                smap[s[i] - 'a']++;
            }

            var res = new List<int>();
            for (int i = 0; i < s.Length - p.Length; i++)
            {
                if (Matches(smap, pmap))
                {
                    res.Add(i);
                }

                smap[s[i + p.Length] - 'a']++;
                smap[s[i] - 'a']--;
            }

            if (Matches(smap, pmap))
                res.Add(s.Length - p.Length);

            return res;
        }

        private bool Matches(int[] arr1, int[] arr2)
        {
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i])
                    return false;
            }

            return true;
        }
    }
}
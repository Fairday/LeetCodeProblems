using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.PString
{
    //Given a string which consists of lowercase or uppercase letters, find the length of the longest palindromes that can be built with those letters.

    //This is case sensitive, for example "Aa" is not considered a palindrome here.

    //Note:
    //Assume the length of given string will not exceed 1,010.

    //Example:

    //Input:
    //"abccccdd"

    //Output:
    //7

    //Explanation:
    //One longest palindrome that can be built is "dccaccd", whose length is 7.
    public class Solution_409
    {
        public int LongestPalindrome(string s)
        {
            if (s.Length == 0)
                return 0;

            Dictionary<char, int> map = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (map.ContainsKey(s[i]))
                    map[s[i]] += 1;
                else
                    map[s[i]] = 1;
            }

            var palindromeLength = 0;
            var values = map.Values.ToList();

            for (int i = 0; i < values.Count; i++)
            {
                palindromeLength += values[i] / 2 * 2;
                //Use possibility of single character, ex: aaa[b]ccc
                if (palindromeLength % 2 == 0 && values[i] % 2 == 1)
                    palindromeLength++;
            }

            return palindromeLength;
        }
    }
}

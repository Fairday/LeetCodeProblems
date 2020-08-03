namespace ALGON.LeetCodeProblems.Hashtable
{
    /*Given two strings s and t, write a function to determine if t is an anagram of s.

    Example 1:

    Input: s = "anagram", t = "nagaram"
    Output: true
    Example 2:


    Input: s = "rat", t = "car"
    Output: false
    Note:
    You may assume the string contains only lowercase alphabets.

    Follow up:
    What if the inputs contain unicode characters? How would you adapt your solution to such case?*/
    public class Solution_242
    {
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
                return false;

            var letters = new int[26];

            foreach (var l in s)
                letters[l - 'a']++;

            foreach (var l in t)
            {
                var count = letters[l - 'a'];

                if (count == 0)
                    return false;

                letters[l - 'a']--;
            }

            return true;
        }
    }
}

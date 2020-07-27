using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.String
{
    /*Given a string, find the first non-repeating character in it and return its index.If it doesn't exist, return -1.

    Examples:

    s = "leetcode"
    return 0.

    s = "loveleetcode"
    return 2.

    Note: You may assume the string contains only lowercase English letters.*/
    public class Solution_387
    {
        Dictionary<char, int> occur;
        Queue<char> q;

        public Solution_387()
        {
            q = new Queue<char>();
            occur = new Dictionary<char, int>();
        }

        public int FirstUniqChar(string s)
        {
            for (int i = 0; i < s.Length; i++)
                Add(s[i]);

            while (q.Count > 0 && occur[q.Peek()] >= 2)
            {
                q.Dequeue();
            }

            if (q.Count == 0)
                return -1;

            return s.IndexOf(q.Dequeue());
        }

        void Add(char c)
        {
            if (occur.ContainsKey(c))
                occur[c]++;
            else
                occur[c] = 1;
            q.Enqueue(c);
        }
    }
}

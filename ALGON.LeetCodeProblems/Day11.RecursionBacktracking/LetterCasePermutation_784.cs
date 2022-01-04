using System.Collections.Generic;
using System.Linq;

namespace Day11.RecursionBacktracking
{
    //Given a string s, we can transform every letter individually to be lowercase or uppercase to create another string.
    //Return a list of all possible strings we could create.You can return the output in any order.

    //Example 1:

    //Input: s = "a1b2"
    //Output: ["a1b2","a1B2","A1b2","A1B2"]
    //Example 2:

    //Input: s = "3z4"
    //Output: ["3z4","3Z4"]
    //Example 3:

    //Input: s = "12345"
    //Output: ["12345"]
    //Example 4:

    //Input: s = "0"
    //Output: ["0"]

    //Constraints:

    //s will be a string with length between 1 and 12.
    //s will consist only of letters or digits.
    public class LetterCasePermutation_784
    {
        //TC: O(2^N)
        //SC: O(2^N)
        public IList<string> LetterCasePermutation_Dfs(string s)
        {
            var res = new List<string>();
            Dfs(res, 0, s.ToCharArray());
            return res;
        }

        //TC: O(2^N)
        //SC: O(2^N)
        public IList<string> LetterCasePermutation_Bfs(string s)
        {
            var q = new Queue<string>();
            q.Enqueue(s);

            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsDigit(s[i]))
                    continue;

                var size = q.Count;
                for (int j = 0; j < size; j++)
                {
                    var v = q.Dequeue();

                    var v1 = v.ToCharArray();
                    v1[i] = char.ToUpper(v1[i]);
                    q.Enqueue(new string(v1));

                    var v2 = v.ToCharArray();
                    v2[i] = char.ToLower(v2[i]);
                    q.Enqueue(new string(v2));
                }
            }

            return q.ToList();
        }

        private void Dfs(List<string> res, int pos, char[] s)
        {
            if (pos == s.Length)
            {
                res.Add(new string(s));
                return;
            }

            if (char.IsDigit(s[pos]))
            {
                Dfs(res, pos + 1, s);
                return;
            }

            s[pos] = char.ToUpper(s[pos]);
            Dfs(res, pos + 1, s);

            s[pos] = char.ToLower(s[pos]);
            Dfs(res, pos + 1, s);
        }
    }
}
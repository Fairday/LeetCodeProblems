using System.Text;

namespace Day4.TwoPointers
{
    //Given a string s, reverse the order of characters in each word within a sentence while still preserving whitespace and initial word order.

    //Example 1:

    //Input: s = "Let's take LeetCode contest"
    //Output: "s'teL ekat edoCteeL tsetnoc"
    //Example 2:

    //Input: s = "God Ding"
    //Output: "doG gniD"
 
    //Constraints:

    //1 <= s.length <= 5 * 104
    //s contains printable ASCII characters.
    //s does not contain any leading or trailing spaces.
    //There is at least one word in s.
    //All the words in s are separated by a single space.
    public class ReverseWordsInAString3_557
    {  
        //TC: O(N)
        //SC: O(N)
        public string ReverseWords(string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;

            string[] parts = s.Split(' ');
            StringBuilder res = new StringBuilder(s.Length);
            foreach (string part in parts)
            {
                res.Append(Reverse(part));
                res.Append(" ");
            }

            res.Remove(s.Length, 1);
            return res.ToString();

        }

        private string Reverse(string s)
        {
            StringBuilder sb = new StringBuilder(s.Length);
            for (int i = s.Length - 1; i >= 0; i--)
                sb.Append(s[i]);
            return sb.ToString();
        }
    }
}
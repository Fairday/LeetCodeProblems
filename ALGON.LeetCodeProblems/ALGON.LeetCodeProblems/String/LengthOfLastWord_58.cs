using System.Text;

namespace ALGON.LeetCodeProblems.String
{
    /*Given a string s consists of upper/lower-case alphabets and empty space characters ' ', return the length of last word(last word means the last appearing word if we loop from left to right) in the string.

    If the last word does not exist, return 0.

    Note: A word is defined as a maximal substring consisting of non-space characters only.

    Example:

    Input: "Hello World"
    Output: 5*/
    public class Solution_58
    {
        public int LengthOfLastWord(string s)
        {
            var sb = new StringBuilder();
            bool wordStarted = false;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] != ' ' && !wordStarted)
                {
                    wordStarted = true;
                    sb.Append(s[i]);
                }
                else if (s[i] != ' ' && wordStarted)
                {
                    sb.Append(s[i]);
                }
                else if (s[i] == ' ' && wordStarted)
                    break;
            }

            return sb.ToString().Length;
        }
    }
}

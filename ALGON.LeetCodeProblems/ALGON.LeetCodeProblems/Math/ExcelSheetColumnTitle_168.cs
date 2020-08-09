using System.Linq;
using System.Text;

namespace ALGON.LeetCodeProblems.PMath
{
    /*Given a positive integer, return its corresponding column title as appear in an Excel sheet.

    For example:

        1 -> A
        2 -> B
        3 -> C
        ...
        26 -> Z
        27 -> AA
        28 -> AB
        ...
    Example 1:

    Input: 1
    Output: "A"
    Example 2:

    Input: 28
    Output: "AB"
    Example 3:

    Input: 701
    Output: "ZY"*/
    public class Solution_168
    {
        public string ConvertToTitle(int n)
        {
            var res = new StringBuilder();
            while (n > 0)
            {
                if (n % 26 == 0)
                    res.Append('Z');
                else
                    res.Append((char)('A' + n % 26 - 1));
                n--;
                n /= 26;
            }
            return new string(res.ToString().Reverse().ToArray());
        }
    }
}

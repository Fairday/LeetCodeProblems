namespace ALGON.LeetCodeProblems.PMath
{
    /*Given a column title as appear in an Excel sheet, return its corresponding column number.

    For example:

        A -> 1
        B -> 2
        C -> 3
        ...
        Z -> 26
        AA -> 27
        AB -> 28 
        ...
    Example 1:

    Input: "A"
    Output: 1
    Example 2:

    Input: "AB"
    Output: 28
    Example 3:

    Input: "ZY"
    Output: 701

    Constraints:

    1 <= s.length <= 7
    s consists only of uppercase English letters.
    s is between "A" and "FXSHRXW".*/
    public class Solution_171
    {
        public int TitleToNumber(string s)
        {
            var number = 0;
            for (int i = 0; i < s.Length; i++)
            {
                var ch = s[i];
                var num = ch - 'A' + 1;
                if (number != 0)
                {
                    number *= 26;
                }
                number += num;
            }
            return number;
        }
    }
}

using System;

namespace ALGON.LeetCodeProblems.PString
{
    /*Given a string, determine if it is a palindrome, considering only alphanumeric characters and ignoring cases.

    Note: For the purpose of this problem, we define empty string as valid palindrome.

    Example 1:

    Input: "A man, a plan, a canal: Panama"
    Output: true
    Example 2:

    Input: "race a car"
    Output: false



    Constraints:

    s consists only of printable ASCII characters.*/
    public class Solution_125
    {
        public bool IsPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s))
                return true;

            var start = 0;
            var end = s.Length - 1;

            while (start < end)
            {
                var left = s[start];
                var right = s[end];

                while (start < end && !char.IsLetterOrDigit(left))
                    left = s[++start];

                while (start < end && !char.IsLetterOrDigit(right))
                    right = s[--end];

                if (Char.ToLower(left) != Char.ToLower(right))
                    return false;

                start++;
                end--;
            }

            return true;
        }
    }
}

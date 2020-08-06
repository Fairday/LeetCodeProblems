using System.Linq;
using System.Text;

namespace ALGON.LeetCodeProblems.PMath
{
    /*Given two non-negative integers num1 and num2 represented as string, return the sum of num1 and num2.

    Note:

    The length of both num1 and num2 is < 5100.
    Both num1 and num2 contains only digits 0-9.
    Both num1 and num2 does not contain any leading zero.
    You must not use any built-in BigInteger library or convert the inputs to integer directly.*/
    public class Solution_415
    {
        public string AddStrings(string num1, string num2)
        {
            int carry = 0;
            int p1 = num1.Length - 1;
            int p2 = num2.Length - 1;
            var res = new StringBuilder();
            while (p1 >= 0 || p2 >= 0)
            {
                int x1 = p1 >= 0 ? num1[p1] - '0' : 0;
                int x2 = p2 >= 0 ? num2[p2] - '0' : 0;
                var v = (x1 + x2 + carry) % 10;
                res.Append(v);
                carry = (x1 + x2 + carry) / 10;
                p1--;
                p2--;
            }

            if (carry != 0)
                res.Append(carry);

            return new string(res.ToString().Reverse().ToArray());
        }
    }
}

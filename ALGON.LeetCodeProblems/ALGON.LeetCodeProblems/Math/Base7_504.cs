using System;
using System.Linq;
using System.Text;

namespace ALGON.LeetCodeProblems.PMath
{
    public class Solution_504
    {
        public string ConvertToBase7(int num)
        {
            if (num == 0)
                return "0";

            var res = new StringBuilder();

            var sign = Math.Sign(num);

            num = Math.Abs(num);

            while (num > 0)
            {
                var remainder = num % 7;
                res.Append(remainder);
                num = num / 7;
            }

            if (sign == -1)
                res.Append("-");

            return new string(res.ToString().Reverse().ToArray());
        }
    }
}

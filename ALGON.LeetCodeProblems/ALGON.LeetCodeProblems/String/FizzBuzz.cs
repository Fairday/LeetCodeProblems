using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.String
{
    /*Write a program that outputs the string representation of numbers from 1 to n.

    But for multiples of three it should output “Fizz” instead of the number and for the multiples of five output “Buzz”. For numbers which are multiples of both three and five output “FizzBuzz”.

    Example:

    n = 15,

    Return:
    [
        "1",
        "2",
        "Fizz",
        "4",
        "Buzz",
        "Fizz",
        "7",
        "8",
        "Fizz",
        "Buzz",
        "11",
        "Fizz",
        "13",
        "14",
        "FizzBuzz"
    ]*/
    public class Solution_412
    {
        public IList<string> FizzBuzz(int n)
        {
            var output = new List<string>();

            for (int i = 1; i <= n; i++)
            {
                string s = "";
                if (i % 3 == 0)
                    s += "Fizz";
                if (i % 5 == 0)
                    s += "Buzz";
                if (s == "")
                    s = i.ToString();
                output.Add(s);
            }

            return output;
        }
    }
}

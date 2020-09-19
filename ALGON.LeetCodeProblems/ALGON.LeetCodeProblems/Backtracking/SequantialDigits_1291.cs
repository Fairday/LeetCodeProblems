using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.Backtracking
{
    //An integer has sequential digits if and only if each digit in the number is one more than the previous digit.

    //Return a sorted list of all the integers in the range [low, high] inclusive that have sequential digits.

    //Example 1:

    //Input: low = 100, high = 300
    //Output: [123,234]
    //Example 2:

    //Input: low = 1000, high = 13000
    //Output: [1234,2345,3456,4567,5678,6789,12345]


    //Constraints:

    //10 <= low <= high <= 10^9
    public class Solution_1291
    {
        //TC: O(n logn)
        //SC: O(n) in sort + recursive stack
        public IList<int> SequentialDigits(int low, int high)
        {
            var integers = new List<int>();

            //9 o(n)
            for (int i = 1; i <= 9; i++)
                dfs(integers, low, high, i.ToString(), i);

            //n logn
            integers.Sort();

            return integers;
        }

        void dfs(IList<int> integers, int low, int high, string subnumber, int lastDigit)
        {
            var number = int.Parse(subnumber);

            if (number >= low && number <= high)
                integers.Add(number);

            if (number < high && lastDigit < 9)
            {
                subnumber += (lastDigit + 1).ToString();
                dfs(integers, low, high, subnumber, lastDigit + 1);
            }
        }
    }
}

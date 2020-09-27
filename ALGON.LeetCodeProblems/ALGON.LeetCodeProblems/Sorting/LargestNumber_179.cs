using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALGON.LeetCodeProblems.Sorting
{
    //Given a list of non negative integers, arrange them such that they form the largest number.

    //Example 1:

    //Input: [10,2]
    //    Output: "210"
    //Example 2:

    //Input: [3,30,34,5,9]
    //    Output: "9534330"
    //Note: The result may be very large, so you need to return a string instead of an integer.
    public class Solution_179
    {
        //TC: O(nlogn)
        //SC: O(n)
        public string LargestNumber(int[] nums)
        {
            var numsAsString = nums.Select(n => n.ToString()).ToArray();
            var ans = new StringBuilder();

            Array.Sort(numsAsString, new CustomStringComparer());

            if (numsAsString[0].Equals("0"))
                return "0";

            for (int i = 0; i < nums.Length; i++)
                ans.Append(numsAsString[i]);
            return ans.ToString();
        }
    }

    public class CustomStringComparer : IComparer<string>
    {
        //3, 30
        //order1=303
        //order2=330
        public int Compare(string x, string y)
        {
            var order1 = x + y;
            var order2 = y + x;
            return order2.CompareTo(order1);
        }
    }
}

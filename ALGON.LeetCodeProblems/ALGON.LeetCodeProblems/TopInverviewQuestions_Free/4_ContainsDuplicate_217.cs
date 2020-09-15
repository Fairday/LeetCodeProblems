using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.TopInverviewQuestions_Free
{
    /*Given an array of integers, find if the array contains any duplicates.

    Your function should return true if any value appears at least twice in the array, and it should return false if every element is distinct.

    Example 1:

    Input: [1,2,3,1]
        Output: true
    Example 2:

    Input: [1,2,3,4]
        Output: false
    Example 3:

    Input: [1,1,1,3,3,4,3,2,4,2]
    Output: true*/
    public class Solution_217
    {
        //TC: O(n)
        //SC: O(n)
        public bool ContainsDuplicate(int[] nums)
        {
            var hs = new HashSet<int>();

            foreach (var num in nums)
            {
                if (!hs.Add(num))
                    return true;
            }

            return false;
        }
    }
}

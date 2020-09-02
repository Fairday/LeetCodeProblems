using System;

namespace ALGON.LeetCodeProblems.PMath
{
    //Given an array of 4 digits, return the largest 24 hour time that can be made.

    //The smallest 24 hour time is 00:00, and the largest is 23:59.  Starting from 00:00, a time is larger if more time has elapsed since midnight.

    //Return the answer as a string of length 5.  If no valid time can be made, return an empty string.

    //Example 1:

    //Input: [1,2,3,4]
    //Output: "23:41"
    //Example 2:

    //Input: [5,5,5,5]
    //Output: ""

    //Note:

    //A.length == 4
    //0 <= A[i] <= 9
    public class Solution_949
    {
        int maxTime = -1;

        //TC^ O(n!), but n is constant that equal 4, so TC -> O(1), SC -> O(1)
        public string LargestTimeFromDigits(int[] A)
        {
            Permute(A, 0);
            if (maxTime == -1)
                return string.Empty;
            else
                return TimeSpan.FromHours(maxTime / 60).ToString("hh") + ":" + TimeSpan.FromMinutes(maxTime % 60).ToString("mm");
        }

        void Permute(int[] A, int start)
        {
            if (A.Length == start)
            {
                BuildTime(A);
            }

            for (int i = start; i < A.Length; i++)
            {
                Swap(A, start, i);
                Permute(A, start + 1);
                Swap(A, start, i);
            }
        }

        void BuildTime(int[] pm)
        {
            var hour = pm[0] * 10 + pm[1];
            var min = pm[2] * 10 + pm[3];
            if (hour < 24 && min < 60)
                maxTime = Math.Max(maxTime, hour * 60 + min);
        }

        void Swap(int[] arr, int i, int j)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}

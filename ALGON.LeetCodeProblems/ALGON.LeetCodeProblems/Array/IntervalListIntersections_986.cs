using System;
using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.PArray
{
    //Given two lists of closed intervals, each list of intervals is pairwise disjoint and in sorted order.

    //Return the intersection of these two interval lists.

    //(Formally, a closed interval [a, b] (with a <= b) denotes the set of real numbers x with a <= x <= b.The intersection of two closed intervals is a set of real numbers that is either empty, or can be represented as a closed interval.For example, the intersection of[1, 3] and[2, 4] is [2, 3].)

    //Example 1:

    //Input: A = [[0,2],[5,10],[13,23],[24,25]], B = [[1,5],[8,12],[15,24],[25,26]]
    //Output: [[1,2],[5,5],[8,10],[15,23],[24,24],[25,25]]

    //Note:

    //0 <= A.length< 1000
    //0 <= B.length< 1000
    //0 <= A[i].start, A[i].end, B[i].start, B[i].end< 10^9
    public class Solution_986
    {
        // O (A.Length + B.Length)
        public int[][] IntervalIntersection(int[][] A, int[][] B)
        {
            var i = 0;
            var j = 0;
            var ans = new List<int[]>();

            while (i < A.Length && j < B.Length)
            {
                //intersection of 2 intervals
                var lo = Math.Max(A[i][0], B[j][0]);
                var hi = Math.Min(A[i][1], B[j][1]);

                if (lo <= hi)
                    ans.Add(new int[] { lo, hi });

                if (A[i][1] < B[j][1])
                    i++;
                else
                    j++;
            }

            return ans.ToArray();
        }
    }
}

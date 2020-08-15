using System;

namespace ALGON.LeetCodeProblems.PArray
{
    //Given a collection of intervals, find the minimum number of intervals you need to remove to make the rest of the intervals non-overlapping.

    //Example 1:

    //Input: [[1,2],[2,3],[3,4],[1,3]]
    //Output: 1
    //Explanation: [1,3] can be removed and the rest of intervals are non-overlapping.
    //Example 2:

    //Input: [[1,2],[1,2],[1,2]]
    //Output: 2
    //Explanation: You need to remove two[1, 2] to make the rest of intervals non-overlapping.
    //Example 3:

    //Input: [[1,2],[2,3]]
    //Output: 0
    //Explanation: You don't need to remove any of the intervals since they're already non-overlapping.


    //Note:

    //You may assume the interval's end point is always bigger than its start point.
    //Intervals like[1, 2] and[2, 3] have borders "touching" but they don't overlap each other.
    //This problem is solved with greedy approach first we need to sort the intervals based on[some] criterial and the choose maximum intervals which are not overlaps.

    //First we will sort the intervals using Arrays.sort method and custom comparator.

    //Sort intervals smaller end first and if end same them sort bigger start first.
    //Start prevEnd with -Inf and just compare start of current interval with prevEnd and take action
    //if prevEnd > start --> increment minErase
    //else update prevEnd = end
    //intervals[][] = [[1,2],[2,3],[3,4],[-100,3],[5,7]]

    //after sorting
    //intervals[][] = [[1,2],[2,3],[-100,3],[3,4],[5,7]]

    //minErase = 0;
    //prevEnd = Integer.MIN_VALUE

    //compare for interval[1, 2] prevEnd<start => prevEnd = end = 2, minErase = 0
    //compare for interval [2,3] prevEnd < start => prevEnd = end = 3, minErase = 0
    //compare for interval [-100,3] prevEnd > start => prevEnd = 3, minErase = 1
    //compare for interval[3, 4] prevEnd < start => prevEnd = end = 4, minErase = 1
    //compare for interval[5, 7] prevEnd < start => prevEnd = end = 7, minErase = 1
    public class Solution_435
    {
        public int EraseOverlapIntervals(int[][] intervals)
        {
            //Main idea: we need to skip bigger intervals that contains short non overlapping intervals
            //Sort by end, if end(a) == end(b) -> sort descending by start
            Array.Sort(intervals, (a, b) => a[1] == b[1] ? b[0] - a[0] : a[1] - b[1]);
            var minErase = 0;
            var prevEnd = Int32.MinValue;

            foreach (var interval in intervals)
            {
                if (prevEnd > interval[0])
                    minErase++;
                else
                    prevEnd = interval[1];
            }

            return minErase;
        }
    }
}

using System;
using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.Array
{
    //Given a set of non-overlapping intervals, insert a new interval into the intervals(merge if necessary).

    //You may assume that the intervals were initially sorted according to their start times.

    //Example 1:

    //Input: intervals = [[1, 3], [6,9]], newInterval = [2,5]
    //    Output: [[1,5],[6,9]]
    //Example 2:

    //Input: intervals = [[1,2],[3,5],[6,7],[8,10],[12,16]], newInterval = [4,8]
    //    Output: [[1,2],[3,10],[12,16]]
    //Explanation: Because the new interval[4, 8] overlaps with[3, 5],[6,7],[8,10].
    //Example 3:

    //Input: intervals = [], newInterval = [5,7]
    //    Output: [[5,7]]
    //Example 4:

    //Input: intervals = [[1,5]], newInterval = [2,3]
    //    Output: [[1,5]]
    //Example 5:

    //Input: intervals = [[1,5]], newInterval = [2,7]
    //    Output: [[1,7]]
 

    //Constraints:

    //0 <= intervals.length <= 104
    //intervals[i].length == 2
    //0 <= intervals[i][0] <= intervals[i][1] <= 105
    //intervals is sorted by intervals[i][0] in ascending order.
    //newInterval.length == 2
    //0 <= newInterval[0] <= newInterval[1] <= 105
    public class Solution_57
    {
        //TC: O(N), SC: O(N) - answer
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            var ans = new List<int[]>(intervals.Length + 1);

            foreach (var interval in intervals)
            {
                if (interval[1] < newInterval[0])
                    ans.Add(interval);
                else if (interval[0] > newInterval[1])
                {
                    ans.Add(newInterval);
                    newInterval = interval;
                }
                else
                {
                    newInterval[0] = Math.Min(interval[0], newInterval[0]);
                    newInterval[1] = Math.Max(interval[1], newInterval[1]);
                }
            }
            ans.Add(newInterval);

            return ans.ToArray();
        }

        //TC: O(N), SC: O(N) - answer
        public int[][] Insert1(int[][] intervals, int[] newInterval)
        {
            var newIntervalStart = newInterval[0];
            var newIntervalEnd = newInterval[1];

            //TC: O(N), SC: O(1)
            int[] intervalOfNewIntervalStartIn = In(intervals, newIntervalStart);
            //TC: O(N), SC: O(1)
            int[] intervalOfNewIntervalEndIn = In(intervals, newIntervalEnd);

            if (intervalOfNewIntervalStartIn == null)
                intervalOfNewIntervalStartIn = new int[] { newInterval[0] };

            if (intervalOfNewIntervalEndIn == null)
                intervalOfNewIntervalEndIn = new int[] { 0, newInterval[1] };

            var ans = new List<int[]>();

            //O(N)
            foreach (var interval in intervals)
            {
                if (interval[1] < intervalOfNewIntervalStartIn[0])
                    ans.Add(interval);
                else
                    break;
            }

            ans.Add(new int[] { intervalOfNewIntervalStartIn[0], intervalOfNewIntervalEndIn[1] });

            //O(N)
            foreach (var interval in intervals)
            {
                if (interval[0] > intervalOfNewIntervalEndIn[1])
                    ans.Add(interval);
            }

            return ans.ToArray();
        }

        int[] In(int[][] intervals, int v)
        {
            int[] intervalOfNewIntervalIn = null;

            for (int i = 0; i < intervals.Length; i++)
            {
                var interval = intervals[i];

                if (In(interval, v))
                {
                    intervalOfNewIntervalIn = interval;
                    break;
                }
            }

            return intervalOfNewIntervalIn;
        }

        bool In(int[] interval, int v)
            => interval[0] <= v && interval[1] >= v;
    }

}

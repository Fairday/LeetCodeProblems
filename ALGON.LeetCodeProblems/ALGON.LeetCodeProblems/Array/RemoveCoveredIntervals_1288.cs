using System;
using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.PArray
{
    //Given a list of intervals, remove all intervals that are covered by another interval in the list.

    //Interval [a, b) is covered by interval[c, d) if and only if c <= a and b <= d.

    // After doing so, return the number of remaining intervals.

    // Example 1:

    //Input: intervals = [[1, 4],[3, 6],[2,8]]
    //Output: 2
    //Explanation: Interval[3, 6] is covered by[2, 8], therefore it is removed.
    //Example 2:

    //Input: intervals = [[1,4],[2,3]]
    //Output: 1
    //Example 3:

    //Input: intervals = [[0,10],[5,12]]
    //Output: 2
    //Example 4:

    //Input: intervals = [[3,10],[4,10],[5,11]]
    //Output: 2
    //Example 5:

    //Input: intervals = [[1,2],[1,4],[3,4]]
    //Output: 1


    //Constraints:

    //1 <= intervals.length <= 1000
    //intervals[i].length == 2
    //0 <= intervals[i][0] < intervals[i][1] <= 10^5
    //All the intervals are unique.
    public class Solution_1288
    {
        //TC: O(N^2)
        //SC: O(N)
        //Brute force
        public int RemoveCoveredIntervals1(int[][] intervals)
        {
            var deletedIntervals = new HashSet<int[]>();

            var deleted = 0;
            foreach (var a in intervals)
                foreach (var b in intervals)
                    if (a != b && IsCoveredBy(a, b) && deletedIntervals.Add(b))
                        deleted += 1;
            return intervals.Length - deleted;
        }

        bool IsCoveredBy(int[] a, int[] b)
        {
            return a[0] <= b[0] && b[1] <= a[1];
        }

        //TC: O(nlogn)
        //SC: O(1)
        //Count overlap
        public int RemoveCoveredIntervals2(int[][] intervals)
        {
            Array.Sort(intervals, (a, b) => a[0] - b[0]);
            int[] currInt = { -1, -1 };
            var overlap = 0;
            foreach (var interval in intervals)
            {
                //interval in currInt
                if (currInt[0] <= interval[0] && currInt[1] >= interval[1])
                    overlap++;
                else
                {
                    //currInt in interval
                    if (currInt[0] >= interval[0] && currInt[1] <= interval[1])
                        overlap++;
                    currInt = interval;
                }
            }
            return intervals.Length - overlap;
        }

        //TC: O(nlogn)
        //SC: O(1)
        //Count non-overlap 
        public int RemoveCoveredIntervals(int[][] intervals)
        {
            Array.Sort(intervals, (a, b) => a[0] - b[0]);
            int[] currInt = { -1, -1 };
            var non_overlap = 0;
            foreach (var interval in intervals)
            {
                //currInt not overlapped with next interval
                if (currInt[0] < interval[0] && currInt[1] < interval[1])
                {
                    currInt[0] = interval[0];
                    non_overlap++;
                }

                currInt[1] = Math.Max(currInt[1], interval[1]);
            }
            return non_overlap;
        }
    }
}

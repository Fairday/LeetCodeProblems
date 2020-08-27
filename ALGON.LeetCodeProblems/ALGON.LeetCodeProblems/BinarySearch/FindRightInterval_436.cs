using System;
using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.BinarySearch
{
    //Given a set of intervals, for each of the interval i, check if there exists an interval j whose start point is bigger than or equal to the end point of the interval i, which can be called that j is on the "right" of i.

    //For any interval i, you need to store the minimum interval j's index, which means that the interval j has the minimum start point to build the "right" relationship for interval i. If the interval j doesn't exist, store -1 for the interval i.Finally, you need output the stored value of each interval as an array.

    //Note:

    //You may assume the interval's end point is always bigger than its start point.
    //You may assume none of these intervals have the same start point.



    //Example 1:

    //Input: [ [1,2] ]

    //Output: [-1]

    //    Explanation: There is only one interval in the collection, so it outputs -1.


    //Example 2:

    //Input: [ [3,4], [2,3], [1,2] ]

    //Output: [-1, 0, 1]

    //    Explanation: There is no satisfied "right" interval for [3,4].
    //For[2, 3], the interval[3, 4] has minimum-"right" start point;
    //    For[1, 2], the interval[2, 3] has minimum-"right" start point.


    //    Example 3:

    //Input: [ [1,4], [2,3], [3,4] ]

    //Output: [-1, 2, -1]

    //    Explanation: There is no satisfied "right" interval for [1,4] and[3, 4].
    //For[2, 3], the interval[3, 4] has minimum-"right" start point.
    //NOTE: input types have been changed on April 15, 2019. Please reset to default code definition to get new method signature.
    public class Solution_436
    {
        //TC: O(N logN), SC: O(N) for dict
        public int[] FindRightInterval(int[][] intervals)
        {
            int[] answer = new int[intervals.Length];

            //Store off where intervals existed prior to sorting so that we can use the original incides in the answer array
            Dictionary<int, int> index = new Dictionary<int, int>();
            for (int i = 0; i < intervals.Length; i++)
            {
                index[intervals[i][0]] = i;
            }

            //Sort by the start point of the interval because what we want to do for any given interval 'i' is binary search for an interval 'j' that starts to the right of 'i'
            Array.Sort(intervals, (a, b) => a[0] - b[0]);

            //For every interval, simply binary search for a valid right interval. If one is found, store of the original index of that interval 'j' in the spot of the original index for interval 'i'
            //Otherwise, store -1 for no valid right interval
            for (int i = 0; i < intervals.Length; i++)
            {
                int search = intervals[i][1];
                int l = 0;
                int r = intervals.Length;
                int m;
                while (l < r)
                {
                    m = l + (r - l) / 2;
                    if (intervals[m][0] < search)
                    {
                        l = m + 1;
                    }
                    else
                    {
                        r = m;
                    }
                }
                if (l < intervals.Length && intervals[l][0] >= search)
                {
                    answer[index[intervals[i][0]]] = index[intervals[l][0]];
                }
                else
                {
                    answer[index[intervals[i][0]]] = -1;
                }
            }

            return answer;
        }

        // Primitive O(N^2) TC solution, SC: O(N)
        public int[] FindRightInterval1(int[][] intervals)
        {
            var length = intervals.Length;
            var minRigtsIndexes = new int[length];
            var minRigts = new int[length];

            for (int i = 0; i < length; i++)
            {
                var a = intervals[i];
                minRigtsIndexes[i] = -1;
                minRigts[i] = -1;

                for (int j = 0; j < length; j++)
                {
                    var b = intervals[j];

                    if (a == b)
                        continue;

                    if (b[0] >= a[1])
                    {
                        if (minRigtsIndexes[i] < 0)
                        {
                            minRigtsIndexes[i] = j;
                            minRigts[i] = b[0];
                        }
                        else
                        {
                            if (b[0] < minRigts[i])
                            {
                                minRigts[i] = b[0];
                                minRigtsIndexes[i] = j;
                            }
                        }
                    }
                }
            }

            return minRigtsIndexes;
        }
    }
}

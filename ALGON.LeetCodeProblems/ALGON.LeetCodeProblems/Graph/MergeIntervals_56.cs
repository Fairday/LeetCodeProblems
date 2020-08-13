using System;
using System.Collections.Generic;
using System.Linq;

namespace ALGON.LeetCodeProblems.Graph
{
    //Given a collection of intervals, merge all overlapping intervals.

    //Example 1:

    //Input: intervals = [[1, 3], [2,6], [8,10], [15,18]]
    //Output: [[1,6],[8,10],[15,18]]
    //Explanation: Since intervals[1, 3] and[2, 6] overlaps, merge them into[1, 6].
    //Example 2:

    //Input: intervals = [[1,4],[4,5]]
    //Output: [[1,5]]
    //Explanation: Intervals[1, 4] and[4, 5] are considered overlapping.
    //NOTE: input types have been changed on April 15, 2019. Please reset to default code definition to get new method signature.



    //Constraints:

    //intervals[i][0] <= intervals[i][1]
    public class Solution_56
    {
        public int[][] Merge(int[][] intervals)
        {
            Array.Sort(intervals, (a, b) => a[0] < b[0] ? -1 : (a[0] == b[0] ? 0 : 1));
            var merged = new List<int[]>();

            foreach (var interval in intervals)
            {
                if (merged.Count == 0 || merged.Last()[1] < interval[0])
                    merged.Add(interval);
                else
                    merged.Last()[1] = Math.Max(merged.Last()[1], interval[1]);
            }

            return merged.ToArray();
        }

        Dictionary<int[], List<int[]>> Graph;
        Dictionary<int, List<int[]>> SCC;

        // Time: O(N^2)
        // Space: O(N^2)
        public int[][] Merge1(int[][] intervals)
        {
            BuildGraph(intervals);
            BuildComponents(intervals);

            var merged = new List<int[]>();

            for (int comp = 0; comp < SCC.Count; comp++)
            {
                var interval = MergeNodes(SCC[comp]);
                merged.Add(interval);
            }

            return merged.ToArray();
        }

        int[] MergeNodes(List<int[]> nodes)
        {
            var minStart = nodes[0][0];
            foreach (var node in nodes)
                minStart = Math.Min(minStart, node[0]);

            var maxEnd = nodes[0][1];
            foreach (var node in nodes)
                maxEnd = Math.Max(maxEnd, node[1]);

            return new int[] { minStart, maxEnd };
        }

        void BuildGraph(int[][] intervals)
        {
            Graph = new Dictionary<int[], List<int[]>>();

            foreach (var interval in intervals)
                Graph[interval] = new List<int[]>();

            foreach (var interval1 in intervals)
                foreach (var interval2 in intervals)
                {
                    if (Overlap(interval1, interval2))
                    {
                        Graph[interval1].Add(interval2);
                        Graph[interval2].Add(interval1);
                    }
                }
        }

        void MarkComponents(int[] interval, int componentNumber, HashSet<int[]> visited)
        {
            var queue = new Queue<int[]>();
            queue.Enqueue(interval);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (visited.Add(node))
                {
                    if (!SCC.ContainsKey(componentNumber))
                    {
                        SCC[componentNumber] = new List<int[]>();
                    }

                    SCC[componentNumber].Add(node);

                    foreach (var childInterval in Graph[node])
                        queue.Enqueue(childInterval);
                }
            }
        }

        void BuildComponents(int[][] intervals)
        {
            SCC = new Dictionary<int, List<int[]>>();
            var visited = new HashSet<int[]>();
            var componentNumber = 0;

            foreach (var interval in intervals)
            {
                if (!visited.Contains(interval))
                {
                    MarkComponents(interval, componentNumber, visited);
                    componentNumber++;
                }
            }
        }

        bool Overlap(int[] a, int[] b)
        {
            return a[1] >= b[0] && a[0] <= b[1];
        }
    }
}

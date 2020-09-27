using System;
using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.Greedy
{
    public class Solution_1094
    {
        //TC: O(N^2)
        //SC: O(1)
        public bool CarPooling1(int[][] trips, int capacity)
        {
            var start = Int32.MaxValue;
            var end = 0;

            foreach (var trip in trips)
            {
                if (trip[1] < start)
                    start = trip[1];
                if (trip[2] > end)
                    end = trip[2];
            }

            for (int i = start; i <= end; i++)
            {
                var available = capacity;
                foreach (var trip in trips)
                {
                    if (trip[1] <= i && i < trip[2])
                        available -= trip[0];
                }

                if (available < 0)
                    return false;
            }

            return true;
        }


        //TC: O(nlogn)
        //SC: O(n)
        //https://leetcode.com/problems/car-pooling/solution/
        public bool CarPooling(int[][] trips, int capacity)
        {
            //BST
            var timestamp = new SortedDictionary<int, int>();

            foreach (var trip in trips)
            {
                var start = GetOrDefault(timestamp, trip[1]) + trip[0];
                timestamp[trip[1]] = start;

                var end = GetOrDefault(timestamp, trip[2]) - trip[0];
                timestamp[trip[2]] = end;
            }

            var usedCapacity = 0;
            foreach (var psChange in timestamp.Values)
            {
                usedCapacity += psChange;
                if (usedCapacity > capacity)
                    return false;
            }

            return true;
        }

        int GetOrDefault(SortedDictionary<int, int> map, int key)
        {
            if (map.ContainsKey(key))
                return map[key];
            else
                return 0;
        }
    }
}

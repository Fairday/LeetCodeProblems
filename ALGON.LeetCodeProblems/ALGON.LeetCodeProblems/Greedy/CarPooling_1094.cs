using System;
using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.Greedy
{
    //You are driving a vehicle that has capacity empty seats initially available for passengers.The vehicle only drives east(ie.it cannot turn around and drive west.)

    //Given a list of trips, trip[i] = [num_passengers, start_location, end_location] contains information about the i-th trip: the number of passengers that must be picked up, and the locations to pick them up and drop them off.The locations are given as the number of kilometers due east from your vehicle's initial location.

    //Return true if and only if it is possible to pick up and drop off all passengers for all the given trips.

    //Example 1:

    //Input: trips = [[2, 1, 5], [3,3,7]], capacity = 4
    //Output: false
    //Example 2:

    //Input: trips = [[2,1,5],[3,3,7]], capacity = 5
    //Output: true
    //Example 3:

    //Input: trips = [[2,1,5],[3,5,7]], capacity = 3
    //Output: true
    //Example 4:

    //Input: trips = [[3,2,7],[3,7,9],[8,3,9]], capacity = 11
    //Output: true
 
 

    //Constraints:

    //trips.length <= 1000
    //trips[i].length == 3
    //1 <= trips[i][0] <= 100
    //0 <= trips[i][1] < trips[i][2] <= 1000
    //1 <= capacity <= 100000
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

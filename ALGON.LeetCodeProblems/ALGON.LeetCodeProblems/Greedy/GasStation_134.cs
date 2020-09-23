using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.Greedy
{
    //There are N gas stations along a circular route, where the amount of gas at station i is gas[i].

    //You have a car with an unlimited gas tank and it costs cost[i] of gas to travel from station i to its next station(i+1). You begin the journey with an empty tank at one of the gas stations.

    //Return the starting gas station's index if you can travel around the circuit once in the clockwise direction, otherwise return -1.


    //Note:


    //If there exists a solution, it is guaranteed to be unique.
    //Both input arrays are non-empty and have the same length.
    //Each element in the input arrays is a non-negative integer.
    //Example 1:


    //Input: 
    //gas  = [1, 2, 3, 4, 5]
    //cost = [3, 4, 5, 1, 2]


    //Output: 3


    //Explanation:
    //Start at station 3 (index 3) and fill up with 4 unit of gas.Your tank = 0 + 4 = 4
    //Travel to station 4. Your tank = 4 - 1 + 5 = 8
    //Travel to station 0. Your tank = 8 - 2 + 1 = 7
    //Travel to station 1. Your tank = 7 - 3 + 2 = 6
    //Travel to station 2. Your tank = 6 - 4 + 3 = 5
    //Travel to station 3. The cost is 5. Your gas is just enough to travel back to station 3.
    //Therefore, return 3 as the starting index.
    //Example 2:

    //Input: 
    //gas  = [2,3,4]
    //    cost = [3,4,3]

    //    Output: -1

    //Explanation:
    //You can't start at station 0 or 1, as there is not enough gas to travel to the next station.
    //Let's start at station 2 and fill up with 4 unit of gas. Your tank = 0 + 4 = 4
    //Travel to station 0. Your tank = 4 - 3 + 2 = 3
    //Travel to station 1. Your tank = 3 - 3 + 3 = 3
    //You cannot travel back to station 2, as it requires 4 unit of gas but you only have 3.
    //Therefore, you can't travel around the circuit once no matter where you start.
    public class Solution_134
    {
        //TC: O(N^2)
        //SC: O(N)
        public int CanCompleteCircuit1(int[] gas, int[] cost)
        {
            var availableStarts = new List<int>();

            for (int i = 0; i < gas.Length; i++)
            {
                if (gas[i] >= cost[i])
                    availableStarts.Add(i);
            }

            foreach (var availableStart in availableStarts)
                if (CheckCircuit(availableStart, gas, cost))
                    return availableStart;

            return -1;
        }

        bool CheckCircuit(int start, int[] gas, int[] cost)
        {
            var startGasOnStation = gas[start];
            var startCost = cost[start];

            var currGasStation = (start + 1) % gas.Length;
            var carGas = startGasOnStation - startCost;

            while (carGas >= 0 && currGasStation != start)
            {
                carGas += gas[currGasStation] - cost[currGasStation];
                //Console.WriteLine(carGas);
                currGasStation = ++currGasStation % gas.Length;
                //Console.WriteLine(currGasStation);         
            }

            return carGas >= 0;
        }

        //TC: O(N)
        //SC: O(1)
        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            //total stations consume
            var total = 0;
            //start
            var index = 0;
            //car tank
            var tank = 0;
            for (int i = 0; i < gas.Length; i++)
            {
                //station consume
                var consume = gas[i] - cost[i];
                //current car tank
                tank += consume;
                //if on this station we cannot reach next station it means that all stations before have invalid starts
                if (tank < 0)
                {
                    //move start to next
                    index = i + 1;
                    //now we start from new index
                    tank = 0;
                }
                //all stations consume
                total += consume;
            }

            return total < 0 ? -1 : index; // check if total -ve which means we can't complete the trip.
        }
    }
}

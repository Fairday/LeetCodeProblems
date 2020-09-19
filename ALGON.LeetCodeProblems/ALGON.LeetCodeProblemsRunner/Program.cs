using ALGON.LeetCodeProblems.Sorting;
using ALGON.LeetCodeProblems.String;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ALGON.LeetCodeProblemsRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var sol = new Solution_165();
            sol.CompareVersion("1.01", "1.001");

            var s = "s ";
            var x = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var intervals = new int[5][];
            intervals[0] = new int[] { 2, 3 };
            intervals[1] = new int[] { 1, 2 };
            intervals[2] = new int[] { 1, 3 };
            intervals[3] = new int[] { 3, 5 };
            intervals[4] = new int[] { 6, 7 };


            Array.Sort(intervals, (a, b) => a[0] - b[0]);

            var sortedDictionary = new SortedDictionary<int, int>();

            for (int i = 0; i < intervals.Length; i++)
            {
                sortedDictionary[intervals[i][0]] = i;
            }

            var ans = new int[intervals.Length];

            for (int i = 0; i < intervals.Length; i++)
            {
                var key = sortedDictionary.FirstOrDefault(kvp => kvp.Key >= intervals[i][1]);

                if (key.Value == 0 && key.Key == 0)
                    ans[i] = -1;
                else
                    ans[i] = sortedDictionary[key.Key];
            }
        }
    }
}

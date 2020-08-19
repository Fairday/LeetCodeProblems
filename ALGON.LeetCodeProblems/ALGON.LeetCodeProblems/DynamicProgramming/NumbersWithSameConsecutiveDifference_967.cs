using System.Collections.Generic;
using System.Linq;

namespace ALGON.LeetCodeProblems.DynamicProgramming
{
    //Return all non-negative integers of length N such that the absolute difference between every two consecutive digits is K.

    //Note that every number in the answer must not have leading zeros except for the number 0 itself.For example, 01 has one leading zero and is invalid, but 0 is valid.

    //You may return the answer in any order.

    //Example 1:

    //Input: N = 3, K = 7
    //Output: [181,292,707,818,929]
    //Explanation: Note that 070 is not a valid number, because it has leading zeroes.
    //Example 2:

    //Input: N = 2, K = 1
    //Output: [10,12,21,23,32,34,43,45,54,56,65,67,76,78,87,89,98]

    //Note:

    //1 <= N <= 9
    //0 <= K <= 9
    public class Solution_967
    {
        //Let NN be the number of digits for a valid combination, and KK be the difference between digits.
        //First of all, let us estimate the number of potential solutions.For the highest digit, we could have 9 potential candidates. 
        //Starting from the second highest position, we could have at most 2 candidates for each position. Therefore, at most, we could have 9 \cdot 2^{ N - 1}9⋅2 
        //N−1 solutions, for N > 1N>1.
        // https://leetcode.com/problems/numbers-with-same-consecutive-differences/solution/
        // Time: O(N * 2 ^ N)
        // Space: O(2^N)
        public int[] NumsSameConsecDiff(int N, int K)
        {
            var starts = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            if (N == 1)
                return starts;

            var queue = new Queue<int>(starts.Skip(1));

            for (int level = 1; level < N; level++)
            {
                var nodes = queue.Count;

                while (nodes > 0)
                {
                    var node = queue.Dequeue();
                    var tailDigit = node % 10;

                    var nextDigits = new List<int>();
                    nextDigits.Add(tailDigit + K);
                    if (K != 0)
                        nextDigits.Add(tailDigit - K);

                    foreach (var digit in nextDigits)
                    {
                        if (digit >= 0 && digit < 10)
                        {
                            var num = node * 10 + digit;
                            queue.Enqueue(num);
                        }
                    }

                    nodes--;
                }
            }

            return queue.ToArray();
        }
    }
}

using System.Collections.Generic;

namespace Problems.DP
{
    //You are climbing a staircase. It takes n steps to reach the top.

    //Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?

    //Example 1:

    //Input: n = 2
    //Output: 2
    //Explanation: There are two ways to climb to the top.
    //1. 1 step + 1 step
    //2. 2 steps
    //Example 2:

    //Input: n = 3
    //Output: 3
    //Explanation: There are three ways to climb to the top.
    //1. 1 step + 1 step + 1 step
    //2. 1 step + 2 steps
    //3. 2 steps + 1 step
 
    //Constraints:

    //1 <= n <= 45
    public class ClimbingStairs_70
    {    
        //O(N)
        //O(1)
        public int ClimbStairs_InPlace(int n)
        {
            var a = 1;
            var b = 1;
            while (n-- > 0)
            {
                a = (b += a) - a;
            }
            return a;
        }

        //O(N)
        //O(N)
        public int ClimbStairs_DP(int n)
        {
            if (n == 0)
                return 0;
            if (n == 1)
                return 1;
            if (n == 2)
                return 2;

            var memo = new int[n];
            memo[0] = 1;
            memo[1] = 2;

            for (int i = 2; i < memo.Length; i++)
                memo[i] = memo[i - 1] + memo[i - 2];

            return memo[n - 1];
        }

        Dictionary<int, int> memo = new Dictionary<int, int>();

        //TLE
        //TC: ??
        //SC: ?? - call stack
        public int ClimbStairs_WithMemo(int n)
        {
            if (n < 0)
                return 0;
            else if (n == 0)
                return 1;

            int n_1;
            int n_2;

            if (memo.ContainsKey(n - 1))
                n_1 = memo[n - 1];
            else
                n_1 = ClimbStairs_WithMemo(n - 1);

            if (memo.ContainsKey(n - 2))
                n_2 = memo[n - 2];
            else
                n_2 = ClimbStairs_WithMemo(n - 2);

            return n_1 + n_2;
        }

        //TLE
        //TC: O(2^N)
        //SC: O(2^N) - call stack
        public int ClimbStairs_NaiveApproach(int n)
        {
            if (n < 0)
                return 0;
            else if (n == 0)
                return 1;

            return ClimbStairs_NaiveApproach(n - 1) + ClimbStairs_NaiveApproach(n - 2);
        }
    }
}
using System;
using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.UnionFind
{
    //Given a non-empty array of unique positive integers A, consider the following graph:

    //There are A.length nodes, labelled A[0] to A[A.length - 1];
    //There is an edge between A[i] and A[j] if and only if A[i] and A[j] share a common factor greater than 1.
    //Return the size of the largest connected component in the graph.

    //Example 1:

    //Input: [4,6,15,35]
    //Output: 4

    //Example 2:

    //Input: [20,50,9,63]
    //Output: 2

    //Example 3:

    //Input: [2,3,6,7,4,12,21,39]
    //Output: 8

    //Note:

    //1 <= A.length <= 20000
    //1 <= A[i] <= 100000
    public class Solution
    {
        // https://ru.wikipedia.org/wiki/%D0%A1%D0%B8%D1%81%D1%82%D0%B5%D0%BC%D0%B0_%D0%BD%D0%B5%D0%BF%D0%B5%D1%80%D0%B5%D1%81%D0%B5%D0%BA%D0%B0%D1%8E%D1%89%D0%B8%D1%85%D1%81%D1%8F_%D0%BC%D0%BD%D0%BE%D0%B6%D0%B5%D1%81%D1%82%D0%B2
        //https://dou.ua/lenta/articles/union-find/
        //https://www.youtube.com/watch?v=2mva2YRgrW8
        //TC: O(N^2)
        public int LargestComponentSize(int[] A)
        {
            //1. Find maximum value and initalize disjoint set with it
            var max = 0;
            foreach (var a in A)
                max = Math.Max(max, a);

            //2. Create UnionFind
            var uf = new UnionFind(max + 1);

            //3. Iterate all numbers 
            //In the nested loop from i = 2 to Sqrt(number)
            //Union by prime factors. If number % i == 0, then union(number, prime), union(number, number / prime)
            foreach (var a in A)
            {
                for (int i = 2; i <= Math.Sqrt(a); i++)
                {
                    if (a % i == 0)
                    {
                        uf.Union(a, i);
                        uf.Union(a, a / i);
                    }
                }
            }

            //4. Initialize HashMap
            var map = new Dictionary<int, int>();
            //5. Results 1 <= A.length <= 20000, minimum length
            max = 1;
            foreach (var a in A)
            {
                //6. Find parent
                var parent = uf.Find(a);
                //Keep value in map
                if (map.ContainsKey(parent))
                    map[parent]++;
                else
                    map[parent] = 1;
                //Max connected component by prime factor
                max = Math.Max(max, map[parent]);
            }

            return max;
        }
    }

    public class UnionFind
    {
        int[] ar;

        public UnionFind(int len)
        {
            ar = new int[len];
            for (int i = 0; i < len; i++)
                ar[i] = i;
        }

        public void Union(int a, int b)
        {
            ar[Find(a)] = ar[Find(b)];
        }

        public int Find(int x)
        {
            if (x != ar[x])
                ar[x] = Find(ar[x]);
            return ar[x];
        }
    }

}

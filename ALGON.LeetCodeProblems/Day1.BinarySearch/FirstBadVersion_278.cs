using System;

namespace Day1.BinarySearch
{
    //You are a product manager and currently leading a team to develop a new product.Unfortunately, the latest version of your product fails the quality check.Since each version is developed based on the previous version, all the versions after a bad version are also bad.

    //Suppose you have n versions[1, 2, ..., n] and you want to find out the first bad one, which causes all the following ones to be bad.

    //You are given an API bool isBadVersion(version) which returns whether version is bad.Implement a function to find the first bad version.You should minimize the number of calls to the API.

    //Example 1:

    //Input: n = 5, bad = 4
    //Output: 4
    //Explanation:
    //call isBadVersion(3) -> false
    //call isBadVersion(5) -> true
    //call isBadVersion(4) -> true
    //Then 4 is the first bad version.

    //Example 2:

    //Input: n = 1, bad = 1
    //Output: 1

    //Constraints:

    //1 <= bad <= n <= 231 - 1
    public class FirstBadVersion_278
    {
        //TC: O(N)
        //SC: O(1)
        public int FirstBadVersion_NaiveApproach(int n)
        {
            if (n <= 0)
                throw new Exception("n should be more than zero");

            for (int i = 1; i <= n; i++)
            {
                if (IsBadVersion(i))
                    return i;
            }

            throw new Exception("bad version should exist");
        }

        //TC: O(log N)
        //SC: O(1)
        public int FirstBadVersion(int n)
        {
            if (n <= 0)
                throw new Exception("n should be more than zero");

            int lo = 1;
            int hi = n;
            //int mid = 0;

            while (/*lo <= hi*/ lo < hi)
            {
                int mid = lo + (hi - lo) / 2;

                //example
                // 1 2 3 4 5 6(*) 7 8
                // 4 5 6(*) 7 8
                // 4 5 6(*)
                // 5 6(*)
                //lo = 5, hi = 6, mid = 5 -> lo = 6
                //lo = 6, hi = 6, mid = 6
                //moving in left direction
                //if (mid == hi)
                //return mid;

                if (IsBadVersion(mid))
                    hi = mid;
                else
                    lo = mid + 1;
            }

            //another approarch,  moving lo to hi
            return lo;
        }

        private bool IsBadVersion(int version) 
        {
            throw new NotImplementedException("LeedCode impl should be here");
        }
    }
}
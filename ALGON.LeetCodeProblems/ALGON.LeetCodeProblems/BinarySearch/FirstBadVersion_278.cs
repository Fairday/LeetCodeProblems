namespace ALGON.LeetCodeProblems.BinarySearch
{
    /*You are a product manager and currently leading a team to develop a new product.Unfortunately, the latest version of your product fails the quality check.Since each version is developed based on the previous version, all the versions after a bad version are also bad.

    Suppose you have n versions[1, 2, ..., n] and you want to find out the first bad one, which causes all the following ones to be bad.

    You are given an API bool isBadVersion(version) which will return whether version is bad.Implement a function to find the first bad version.You should minimize the number of calls to the API.

    Example:

    Given n = 5, and version = 4 is the first bad version.

    call isBadVersion(3) -> false
    call isBadVersion(5) -> true
    call isBadVersion(4) -> true

    Then 4 is the first bad version.*/
    /* The isBadVersion API is defined in the parent class VersionControl.
          bool IsBadVersion(int version); */
    public class Solution_278
    {
        /*Before this problem, I have always use
        mid = (start+end)) / 2;
        To get the middle value, but this can caused OVERFLOW !
        when start and end are all about INT_MAX , then (start+end) of course will be overflow !
        To avoid the problem we can use
        mid =  start+(end-start)/2;
        https://discuss.leetcode.com/topic/38135/a-good-warning-to-me-to-use-start-end-start-2-to-avoid-overflow
        */
        public int FirstBadVersion(int n)
        {
            var left = 1;
            var right = n;

            while (left <= right)
            {
                var mid = left + (right - left) / 2;

                if (IsBadVersion(mid))
                {
                    if (mid > 1 && !IsBadVersion(mid - 1))
                        return mid;
                    else if (mid > 1 && IsBadVersion(mid - 1))
                        right = mid - 1;
                    else
                        return mid;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return right;
        }

        bool IsBadVersion(int version)
        {
            return true;
        }
    }
}

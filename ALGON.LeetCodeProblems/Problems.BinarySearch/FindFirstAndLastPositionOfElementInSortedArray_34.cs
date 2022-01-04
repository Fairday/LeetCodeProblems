using System;

namespace Problems.BinarySearch
{
    //Given an array of integers nums sorted in non-decreasing order, find the starting and ending position of a given target value.

    //If target is not found in the array, return [-1, -1].

    //You must write an algorithm with O(log n) runtime complexity.

    //Example 1:

    //Input: nums = [5, 7, 7, 8, 8, 10], target = 8
    //Output: [3,4]
    //Example 2:

    //Input: nums = [5, 7, 7, 8, 8, 10], target = 6
    //Output: [-1,-1]
    //Example 3:

    //Input: nums = [], target = 0
    //Output: [-1,-1]

    //Constraints:

    //0 <= nums.length <= 105
    //-109 <= nums[i] <= 109
    //nums is a non-decreasing array.
    //-109 <= target <= 109
    public class FindFirstAndLastPositionOfElementInSortedArray_34
    {
        //TC: O(N)
        //SC: O(1)
        public int[] SearchRange_NaiveApproach(int[] nums, int target)
        {
            if (nums == null)
                throw new Exception("nums cannot be null");

            int start = -1;
            int end = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == target && start == -1)
                    start = i;
                else if (nums[i] == target)
                    end = i;
                else if (start > -1 && end > -1)
                    break;
            }

            if (start >= 0 && end < 0)
                end = start;

            return new int[] { start, end };
        }

        //TC: O(log N)
        //SC: O(1)
        public int[] SearchRange_NaiveDoubleBinarySearch(int[] nums, int target)
        {
            if (nums == null)
                throw new Exception("nums cannot be null");

            int lo = 0;
            int hi = nums.Length - 1;

            int start = -1;
            int end = -1;

            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;
                int num = nums[mid];
                if (num == target)
                {
                    if (mid > 0 && nums[mid - 1] != target)
                    {
                        start = mid;
                        break;
                    }
                    else if (mid > 0 && nums[mid - 1] == target)
                    {
                        hi = mid;
                    }
                    else if (mid == 0)
                    {
                        start = mid;
                        break;
                    }
                }
                else if (num > target)
                {
                    hi = mid - 1;
                }
                else
                {
                    lo = mid + 1;
                }
            }

            lo = 0;
            hi = nums.Length - 1;

            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;
                int num = nums[mid];
                if (num == target)
                {
                    if (mid < nums.Length - 1 && nums[mid + 1] != target)
                    {
                        end = mid;
                        break;
                    }
                    else if (mid < nums.Length - 1 && nums[mid + 1] == target)
                    {
                        lo = mid + 1;
                    }
                    else if (mid == nums.Length - 1)
                    {
                        end = mid;
                        break;
                    }
                }
                else if (num > target)
                {
                    hi = mid - 1;
                }
                else
                {
                    lo = mid + 1;
                }
            }

            return new int[] { start, end };
        }

        //TC: O(log N)
        //SC: O(1)
        public int[] SearchRange(int[] nums, int target)
        {
            if (nums == null)
                throw new Exception("nums cannot be null");

            int lo = 0;
            int hi = nums.Length - 1;
            int[] res = new int[] { -1, -1 };

            if (nums.Length == 0)
                return res;

            while (lo < hi)
            {
                //bind mid to left
                int mid = lo + (hi - lo) / 2;
                if (nums[mid] < target)
                    lo = mid + 1;
                else
                    hi = mid;
            }

            if (nums[lo] != target)
                return res;
            res[0] = lo;

            hi = nums.Length - 1;

            while (lo < hi)
            {
                //bind mid to right
                int mid = lo + (hi - lo) / 2 + 1;
                if (nums[mid] > target)
                    hi = mid - 1;
                else
                    lo = mid;
            }

            res[1] = hi;
            return res;
        }
    }
}
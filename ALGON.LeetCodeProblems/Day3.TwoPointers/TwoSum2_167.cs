using System;
using System.Collections.Generic;

namespace Day3.TwoPointers
{
    //Given a 1-indexed array of integers numbers that is already sorted in non-decreasing order, find two numbers such that they add up to a specific target number.Let these two numbers be numbers[index1] and numbers[index2] where 1 <= first<second <= numbers.length.

    //Return the indices of the two numbers, index1 and index2, as an integer array[index1, index2] of length 2.

    //The tests are generated such that there is exactly one solution.You may not use the same element twice.

    //Example 1:

    //Input: numbers = [2, 7, 11, 15], target = 9
    //Output: [1,2]
    //Explanation: The sum of 2 and 7 is 9. Therefore index1 = 1, index2 = 2.
    //Example 2:

    //Input: numbers = [2, 3, 4], target = 6
    //Output: [1,3]
    //Explanation: The sum of 2 and 4 is 6. Therefore index1 = 1, index2 = 3.
    //Example 3:

    //Input: numbers = [-1, 0], target = -1
    //Output: [1,2]
    //Explanation: The sum of -1 and 0 is -1. Therefore index1 = 1, index2 = 2.

    //Constraints:

    //2 <= numbers.length <= 3 * 104
    //-1000 <= numbers[i] <= 1000
    //numbers is sorted in non-decreasing order.
    //-1000 <= target <= 1000
    //The tests are generated such that there is exactly one solution.
    public class TwoSum2_167
    {
        //TC: O(N^2)
        //SC: O(1)
        public int[] TwoSum_NaiveApproach(int[] numbers, int target)
        {
            if (numbers == null)
                throw new Exception("numbers cannot be null");

            for (int i = 0; i < numbers.Length; i++)
            {
                int num1 = numbers[i];
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (num1 + numbers[j] == target && i != j)
                        return new int[] { i + 1, j + 1 };
                }
            }

            throw new Exception("Solution is not exist");
        }

        //TC: O(N)
        //SC: O(1)
        public int[] TwoSum(int[] numbers, int target)
        {
            if (numbers == null)
                throw new Exception("numbers cannot be null");

            int i = 0;
            int j = numbers.Length - 1;

            while (i < j)
            {
                if (numbers[i] + numbers[j] > target)
                    j--;
                else if (numbers[i] + numbers[j] < target)
                    i++;
                else
                    return new int[] { i + 1, j + 1 };
            }

            throw new Exception("Solution is not exist");
        }

        //TC: O(N)
        //SC: O(N)
        public int[] TwoSum_ViaDictionary(int[] numbers, int target)
        {
            if (numbers == null)
                throw new Exception("numbers cannot be null");

            Dictionary<int, int> dic = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                int num = numbers[i];
                int diff = target - num;
                if (dic.ContainsKey(diff))
                {
                    return new int[] { dic[diff] + 1, i + 1 };
                }
                dic[num] = i;
            }

            throw new Exception("Solution is not exist");
        }

        //TC: O(N log N)
        //SC: O(1)
        public int[] TwoSum_ViaBinarySearch(int[] numbers, int target)
        {
            if (numbers == null)
                throw new Exception("numbers cannot be null");

            for (int i = 0; i < numbers.Length; i++)
            {
                var diff = target - numbers[i];
                var idx = BinarySearch(numbers, i + 1, diff);
                if (idx > 0)
                    return new int[] { i + 1, idx + 1 };
            }

            throw new Exception("Solution is not exist");
        }

        private int BinarySearch(int[] nums, int lo, int target)
        {
            //VAR1
            //int hi = nums.Length - 1;
            //while (lo <= hi)
            //{
            //    int mid = lo + (hi - lo) / 2;
            //    int num = nums[mid];
            //    if (num == target)
            //        return mid;
            //    else if (num > target)
            //        hi = mid - 1;
            //    else
            //        lo = mid + 1;
            //}

            //return -1;

            //VAR2
            return Array.BinarySearch(nums, lo, nums.Length - lo, target);
        }
    }
}
namespace Day1.BinarySearch
{
    //Given a sorted array of distinct integers and a target value, return the index if the target is found.If not, return the index where it would be if it were inserted in order.

    //You must write an algorithm with O(log n) runtime complexity.

    //Example 1:

    //Input: nums = [1, 3, 5, 6], target = 5
    //Output: 2
    //Example 2:

    //Input: nums = [1, 3, 5, 6], target = 2
    //Output: 1
    //Example 3:

    //Input: nums = [1, 3, 5, 6], target = 7
    //Output: 4
    //Example 4:

    //Input: nums = [1, 3, 5, 6], target = 0
    //Output: 0
    //Example 5:

    //Input: nums = [1], target = 0
    //Output: 0
    public sealed class SearchInsertPosition_35
    {
        //TC: O(log N)
        //SC: O(1)
        public int SearchInsert(int[] nums, int target)
        {
            if (nums.Length == 0)
                return 0;

            int lo = 0;
            int hi = nums.Length - 1;

            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;
                int num = nums[mid];
                if (num == target)
                    return mid;
                else if (target > num)
                    lo = mid + 1;
                else
                    hi = mid - 1;
            }

            return lo;
        }

        //TC: O(N)
        //SC: O(1)
        public int SearchInsert_NaiveApproach(int[] nums, int target)
        {
            if (nums.Length == 0 || nums[0] > target)
                return 0;

            if (nums.Length == 1 && nums[0] == target)
                return 0;

            for (int i = 0; i < nums.Length - 1; i++)
            {
                //1 3 5
                //3 -> 2
                //5 -> 3
                //4 -> 2

                //1 3
                //1
                if (target > nums[i] && target <= nums[i + 1])
                    return i + 1;
                else if (target >= nums[i] && target < nums[i + 1])
                    return i;
                else if (target >= nums[i] && target <= nums[i + 1])
                    return i;
            }

            return nums.Length;
        }
    }
}
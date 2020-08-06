namespace ALGON.LeetCodeProblems.PArray
{
    /*There are two sorted arrays nums1 and nums2 of size m and n respectively.

    Find the median of the two sorted arrays.The overall run time complexity should be O(log (m+n)).

    You may assume nums1 and nums2 cannot be both empty.

    Example 1:

    nums1 = [1, 3]
    nums2 = [2]

    The median is 2.0
    Example 2:

    nums1 = [1, 2]
    nums2 = [3, 4]

    The median is (2 + 3)/2 = 2.5*/
    public class Solution_4
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var combined = new int[nums1.Length + nums2.Length];
            var i = 0;
            var j = 0;
            var k = 0;
            while (i < nums1.Length && j < nums2.Length)
            {
                if (nums1[i] <= nums2[j])
                {
                    combined[k] = nums1[i];
                    i++;
                }
                else
                {
                    combined[k] = nums2[j];
                    j++;
                }
                k++;
            }

            for (; i < nums1.Length; i++)
                combined[k++] = nums1[i];

            for (; j < nums2.Length; j++)
                combined[k++] = nums2[j];

            if (combined.Length % 2 != 0)
                return combined[combined.Length / 2];
            else
                return (combined[combined.Length / 2] + combined[combined.Length / 2 - 1]) / 2d;
        }
    }
}

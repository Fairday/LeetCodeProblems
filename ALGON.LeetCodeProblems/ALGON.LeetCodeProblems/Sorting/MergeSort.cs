using System;

namespace ALGON.LeetCodeProblems.Sorting
{
    /// <summary>
    /// Time complexity: O(N * logN)
    /// Space complexity: depends on data size
    /// </summary>
    public static class MergeSort
    {
        public static void Sort(int[] array) 
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (array.Length == 0)
                return;

            int[] buffer = new int[array.Length];
            Sort(array, buffer, 0, array.Length - 1);
        }

        static void Sort(int[] array, int[] buffer, int lo, int hi) 
        {
            if (lo < hi)
            {
                var mid = (hi + lo) / 2;
                Sort(array, buffer, lo, mid);
                Sort(array, buffer, mid + 1, hi);
                Merge(array, buffer, lo, mid, hi);
            }
        }

        static void Merge(int[] array, int[] buffer, int lo, int mid, int hi) 
        {
            for (int i = 0; i <= hi; i++)
                buffer[i] = array[i];

            var left = lo;
            var right = mid + 1;
            var curr = lo;
            while (left <= mid && right <= hi) 
            {
                if (buffer[left] <= buffer[right]) 
                    array[curr++] = buffer[left++];
                else
                    array[curr++] = buffer[right++];
            }

            var remaining = mid - left;
            for (int i = 0; i <= remaining; i++)
                array[curr + i] = buffer[left + i];
        }
    }
}

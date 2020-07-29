namespace ALGON.LeetCodeProblems.Sorting
{
    /// <summary>
    /// Find kth element in array
    /// </summary>
    public class QuickSelection
    {
        public static int GetKthElement(int[] array, int k) 
        {
            var lo = 0;
            var hi = array.Length - 1;

            while (lo <= hi)
            {
                var pivotIndex = Partition(array, lo, hi);
                if (pivotIndex == k)
                    return array[pivotIndex];
                else if (pivotIndex < k)
                    lo = pivotIndex + 1;
                else
                    hi = pivotIndex - 1;
            }

            return array[k];
        }

        static int Partition(int[] array, int lo, int hi) 
        {
            var mid = (hi + lo) / 2;
            var pivot = array[mid];
            var i = lo;
            var j = hi;
            while (true) 
            {
                while (array[i] < pivot)
                    i++;
                while (array[j] > pivot)
                    j--;

                if (i >= j)
                    return j;

                Swap(array, i, j);
                i++;
                j++;
            }
        }

        static void Swap(int[] array, int i, int j) 
        {
            var temp = array[j];
            array[j] = array[i];
            array[i] = temp;
        }
    }
}

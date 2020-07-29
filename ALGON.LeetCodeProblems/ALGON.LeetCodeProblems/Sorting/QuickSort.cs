namespace ALGON.LeetCodeProblems.Sorting
{
    /// <summary>
    /// Time complexity: O(N^2) - worst, O(N * logN) - default partition, O(N) - partition on 3
    /// Space complexity: O(N)
    /// </summary>
    public static class QuickSort
    {
        public static void Sort_2W(int[] array)
        {
            SortHelper_2W(array, 0, array.Length - 1);
        }

        public static void Sort_3W(int[] array) 
        {
            SortHelper_3W(array, 0, array.Length - 1);
        }

        static void SortHelper_2W(int[] array, int lo, int hi)
        {
            if (lo < hi) 
            {
                var pivotIndex = Partition_2W(array, lo, hi);
                SortHelper_2W(array, lo, pivotIndex);
                SortHelper_2W(array, pivotIndex + 1, hi);
            }
        }

        // Dijkstra 3-way partitioning algorithm.
        // https://www.quora.com/How-does-your-3-way-quicksort-algorithm-work
        static void SortHelper_3W(int[] array, int lo, int hi)
        {
            if (lo < hi)
            {
                var lt = lo;
                var gt = hi;
                var i = lo;
                var pivot = array[lo];

                while (i <= gt)
                {
                    if (array[i] < pivot)
                    {
                        Swap(array, lt, i);
                        lt++;
                        i++;
                    }
                    else if (array[i] > pivot) 
                    {
                        Swap(array, gt, i);
                        gt--;
                    }
                    else
                    {
                        i++;
                    }
                }

                SortHelper_3W(array, lo, lt - 1);
                SortHelper_3W(array, gt + 1, hi);
            }
        }

        //Разбиение Хоара
        static int Partition_2W(int[] array, int lo, int hi) 
        {
            var pivotIndex = (lo + hi) / 2;
            var pivot = array[pivotIndex];
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
                j--;
            }
        }

        static int Partition_3W(int[] array, int lo, int hi)
        {
            var pivotIndex = (lo + hi) / 2;
            var pivot = array[pivotIndex];
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
                j--;
            }
        }

        static void Swap(int[] array, int i, int j) 
        {
            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}

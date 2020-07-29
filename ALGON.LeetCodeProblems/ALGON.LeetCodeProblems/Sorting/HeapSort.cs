namespace ALGON.LeetCodeProblems.Sorting
{
    /// <summary>
    /// Time complexity: O(N * logN)
    /// Space complexity: O(1)
    /// </summary>
    public static class HeapSort
    {
        public static void Sort(int[] array) 
        {
            BuildHeap(array);

            for (int i = array.Length - 1; i >= 0; i--)
            {
                //Swap root and last
                var temp = array[0];
                array[0] = array[i];
                array[i] = temp;

                //Heapify on the reduced heap
                Heapify(array, i, 0);
            }
        }

        static void BuildHeap(int[] array) 
        {
            var n = array.Length;
            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(array, n, i);
        }

        static void Heapify(int[] array, int heapSize, int i) 
        {
            var l = i * 2 + 1;
            var r = i * 2 + 2;
            var largest = i; //initializing root

            if (l < heapSize && array[largest] < array[l]) 
            {
                largest = l;
            }

            if (r < heapSize && array[largest] < array[r]) 
            {
                largest = r;
            }

            if (largest != i) 
            {
                Swap(array, i, largest);
                Heapify(array, heapSize, largest);
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

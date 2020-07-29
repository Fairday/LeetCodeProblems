using System;

namespace ALGON.LeetCodeProblems.Sorting
{
    /// <summary>
    /// Time comlexity: O(N^2)
    /// Space complexity: O(1)
    /// </summary>
    public static class BubbleSort
    {
        public static void Sort(int[] array) 
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            for (int i = 0; i < array.Length; i++) 
                for (int j = 1; j < array.Length - i; j++) 
                    if (array[j] < array[j - 1]) 
                        Swap(array, j, j - 1);
        }

        static void Swap(int[] array, int i, int j) 
        {
            var temp = array[j];
            array[j] = array[i];
            array[i] = temp;
        }
    }
}

using ALGON.LeetCodeProblems.Sorting;

namespace ALGON.LeetCodeProblemsRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var array1 = new int[] { 3, 5, 9, 6, 7, 1, 8};
            var array2 = new int[] { 3, 5, 4, 6, 6, 5, 6, 7, 1, 7 };
            BubbleSort.Sort(array1);
            QuickSort.Sort_3W(array2);
            var el = QuickSelection.GetKthElement(array2, 1);
            var isEqual = ArrayComparer.IsEqual(array1, array2);
        }
    }
}

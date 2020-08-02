namespace ALGON.LeetCodeProblems.Helpers
{
    public static class ArrayExtensions
    {
        public static void Fill<T>(this T[] arr, T val) 
        {
            if (arr == null || arr.Length == 0)
                return;

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = val;
            }
        }
    }
}

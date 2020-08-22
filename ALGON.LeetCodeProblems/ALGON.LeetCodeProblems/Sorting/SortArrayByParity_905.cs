namespace ALGON.LeetCodeProblems.Sorting
{
    public class Solution_905
    {
        // QuickSort TC: O(N), SC: O(1)
        // One pass, in place
        //Example: 3 1 2 4
        //Step 1
        //i = 0; j = 3;
        //4 1 2 3
        //Step 2
        //i = 1; j = 2;
        //4 2 1 3
        //End
        public int[] SortArrayByParity(int[] A)
        {
            int i = 0;
            int j = A.Length - 1;

            while (i < j)
            {
                //Swap
                if (A[i] % 2 > A[j] % 2)
                {
                    var temp = A[i];
                    A[i] = A[j];
                    A[j] = temp;
                }

                if (A[i] % 2 == 0) i++;
                if (A[j] % 2 == 1) j--;
            }

            return A;
        }
    }
}

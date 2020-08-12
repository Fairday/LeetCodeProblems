namespace ALGON.LeetCodeProblems.Sorting
{
    //Given an array of citations(each citation is a non-negative integer) of a researcher, write a function to compute the researcher's h-index.

    //According to the definition of h-index on Wikipedia: "A scientist has index h if h of his/her N papers have at least h citations each, and the other N − h papers have no more than h citations each."

    //Example:

    //Input: citations = [3,0,6,1,5]
    //    Output: 3 
    //Explanation: [3,0,6,1,5] means the researcher has 5 papers in total and each of them had
    //             received 3, 0, 6, 1, 5 citations respectively.
    //             Since the researcher has 3 papers with at least 3 citations each and the remaining
    //             two with no more than 3 citations each, her h-index is 3.
    //Note: If there are several possible values for h, the maximum one is taken as the h-index.
    public class Solution_274
    {
        public int HIndex(int[] citations)
        {
            //use bucket sort

            //exmaple: arr[3,1,2,3,2]
            //3 is not H-index, occurs only 2 times (need 3 to h-index)
            //2 is H-index, occurs 2 times
            //1 is H-index, occurs 1 time

            var n = citations.Length;
            var bucket = new int[n + 1];

            for (int i = 0; i < n; i++)
            {
                if (citations[i] > n)
                    bucket[n]++;
                else
                    bucket[citations[i]]++;
            }

            var countSum = 0;
            for (int i = n; i >= 0; i--)
            {
                countSum += bucket[i];
                if (countSum >= i)
                    return i;
            }

            return 0;
        }
    }
}

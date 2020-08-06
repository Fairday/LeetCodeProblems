using ALGON.LeetCodeProblems.PArray;
using System.Linq;
using System.Text;

namespace ALGON.LeetCodeProblemsRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution_239();
            s.MaxSlidingWindow(new int[] { -6, -10, -7, -1, -9, 9, -8, -4, 10, -5, 2, 9, 0, -7, 7, 4, -2, -10, 8, 7 }, 7);
            //s.SearchMatrix(2147395599);

        }
    }
}

using ALGON.LeetCodeProblems.Graph;

namespace ALGON.LeetCodeProblemsRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution_56();
            var input = new int[3][];
            input[0] = new int[] { 4, 5 };
            input[1] = new int[] { 1, 4 };
            input[2] = new int[] { 0, 1 };
            solution.Merge(input);
        }
    }
}

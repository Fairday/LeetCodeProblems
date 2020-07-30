using ALGON.LeetCodeProblems.Backtracking;

namespace ALGON.LeetCodeProblemsRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var cs = new Solution_139();
            cs.WordBreak("leetcode", new string[] {  "leet", "lee", "t", "code" });
        }
    }
}

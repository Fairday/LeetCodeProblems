using ALGON.LeetCodeProblems.String;

namespace ALGON.LeetCodeProblemsRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var bc = new Solution_772();
            var r1 = bc.Calculate("1 + 1"); //2
            var r2 = bc.Calculate("6-4 / 2 "); //4
            var r3 = bc.Calculate("2*(5+5*2)/3+(6/2+8)"); //21
            var r4 = bc.Calculate("(6-4)/ 2 "); //1
            var r5 = bc.Calculate("(2+6* 3+5- (3*14/7+2)*5)+3"); //-12
        }
    }
}

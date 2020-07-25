using ALGON.LeetCodeProblems.Design;

namespace ALGON.LeetCodeProblemsRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var d = new CircularDeque(77);
            d.InsertFront(89);
            var r1 = d.GetRear();
            d.DeleteLast();
            var r2 = d.GetRear();
            d.InsertFront(19);
            d.InsertFront(23);
            d.InsertFront(23);
            d.InsertFront(82);
            d.IsFull();
            d.InsertFront(45);
            d.IsFull();
            var r3 = d.GetRear();
            d.DeleteLast();
            var f1= d.GetFront();
            var f2 = d.GetFront();
            d.InsertLast(74);
            d.DeleteFront();
            var f3 = d.GetFront();
        }
    }
}

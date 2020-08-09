using ALGON.LeetCodeProblems.LinkedList;

namespace ALGON.LeetCodeProblemsRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var isl = new Solution_147();
            var node = new ListNode(-1);
            node.next = new ListNode(5);
            node.next.next = new ListNode(3);
            node.next.next.next = new ListNode(4);
            node.next.next.next.next = new ListNode(0);
            isl.InsertionSortList(node);
        }
    }
}

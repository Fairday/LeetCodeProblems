namespace ALGON.LeetCodeProblems.LinkedList
{
    /*Given a singly linked list L: L0→L1→…→Ln-1→Ln,
    reorder it to: L0→Ln→L1→Ln-1→L2→Ln-2→…

    You may not modify the values in the list's nodes, only nodes itself may be changed.

    Example 1:

    Given 1->2->3->4, reorder it to 1->4->2->3.
    Example 2:

    Given 1->2->3->4->5, reorder it to 1->5->2->4->3.*/
    /**
    * Definition for singly-linked list.
    * public class ListNode {
    * public int val;
    * public ListNode next;
    * public ListNode(int val=0, ListNode next=null) {
    * this.val = val;
    * this.next = next;
    * }
    * }
*/
    public class Solution_143
    {
        public void ReorderList(ListNode head)
        {
            if (head == null)
                return;

            if (head.next == null)
                return;

            ListNode prev = null;
            var slow = head;
            var fast = head;

            while (fast != null && fast.next != null)
            {
                prev = slow;
                slow = slow.next;
                fast = fast.next.next;
            }

            prev.next = null;
            var mid = slow;

            var newHead = Reverse(mid);
            Merge(head, newHead);
        }

        ListNode Reverse(ListNode head)
        {
            var curr = head;
            ListNode prev = null;

            while (curr != null)
            {
                var next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }

            return prev;
        }

        void Merge(ListNode head1, ListNode head2)
        {
            var curr1 = head1;
            var curr2 = head2;
            ListNode next1 = null;
            ListNode prev = null;

            bool fromRight = true;
            while (curr1 != null && curr2 != null)
            {
                if (fromRight)
                {
                    next1 = curr1.next;
                    curr1.next = curr2;
                    curr1 = curr2;
                    prev = curr2;
                    curr2 = curr2.next;
                    fromRight = false;
                }
                else
                {
                    curr1.next = next1;
                    curr1 = next1;
                    fromRight = true;
                }
            }

            if (curr2 != null)
                prev.next = curr2;
        }
    }
}

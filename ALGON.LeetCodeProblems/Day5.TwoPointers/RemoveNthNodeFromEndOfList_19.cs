using System;

namespace Day5.TwoPointers
{
    //Given the head of a linked list, remove the nth node from the end of the list and return its head.

    //Example 1:

    //Input: head = [1,2,3,4,5], n = 2
    //Output: [1,2,3,5]
    //Example 2:

    //Input: head = [1], n = 1
    //Output: []
    //Example 3:

    //Input: head = [1,2], n = 1
    //Output: [1]
 
    //Constraints:

    //The number of nodes in the list is sz.
    //1 <= sz <= 30
    //0 <= Node.val <= 100
    //1 <= n <= sz
 
    //Follow up: Could you do this in one pass?
    public class RemoveNthNodeFromEndOfList_19
    {
        //TC: O(N)
        //SC: O(1)
        public ListNode RemoveNthFromEnd_TwoPointer(ListNode head, int n)
        {
            if (head == null)
                throw new Exception("head cannot be null");
            if (n < 0)
                throw new Exception("n cannot be less than zero");

            var lo = head;
            var hi = head;
            int i = 0;
            int j = 0;
            while (hi.next != null)
            {
                if (j - i == n)
                {
                    lo = lo.next;
                    i++;
                }
                else
                {
                    hi = hi.next;
                    j++;
                }
            }

            //delete first node, caz we have reached the end
            if (j < n)
                return head.next;
            else
                lo.next = lo.next.next;

            return head;
        }

        //TC: O(N)
        //SC: O(1)
        public ListNode RemoveNthFromEnd_NaiveApproach(ListNode head, int n)
        {
            if (head == null)
                throw new Exception("head cannot be null");
            if (n < 0)
                throw new Exception("n cannot be less than zero");

            int count = 0;
            var curr = head;
            while (curr != null)
            {
                count++;
                curr = curr.next;
            }

            if (count == n)
                return head.next;

            var node = head;
            for (int i = 0; i < count - n - 1; i++)
                node = node.next;
            var toDelete = node.next;
            if (toDelete != null)
                node.next = toDelete.next;
            else
                return null;

            return head;
        }

        //Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
    }
}

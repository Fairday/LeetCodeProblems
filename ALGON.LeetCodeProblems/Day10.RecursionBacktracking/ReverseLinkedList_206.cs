using System.Collections.Generic;
using System.Linq;

namespace Day10.RecursionBacktracking
{
    //Given the head of a singly linked list, reverse the list, and return the reversed list.

    //Example 1:

    //Input: head = [1,2,3,4,5]
    //Output: [5,4,3,2,1]
    //Example 2:

    //Input: head = [1,2]
    //Output: [2,1]
    //Example 3:

    //Input: head = []
    //Output: []

    //Constraints:

    //The number of nodes in the list is the range [0, 5000].
    //-5000 <= Node.val <= 5000
    //Follow up: A linked list can be reversed either iteratively or recursively. Could you implement both?
    public class ReverseLinkedList_206
    {   
        //TC: O(N)
        //SC: O(N)
        public ListNode ReverseList_SimplestApproach(ListNode head)
        {
            if (head == null)
                return null;

            List<ListNode> nodes = new List<ListNode>();

            while (head != null)
            {
                nodes.Add(head);
                head = head.next;
            }

            ListNode prev = null;
            for (int i = nodes.Count - 1; i > 0; i--)
                nodes[i].next = nodes[i - 1];

            nodes[0].next = null;

            return nodes.Last();
        }

        //TC: O(N)
        //SC: O(N), where N - call stack
        public ListNode ReverseList_Recursive(ListNode head)
        {
            if (head == null)
                return null;

            return Recursive(null, head);
        }

        private ListNode Recursive(ListNode prev, ListNode cur)
        {
            if (cur == null)
                return prev;

            var next = cur.next;
            cur.next = prev;
            prev = cur;
            cur = next;
            return Recursive(prev, cur);
        }

        //TC: O(N)
        //SC: O(1)
        public ListNode ReverseList_IterativeOnePlace(ListNode head)
        {
            if (head == null)
                return null;

            ListNode prev = null;

            while (head != null)
            {
                var next = head.next;
                head.next = prev;
                prev = head;
                head = next;
            }

            return prev;
        }

        //TC: O(N)
        //SC: O(1)
        public ListNode ReverseList_IterativeNaiveApproach(ListNode head)
        {
            if (head == null)
                return null;

            ListNode prev = null;
            var cur = head;

            while (cur != null)
            {
                var next = cur.next;
                cur.next = prev;
                prev = cur;
                if (next == null)
                    head = cur;
                cur = next;
            }

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
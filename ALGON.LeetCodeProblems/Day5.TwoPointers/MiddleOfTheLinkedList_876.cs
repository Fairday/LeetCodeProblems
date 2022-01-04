using System;

namespace Day5.TwoPointers
{
    //Given the head of a singly linked list, return the middle node of the linked list.

    //If there are two middle nodes, return the second middle node.

    //Example 1:

    //Input: head = [1,2,3,4,5]
    //Output: [3,4,5]
    //Explanation: The middle node of the list is node 3.
    //Example 2:

    //Input: head = [1,2,3,4,5,6]
    //Output: [4,5,6]
    //Explanation: Since the list has two middle nodes with values 3 and 4, we return the second one.
 
    //Constraints:

    //The number of nodes in the list is in the range [1, 100].
    //1 <= Node.val <= 100
    public class MiddleOfTheLinkedList_876
    {
        //TC: O(N)
        //SC: O(1)
        public ListNode MiddleNode(ListNode head)
        {
            if (head == null)
                throw new Exception("head cannot be null");

            var slow = head;
            var fast = head;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            return slow;
        }

        //TC: O(N)
        //SC: O(1)
        public ListNode MiddleNode_NaiveApproach(ListNode head)
        {
            if (head == null)
                throw new Exception("head cannot be null");

            int count = 0;
            var curr = head;
            while (curr != null)
            {
                count++;
                curr = curr.next;
            }

            var node = head;
            for (int i = 0; i < count / 2; i++)
                node = node.next;
            return node;
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
namespace ALGON.LeetCodeProblems.LinkedList
{
    //Given a linked list and a value x, partition it such that all nodes less than x come before nodes greater than or equal to x.

    //You should preserve the original relative order of the nodes in each of the two partitions.

    //Example:

    //Input: head = 1->4->3->2->5->2, x = 3
    //Output: 1->2->2->4->3->5
    /**
     * Definition for singly-linked list.
     * public class ListNode {
     *     public int val;
     *     public ListNode next;
     *     public ListNode(int val=0, ListNode next=null) {
     *         this.val = val;
     *         this.next = next;
     *     }
     * }
     */
    public class Solution_86
    {
        public ListNode Partition(ListNode head, int x)
        {
            if (head == null)
                return null;

            var curr = head;
            ListNode startLeft = null;
            ListNode left = null;
            ListNode startRight = null;
            ListNode right = null;

            while (curr != null)
            {
                if (curr.val < x)
                {
                    if (startLeft == null)
                    {
                        startLeft = curr;
                        left = startLeft;
                    }
                    else
                    {
                        left.next = curr;
                        left = curr;
                    }
                }
                else if (curr.val >= x)
                {
                    if (startRight == null)
                    {
                        startRight = curr;
                        right = startRight;
                    }
                    else
                    {
                        right.next = curr;
                        right = curr;
                    }
                }

                curr = curr.next;
            }

            if (left != null)
                left.next = startRight;
            if (right != null)
                right.next = null;

            return startLeft == null ? startRight : startLeft;
        }
    }
}

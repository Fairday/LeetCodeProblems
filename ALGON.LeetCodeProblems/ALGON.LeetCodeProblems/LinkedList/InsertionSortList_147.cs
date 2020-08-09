namespace ALGON.LeetCodeProblems.LinkedList
{
    //Sort a linked list using insertion sort.
    //A graphical example of insertion sort.The partial sorted list (black) initially contains only the first element in the list.
    //With each iteration one element (red) is removed from the input data and inserted in-place into the sorted list


    //Algorithm of Insertion Sort:

    //Insertion sort iterates, consuming one input element each repetition, and growing a sorted output list.
    //At each iteration, insertion sort removes one element from the input data, finds the location it belongs within the sorted list, and inserts it there.
    //It repeats until no input elements remain.

    //Example 1:

    //Input: 4->2->1->3
    //Output: 1->2->3->4
    //Example 2:

    //Input: -1->5->3->4->0
    //Output: -1->0->3->4->5
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
    public class Solution_147
    {
        public ListNode InsertionSortList(ListNode head)
        {
            ListNode curr = head;

            while (curr != null)
            {
                if (curr == head)
                {
                    var next = curr.next;
                    curr.next = null;
                    curr = next;
                }
                else
                {
                    ListNode prev = null;
                    var temp = head;
                    while (temp != null && temp.val <= curr.val)
                    {
                        prev = temp;
                        temp = temp.next;
                    }

                    if (prev == null)
                    {
                        var next = curr.next;
                        curr.next = null;
                        curr.next = head;
                        head = curr;
                        curr = next;
                    }
                    else
                    {
                        var next = curr.next;
                        curr.next = null;
                        prev.next = curr;
                        curr.next = temp;
                        curr = next;
                    }
                }
            }

            return head;
        }
    }
}

using ALGON.LeetCodeProblems.Tree;

namespace ALGON.LeetCodeProblems.LinkedList
{
    //Given a singly linked list where elements are sorted in ascending order, convert it to a height balanced BST.

    //For this problem, a height-balanced binary tree is defined as a binary tree in which the depth of the two subtrees of every node never differ by more than 1.

    //Example:

    //Given the sorted linked list: [-10,-3,0,5,9],

    //One possible answer is: [0,-3,9,-10,null,5], which represents the following height balanced BST:

    //      0
    //     / \
    //   -3   9
    //   /   /
    // -10  5
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
    /**
     * Definition for a binary tree node.
     * public class TreeNode {
     *     public int val;
     *     public TreeNode left;
     *     public TreeNode right;
     *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
     *         this.val = val;
     *         this.left = left;
     *         this.right = right;
     *     }
     * }
     */
    public class Solution
    {
        public TreeNode SortedListToBST(ListNode head)
        {
            if (head == null)
                return null;

            var mid = FindMiddleNode(head);
            var node = new TreeNode(mid.val);

            if (mid == head)
                return node;

            node.left = SortedListToBST(head);
            node.right = SortedListToBST(mid.next);

            return node;
        }

        ListNode FindMiddleNode(ListNode head)
        {
            ListNode prev = null;
            ListNode slow = head;
            ListNode fast = head;

            while (fast != null && fast.next != null)
            {
                prev = slow;
                slow = slow.next;
                fast = fast.next.next;
            }

            if (prev != null)
                prev.next = null;

            return slow;
        }
    }
}

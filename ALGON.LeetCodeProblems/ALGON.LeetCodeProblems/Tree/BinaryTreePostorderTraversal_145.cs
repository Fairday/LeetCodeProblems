using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.Tree
{
    //Given the root of a binary tree, return the postorder traversal of its nodes' values.

    //Follow up: Recursive solution is trivial, could you do it iteratively?

    //Example 1:
    //Input: root = [1,null,2,3]
    //    Output: [3,2,1]
    //    Example 2:

    //Input: root = []
    //    Output: []
    //    Example 3:

    //Input: root = [1]
    //    Output: [1]
    //    Example 4:


    //Input: root = [1,2]
    //    Output: [2,1]
    //    Example 5:


    //Input: root = [1,null,2]
    //    Output: [2,1]

    //    Constraints:

    //The number of the nodes in the tree is in the range[0, 100].
    //-100 <= Node.val <= 100
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
    public class Solution_145
    {
        //TC: O(n)
        //SC: O(1) + recursive stack
        public IList<int> PostorderTraversal1(TreeNode root)
        {
            var postorder = new List<int>();

            if (root == null)
            {
                return postorder;
            }

            PostOrderTraversalRecursive(root, postorder);

            return postorder;
        }

        void PostOrderTraversalRecursive(TreeNode root, IList<int> postorder)
        {
            if (root != null)
            {
                PostOrderTraversalRecursive(root.left, postorder);
                PostOrderTraversalRecursive(root.right, postorder);
                postorder.Add(root.val);
            }
        }

        //TC: O(n)
        //SC: O(n)
        public IList<int> PostorderTraversal(TreeNode root)
        {
            var postorder = new List<int>();

            if (root == null)
            {
                return postorder;
            }

            PostOrderTraversalIterative(root, postorder);

            return postorder;
        }

        void PostOrderTraversalIterative(TreeNode root, IList<int> postorder)
        {
            var stack = new Stack<TreeNode>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                var next = stack.Peek();
                bool isLeaf = next.left == null && next.right == null;
                bool subtreeTraversed = next.left == root || next.right == root;
                if (isLeaf || subtreeTraversed)
                {
                    stack.Pop();
                    postorder.Add(next.val);
                    root = next;
                }
                else
                {
                    if (next.right != null)
                        stack.Push(next.right);
                    if (next.left != null)
                        stack.Push(next.left);
                }
            }
        }
    }
}

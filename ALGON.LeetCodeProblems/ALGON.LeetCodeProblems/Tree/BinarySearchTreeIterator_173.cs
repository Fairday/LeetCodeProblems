using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.Tree
{
    /*Implement an iterator over a binary search tree(BST). Your iterator will be initialized with the root node of a BST.

    Calling next() will return the next smallest number in the BST.

    Example:

        7
      /   \
    3       15
          /    \
         9      20


    BSTIterator iterator = new BSTIterator(root);
        iterator.next();    // return 3
    iterator.next();    // return 7
    iterator.hasNext(); // return true
    iterator.next();    // return 9
    iterator.hasNext(); // return true
    iterator.next();    // return 15
    iterator.hasNext(); // return true
    iterator.next();    // return 20
    iterator.hasNext(); // return false
 
    Note:

    next() and hasNext() should run in average O(1) time and uses O(h) memory, where h is the height of the tree.
    You may assume that next() call will always be valid, that is, there will be at least a next smallest number in the BST when next() is called.*/
    public class BSTIterator
    {
        Queue<int> nodes;

        public BSTIterator(TreeNode root)
        {
            nodes = new Queue<int>();
            InOrder(nodes, root);
        }

        /** @return the next smallest number */
        public int Next()
        {
            return nodes.Dequeue();
        }

        /** @return whether we have a next smallest number */
        public bool HasNext()
        {
            return nodes.Count > 0;
        }

        void InOrder(Queue<int> nodes, TreeNode node)
        {
            if (node != null)
            {
                InOrder(nodes, node.left);
                nodes.Enqueue(node.val);
                InOrder(nodes, node.right);
            }
        }
    }

    /**
     * Your BSTIterator object will be instantiated and called as such:
     * BSTIterator obj = new BSTIterator(root);
     * int param_1 = obj.Next();
     * bool param_2 = obj.HasNext();
     */
}

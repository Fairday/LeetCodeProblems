using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.Tree
{
    /*Given a complete binary tree, count the number of nodes.

    Note:

    Definition of a complete binary tree from Wikipedia:
    In a complete binary tree every level, except possibly the last, is completely filled, and all nodes in the last level are as far left as possible.It can have between 1 and 2h nodes inclusive at the last level h.

    Example:

    Input: 
        1
       / \
      2   3
     / \  /
    4  5 6


    Output: 6*/
    public class Solution_222
    {
        public int CountNodes(TreeNode root)
        {
            if (root == null)
                return 0;
            var nodes = 0;
            var q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                var node = q.Dequeue();
                nodes++;
                if (node.left != null)
                    q.Enqueue(node.left);
                if (node.right != null)
                    q.Enqueue(node.right);
            }
            return nodes;
        }
    }
}

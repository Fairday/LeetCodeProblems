using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.Tree
{
    /*Given a binary tree, imagine yourself standing on the right side of it, return the values of the nodes you can see ordered from top to bottom.

    Example:

    Input: [1,2,3,null,5,null,4]
        Output: [1, 3, 4]
        Explanation:

       1            <---
     /   \
    2     3         <---
     \     \
      5     4       <---*/
    public class Solution_199
    {
        public IList<int> RightSideView(TreeNode root)
        {
            var rightSideView = new List<int>();

            if (root == null)
                return rightSideView;

            var q = new Queue<TreeNode>();
            q.Enqueue(root);

            while (q.Count > 0)
            {
                var nodes = q.Count;
                TreeNode last = null;
                while (nodes > 0)
                {
                    last = q.Dequeue();
                    if (last.left != null)
                        q.Enqueue(last.left);
                    if (last.right != null)
                        q.Enqueue(last.right);
                    nodes--;
                }
                rightSideView.Add(last.val);
            }
            return rightSideView;
        }
    }
}

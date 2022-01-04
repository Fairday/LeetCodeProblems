using System.Collections.Generic;
using System.Linq;

namespace Problems.BinaryTrees
{
    //Given the root of a binary tree, return the level order traversal of its nodes' values. (i.e., from left to right, level by level).

    //Example 1:


    //Input: root = [3,9,20,null,null,15,7]
    //    Output: [[3],[9,20],[15,7]]
    //Example 2:

    //Input: root = [1]
    //    Output: [[1]]
    //Example 3:

    //Input: root = []
    //    Output: []

    //    Constraints:

    //The number of nodes in the tree is in the range[0, 2000].
    //-1000 <= Node.val <= 1000
    public class BinaryTreeLevelOrderTraversal_102
    {    
        //TC: O(m), where m - node count
        //SC: O(m), where m - levels count, height of tree
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            var res = new List<IList<int>>();

            if (root == null)
                return res;

            var queue = new Queue<IList<TreeNode>>();
            queue.Enqueue(new List<TreeNode> { root });
            while (queue.Count != 0)
            {
                var level = queue.Dequeue();
                res.Add(level.Select(n => n.val).ToList());
                var toEnqueue = new List<TreeNode>();
                foreach (var node in level)
                {
                    if (node.left != null)
                        toEnqueue.Add(node.left);
                    if (node.right != null)
                        toEnqueue.Add(node.right);
                }
                if (toEnqueue.Count > 0)
                    queue.Enqueue(toEnqueue);
            }

            return res;
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
    }
}
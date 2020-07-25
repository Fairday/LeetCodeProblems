using System.Collections.Generic;
using System.Linq;

namespace ALGON.LeetCodeProblems.Tree
{
    /*Given a binary tree and a sum, find all root-to-leaf paths where each path's sum equals the given sum.

    Note: A leaf is a node with no children.

    Example:

    Given the below binary tree and sum = 22,

          5
         / \
        4   8
       /   / \
      11  13  4
     /  \    / \
    7    2  5   1
    Return:

    [
       [5,4,11,2],
       [5,8,4,5]
    ]*/
    public class Solution_113
    {
        public IList<IList<int>> PathSum(TreeNode root, int sum)
        {
            var paths = new List<IList<int>>();

            if (root == null)
                return paths;

            dfs(paths, new List<int>(), 0, sum, root);
            return paths;
        }

        void dfs(List<IList<int>> paths, List<int> subpath, int subsum, int sum, TreeNode node)
        {
            if (subsum + node.val == sum && (node.left == null && node.right == null))
            {
                subpath.Add(node.val);
                paths.Add(subpath.ToList());
                return;
            }

            subpath.Add(node.val);

            if (node.left != null)
                dfs(paths, subpath.ToList(), subsum + node.val, sum, node.left);
            if (node.right != null)
                dfs(paths, subpath.ToList(), subsum + node.val, sum, node.right);
        }
    }
}

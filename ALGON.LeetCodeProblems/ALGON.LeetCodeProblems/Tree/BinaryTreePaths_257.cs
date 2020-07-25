using System.Collections.Generic;
using System.Text;

namespace ALGON.LeetCodeProblems.Tree
{
    /*Given a binary tree, return all root-to-leaf paths.

    Note: A leaf is a node with no children.

    Example:

    Input:

       1
     /   \
    2     3
     \
      5

    Output: ["1->2->5", "1->3"]

    Explanation: All root-to-leaf paths are: 1->2->5, 1->3*/
    public class Solution_257
    {
        public IList<string> BinaryTreePaths(TreeNode root)
        {
            var paths = new List<string>();

            if (root == null)
                return paths;

            dfs(paths, new StringBuilder(), root);

            return paths;
        }

        void dfs(List<string> paths, StringBuilder sb, TreeNode node)
        {
            sb.Append(node.val);

            if (node.left == null && node.right == null)
            {
                paths.Add(sb.ToString());
            }
            else
            {
                sb.Append("->");
                if (node.left != null)
                    dfs(paths, new StringBuilder(sb.ToString()), node.left);
                if (node.right != null)
                    dfs(paths, new StringBuilder(sb.ToString()), node.right);
            }
        }
    }
}

namespace ALGON.LeetCodeProblems.Tree
{
    /*Find the sum of all left leaves in a given binary tree.

    Example:

        3
       / \
      9  20
        /  \
       15   7

    There are two left leaves in the binary tree, with values 9 and 15 respectively.Return 24.*/
    public class Solution_404
    {
        int sum = 0;

        public int SumOfLeftLeaves(TreeNode root)
        {
            if (root == null)
                return sum;

            dfs(root.left, true);
            dfs(root.right, false);
            return sum;
        }

        void dfs(TreeNode node, bool left)
        {
            if (node == null)
                return;

            if (node.left == null && node.right == null && left)
            {
                sum += node.val;
            }
            else
            {
                dfs(node.left, true);
                dfs(node.right, false);
            }
        }
    }
}

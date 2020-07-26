using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.Tree
{
    /*Given a Binary Search Tree and a target number, return true if there exist two elements in the BST such that their sum is equal to the given target.

    Example 1:

    Input: 
        5
       / \
      3   6
     / \   \
    2   4   7

    Target = 9

    Output: True


    Example 2:

    Input: 
        5
       / \
      3   6
     / \   \
    2   4   7

    Target = 28

    Output: False*/
    public class Solution_653
    {
        //BST + hash
        public bool FindTarget1(TreeNode root, int k)
        {
            if (root == null)
                return false;
            var q = new Queue<TreeNode>();
            var set = new HashSet<int>();
            q.Enqueue(root);

            while (q.Count > 0)
            {
                var node = q.Dequeue();
                if (set.Contains(k - node.val))
                    return true;
                set.Add(node.val);
                if (node.left != null)
                    q.Enqueue(node.left);
                if (node.right != null)
                    q.Enqueue(node.right);
            }

            return false;
        }

        // Using DFS feature (ordering)
        public bool FindTarget(TreeNode root, int k)
        {
            if (root == null)
                return false;

            var inorder = new List<int>();
            Inorder(inorder, root);
            var l = 0;
            var r = inorder.Count - 1;
            while (l < r)
            {
                var sum = inorder[l] + inorder[r];
                if (sum == k)
                    return true;

                if (sum < k)
                    l++;
                else
                    r--;
            }

            return false;
        }

        void Inorder(List<int> inorder, TreeNode node)
        {
            if (node == null)
                return;
            Inorder(inorder, node.left);
            inorder.Add(node.val);
            Inorder(inorder, node.right);
        }
    }
}

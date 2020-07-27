using System;
using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.Tree
{
    /*Given inorder and postorder traversal of a tree, construct the binary tree.

    Note:
    You may assume that duplicates do not exist in the tree.

    For example, given

    inorder = [9, 3, 15, 20, 7]
    postorder = [9, 15, 7, 20, 3]
    Return the following binary tree:

        3
       / \
      9  20
        /  \
       15   7*/
    public class Solution_106
    {
        int processed = 0;

        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            if (inorder.Length == 0 || postorder.Length == 0)
                return null;

            return Helper(inorder, postorder);
        }

        TreeNode Helper(int[] inorder, int[] postorder)
        {
            if (inorder.Length == 0)
                return null;

            var last = GetLast(inorder, postorder);
            var node = new TreeNode(last);

            var left = new List<int>();
            var right = new List<int>();
            var toLeft = true;
            for (int i = 0; i < inorder.Length; i++)
            {
                if (inorder[i] == last)
                {
                    toLeft = false;
                    continue;
                }

                if (toLeft)
                    left.Add(inorder[i]);
                else
                    right.Add(inorder[i]);
            }

            node.left = Helper(left.ToArray(), postorder);
            node.right = Helper(right.ToArray(), postorder);
            return node;
        }

        int GetLast(int[] inorder, int[] postorder)
        {
            var last = 0;

            for (int i = postorder.Length - 1 - processed; i >= 0; i--)
            {
                var pos = Array.IndexOf(inorder, postorder[i]);
                if (pos != -1)
                {
                    last = pos;
                    break;
                }
            }

            //Subtree of postorder[postorder.Length - 1 - processed] constructed
            if (inorder[last] == postorder[postorder.Length - 1 - processed])
                processed++;

            return inorder[last];
        }
    }
}

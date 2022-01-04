using System;
using System.Collections.Generic;
using System.Text;

namespace Day8.BfsDfs
{
    //You are given two binary trees root1 and root2.

    //Imagine that when you put one of them to cover the other, some nodes of the two trees are overlapped while the others are not. You need to merge the two trees into a new binary tree. The merge rule is that if two nodes overlap, then sum node values up as the new value of the merged node. Otherwise, the NOT null node will be used as the node of the new tree.

    //Return the merged tree.

    //Note: The merging process must start from the root nodes of both trees.



    //Example 1:


    //Input: root1 = [1,3,2,5], root2 = [2,1,3,null,4,null,7]
    //Output: [3,4,5,5,4,null,7]
    //Example 2:

    //Input: root1 = [1], root2 = [1,2]
    //Output: [2,2]


    //Constraints:

    //The number of nodes in both trees is in the range [0, 2000].
    //-104 <= Node.val <= 104
    public class MergeTwoBinaryTrees_617
    {    
        //TC: O(m), where m - nodes need to be traversed. 
        //where m stands for "the number of overlapping nodes between the two trees"
        //SC: O(m) - depth of the recusrion tree
        public TreeNode MergeTrees_Recursive(TreeNode root1, TreeNode root2)
        {
            if (root1 == null)
                return root2;
            if (root2 == null)
                return root1;

            root1.val += root2.val;
            root1.left = MergeTrees_Recursive(root1.left, root2.left);
            root1.right = MergeTrees_Recursive(root1.right, root2.right);
            return root1;
        }

        //TC: O(n), where n - minimum from 2 trees nodes need to be traversed. 
        //SC: O(n)
        public TreeNode MergeTrees_Iterative(TreeNode root1, TreeNode root2)
        {
            if (root1 == null)
                return root2;

            Stack<TreeNode[]> stack = new Stack<TreeNode[]>();
            stack.Push(new TreeNode[] { root1, root2 });
            while (stack.Count != 0)
            {
                TreeNode[] t = stack.Pop();
                if (t[0] == null || t[1] == null)
                    continue;
                t[0].val += t[1].val;
                if (t[0].left == null)
                    t[0].left = t[1].left;
                else
                    stack.Push(new TreeNode[] { t[0].left, t[1].left });

                if (t[0].right == null)
                    t[0].right = t[1].right;
                else
                    stack.Push(new TreeNode[] { t[0].right, t[1].right });
            }

            return root1;
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
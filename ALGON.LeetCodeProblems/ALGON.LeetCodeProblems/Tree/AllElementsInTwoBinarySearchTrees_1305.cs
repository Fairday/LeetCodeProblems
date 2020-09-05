using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.Tree
{
    //Given two binary search trees root1 and root2.

    //Return a list containing all the integers from both trees sorted in ascending order.

    //Example 1:


    //Input: root1 = [2, 1, 4], root2 = [1, 0, 3]
    //Output: [0,1,1,2,3,4]
    //Example 2:

    //Input: root1 = [0, -10, 10], root2 = [5, 1, 7, 0, 2]
    //Output: [-10,0,0,1,2,5,7,10]
    //Example 3:

    //Input: root1 = [], root2 = [5, 1, 7, 0, 2]
    //Output: [0,1,2,5,7]
    //Example 4:

    //Input: root1 = [0, -10, 10], root2 = []
    //Output: [-10,0,10]
    //Example 5:


    //Input: root1 = [1, null, 8], root2 = [8, 1]
    //Output: [1,1,8,8]


    //Constraints:

    //Each tree has at most 5000 nodes.
    //Each node's value is between [-10^5, 10^5].
    /**
     * Definition for a binary tree node.
     * public class TreeNode {
     *     public int val;
     *     public TreeNode left;
     *     public TreeNode right;
     *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
     *         this.val = val;
     *         this.left = left;
     *         this.right = right;
     *     }
     * }
     */
    public class Solution_1305
    {
        //TC: O(n)
        //SC: O(n)
        public IList<int> GetAllElements(TreeNode root1, TreeNode root2)
        {
            if (root1 == null && root2 == null)
                return new List<int>();
            else if (root1 == null)
                return InorderTraverse(root2);
            else if (root2 == null)
                return InorderTraverse(root1);
            else
                return Merge(InorderTraverse(root1), InorderTraverse(root2));
        }

        //TC: O(n)
        //SC: O(n)
        IList<int> InorderTraverse(TreeNode root)
        {
            List<int> inorder = new List<int>();

            var curr = root;
            var stack = new Stack<TreeNode>();

            while (curr != null || stack.Count > 0)
            {
                while (curr != null)
                {
                    stack.Push(curr);
                    curr = curr.left;
                }

                var node = stack.Pop();
                inorder.Add(node.val);
                curr = node.right;
            }

            return inorder;
        }

        //TC: O(n)
        //SC: O(n)
        IList<int> Merge(IList<int> arr1, IList<int> arr2)
        {
            var res = new List<int>(arr1.Count + arr2.Count);

            var i = 0;
            var j = 0;

            while (i < arr1.Count && j < arr2.Count)
            {
                if (arr1[i] < arr2[j])
                    res.Add(arr1[i++]);
                else
                    res.Add(arr2[j++]);
            }

            for (; i < arr1.Count; i++)
                res.Add(arr1[i]);
            for (; j < arr2.Count; j++)
                res.Add(arr2[j]);

            return res;
        }
    }
}

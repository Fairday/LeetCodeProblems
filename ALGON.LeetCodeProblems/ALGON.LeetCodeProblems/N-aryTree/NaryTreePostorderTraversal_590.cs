using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.N_aryTree
{
    //Given an n-ary tree, return the postorder traversal of its nodes' values.

    //Nary-Tree input serialization is represented in their level order traversal, each group of children is separated by the null value(See examples).

    //Follow up:

    //Recursive solution is trivial, could you do it iteratively?

    //Example 1:

    //Input: root = [1,null,3,2,4,null,5,6]
    //    Output: [5,6,3,2,4,1]
    //    Example 2:

    //Input: root = [1,null,2,3,4,5,null,null,6,7,null,8,null,9,10,null,null,11,null,12,null,13,null,null,14]
    //    Output: [2,6,14,11,7,3,12,8,4,13,9,10,5,1]


    //    Constraints:

    //The height of the n-ary tree is less than or equal to 1000
    //The total number of nodes is between[0, 10 ^ 4]
    public class Solution_590
    {
        public IList<int> Postorder(Node root)
        {
            var postorder = new List<int>() { };

            if (root == null)
            {
                return postorder;
            }

            PostOrderTraversalIterative(root, postorder);

            return postorder;
        }

        void PostOrderTraversalIterative(Node root, IList<int> postorder)
        {
            var stack = new Stack<Node>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                var next = stack.Peek();
                bool isLeaf = next.children.Count == 0;
                bool subtreeTraversed = next.children.Contains(root);
                if (isLeaf || subtreeTraversed)
                {
                    stack.Pop();
                    postorder.Add(next.val);
                    root = next;
                }
                else
                {
                    for (int i = next.children.Count - 1; i >= 0; i--)
                        stack.Push(next.children[i]);
                }
            }
        }
    }
}

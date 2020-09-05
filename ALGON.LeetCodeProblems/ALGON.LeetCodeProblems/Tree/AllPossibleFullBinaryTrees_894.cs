using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.Tree
{
    //A full binary tree is a binary tree where each node has exactly 0 or 2 children.

    //Return a list of all possible full binary trees with N nodes.Each element of the answer is the root node of one possible tree.

    //Each node of each tree in the answer must have node.val = 0.

    //You may return the final list of trees in any order.
    //Input: 7
    //Output: [[0,0,0,null,null,0,0,null,null,0,0],[0,0,0,null,null,0,0,0,0],[0,0,0,0,0,0,0],[0,0,0,0,0,null,null,null,null,0,0],[0,0,0,0,0,null,null,0,0]]
    public class Solution_894
    {
        //Key - input, Value - Root of subtree
        Dictionary<int, IList<TreeNode>> memo = new Dictionary<int, IList<TreeNode>>();

        //TC: O(2 ^ N)
        //SC: O(2 ^ N)
        //https://leetcode.com/problems/all-possible-full-binary-trees/solution/
        public IList<TreeNode> AllPossibleFBT(int N)
        {
            if (!memo.ContainsKey(N))
            {
                var subtrees = new List<TreeNode>();
                memo[N] = subtrees;

                if (N == 1)
                {
                    subtrees.Add(new TreeNode(0));
                }
                else if (N % 2 == 1)
                {
                    for (int i = 0; i < N; i++)
                    {
                        //N = 5
                        //{x, y} = {0, 4}
                        //{x, y} = {1, 3}
                        //{x, y} = {2, 2}
                        //{x, y} = {3, 1}
                        //{x, y} = {4, 0}

                        var x = i;
                        var y = N - 1 - x;

                        foreach (var left in AllPossibleFBT(x))
                            foreach (var right in AllPossibleFBT(y))
                            {
                                var root = new TreeNode(0);
                                root.left = left;
                                root.right = right;
                                subtrees.Add(root);
                            }
                    }
                }

                return subtrees;
            }

            return memo[N];
        }
    }
}

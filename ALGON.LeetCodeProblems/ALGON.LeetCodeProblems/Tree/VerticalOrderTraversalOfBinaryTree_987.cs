using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.Tree
{
    /*Given a binary tree, return the vertical order traversal of its nodes values.

    For each node at position (X, Y), its left and right children respectively will be at positions (X-1, Y-1) and(X+1, Y-1).

    Running a vertical line from X = -infinity to X = +infinity, whenever the vertical line touches some nodes, we report the values of the nodes in order from top to bottom(decreasing Y coordinates).

    If two nodes have the same position, then the value of the node that is reported first is the value that is smaller.

    Return an list of non-empty reports in order of X coordinate.Every report will have a list of values of nodes.



    Example 1:



    Input: [3,9,20,null,null,15,7]
    Output: [[9], [3,15], [20], [7]]
    Explanation: 
    Without loss of generality, we can assume the root node is at position(0, 0):
    Then, the node with value 9 occurs at position(-1, -1);
        The nodes with values 3 and 15 occur at positions(0, 0) and(0, -2);
        The node with value 20 occurs at position(1, -1);
        The node with value 7 occurs at position(2, -2).
    Example 2:



    Input: [1,2,3,4,5,6,7]
        Output: [[4],[2],[1,5,6],[3],[7]]
    Explanation: 
    The node with value 5 and the node with value 6 have the same position according to the given scheme.
    However, in the report "[1,5,6]", the node value of 5 comes first since 5 is smaller than 6.
 

    Note:

    The tree will have between 1 and 1000 nodes.
    Each node's value will be between 0 and 1000.
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

    public class Solution_987
    {
        //O(n logn), where O(n) - visit all nodes, logn - insert into SortedDictionary
        public IList<IList<int>> VerticalTraversal(TreeNode root)
        {
            var res = new List<IList<int>>();

            if (root == null)
                return res;

            var sortedDictionary = new SortedDictionary<int, SortedDictionary<int, List<int>>>();

            helper(0, sortedDictionary, root, 0);

            foreach (var order in sortedDictionary)
            {
                var level = new List<int>();

                foreach (var onHeight in order.Value)
                {
                    onHeight.Value.Sort();
                    level.AddRange(onHeight.Value);
                }

                res.Add(level);
            }

            return res;
        }

        void helper(int pos, SortedDictionary<int, SortedDictionary<int, List<int>>> map, TreeNode node, int height)
        {
            if (node == null)
                return;

            if (!map.ContainsKey(pos))
            {
                map[pos] = new SortedDictionary<int, List<int>>();
            }
            if (!map[pos].ContainsKey(height))
            {
                map[pos][height] = new List<int>();
            }
            map[pos][height].Add(node.val);

            helper(pos - 1, map, node.left, height + 1);
            helper(pos + 1, map, node.right, height + 1);
        }
    }
}

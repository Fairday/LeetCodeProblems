namespace ALGON.LeetCodeProblems.Tree
{
    //Given the root node of a binary search tree, return the sum of values of all nodes with value between L and R(inclusive).

    //The binary search tree is guaranteed to have unique values.

    //Example 1:

    //Input: root = [10,5,15,3,7,null,18], L = 7, R = 15
    //Output: 32
    //Example 2:

    //Input: root = [10,5,15,3,7,13,18,1,null,6], L = 6, R = 10
    //Output: 23
 
    //Note:

    //The number of nodes in the tree is at most 10000.
    //The final answer is guaranteed to be less than 2^31.
    public class Solution
    {
        //TC: O(N), where N - nodes in tree
        //SC: O(H), where H - height of tree (recursive space)
        public int RangeSumBST(TreeNode root, int L, int R)
        {
            var sum = 0;
            if (root == null)
                return sum;
            if (root.val > L)
                sum += RangeSumBST(root.left, L, R);
            if (root.val < R)
                sum += RangeSumBST(root.right, L, R);
            if (root.val >= L && root.val <= R)
                sum += root.val;
            return sum;
        }
    }
}

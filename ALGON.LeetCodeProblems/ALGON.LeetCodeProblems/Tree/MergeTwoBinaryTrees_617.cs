namespace ALGON.LeetCodeProblems.Tree
{
    /*Given two binary trees and imagine that when you put one of them to cover the other, some nodes of the two trees are overlapped while the others are not.

	    You need to merge them into a new binary tree.The merge rule is that if two nodes overlap, then sum node values up as the new value of the merged node.Otherwise, the NOT null node will be used as the node of new tree.

      Example 1:

    Input: 
	    Tree 1                     Tree 2                  
              1                         2                             
             / \                       / \                            
            3   2                     1   3                        
           /                           \   \                      
          5                             4   7                  
    Output: 
    Merged tree:
	         3
	        / \
	       4   5
	      / \   \ 
	     5   4   7
 

    Note: The merging process must start from the root nodes of both trees.*/
    public class Solution_617
    {
        public TreeNode MergeTrees(TreeNode t1, TreeNode t2)
        {
            return PreOrderTraversal(t1, t2);
        }

        TreeNode PreOrderTraversal(TreeNode t1, TreeNode t2)
        {
            if (t1 == null && t2 == null) return null;
            else if (t1 == null)
                return t2;
            else if (t2 == null)
                return t1;
            else
            {
                t1.val += t2.val;
                var leftSuccessor = PreOrderTraversal(t1.left, t2.left);
                var rightSuccessor = PreOrderTraversal(t1.right, t2.right);
                t1.left = leftSuccessor;
                t1.right = rightSuccessor;
                return t1;
            }
        }
    }
}

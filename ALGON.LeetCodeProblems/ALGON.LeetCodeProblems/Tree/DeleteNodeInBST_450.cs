namespace ALGON.LeetCodeProblems.Tree
{
    //Given a root node reference of a BST and a key, delete the node with the given key in the BST.Return the root node reference (possibly updated) of the BST.

    //Basically, the deletion can be divided into two stages:

    //Search for a node to remove.
    //If the node is found, delete the node.
    //    Note: Time complexity should be O(height of tree).

    //Example:

    //root = [5,3,6,2,4,null,7]
    //    key = 3

    //    5
    //   / \
    //  3   6
    // / \   \
    //2   4   7

    //Given key to delete is 3. So we find the node with value 3 and delete it.

    //One valid answer is [5,4,6,2,null,null,7], shown in the following BST.

    //    5
    //   / \
    //  4   6
    // /     \
    //2       7

    //Another valid answer is [5,2,6,null,4,null,7].

    //    5
    //   / \
    //  2   6
    //   \   \
    //    4   7
    public class Solution_450
    {
        //More consise solution, backtracking
        //TC: O(H), where H - height of tree
        //SC: O(H)
        public TreeNode DeleteNode(TreeNode root, int key)
        {
            if (root == null)
                return null;
            else if (root.val > key)
                root.left = DeleteNode(root.left, key);
            else if (root.val < key)
                root.right = DeleteNode(root.right, key);
            else
            {
                if (root.left == null)
                    return root.right;
                else if (root.right == null)
                    return root.left;

                var succ = GetSuccessor(root);
                root.val = succ.val;
                root.right = DeleteNode(root.right, succ.val);
            }
            return root;
        }

        TreeNode GetSuccessor(TreeNode root)
        {
            var curr = root.right;
            while (curr != null && curr.left != null)
                curr = curr.left;
            return curr;
        }

        //TC: O(H), where H - height of tree
        //SC: O(H)
        public TreeNode DeleteNode1(TreeNode root, int key)
        {
            if (root == null)
                return null;

            var removingNodeWithParent = FindRemovingNode(root, null, key);

            if (removingNodeWithParent == null)
                return root;

            var parent = removingNodeWithParent.Item2;
            var removingNode = removingNodeWithParent.Item1;

            if (IsLeaf(removingNode))
            {
                if (parent == null)
                    return null;
                else
                {
                    if (parent.left == removingNode)
                        parent.left = null;
                    else
                        parent.right = null;
                    return root;
                }
            }
            else if (removingNode.left != null && removingNode.right == null)
            {
                if (parent == null)
                    return removingNode.left;

                if (parent.left == removingNode)
                    parent.left = removingNode.left;
                else
                    parent.right = removingNode.left;
            }
            else if (removingNode.left == null && removingNode.right != null)
            {
                if (parent == null)
                    return removingNode.right;

                if (parent.left == removingNode)
                    parent.left = removingNode.right;
                else
                    parent.right = removingNode.right;
            }
            else
            {
                var leftMostNode = FindLeftMostNode(removingNode.right, removingNode);

                if (leftMostNode != removingNode.right)
                    leftMostNode.right = removingNode.right;

                leftMostNode.left = removingNode.left;

                if (parent != null)
                {
                    if (parent.left == removingNode)
                        parent.left = leftMostNode;
                    else
                        parent.right = leftMostNode;
                }
                else
                    return leftMostNode;
            }

            return root;
        }

        TreeNode FindLeftMostNode(TreeNode node, TreeNode parent)
        {
            if (node.left == null)
            {
                if (parent.right != node)
                    parent.left = node.right;
                return node;
            }
            else
                return FindLeftMostNode(node.left, node);
        }

        System.Tuple<TreeNode, TreeNode> FindRemovingNode(TreeNode node, TreeNode parent, int key)
        {
            if (node == null)
                return null;

            if (node.val == key)
                return System.Tuple.Create(node, parent);
            else if (node.val > key)
                return FindRemovingNode(node.left, node, key);
            else
                return FindRemovingNode(node.right, node, key);
        }

        bool IsLeaf(TreeNode node)
        {
            return node.left == null && node.right == null;
        }
    }
}

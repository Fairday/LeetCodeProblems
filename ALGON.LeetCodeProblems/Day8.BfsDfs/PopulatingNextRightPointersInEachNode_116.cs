namespace Day8.BfsDfs
{
    //You are given a perfect binary tree where all leaves are on the same level, and every parent has two children.The binary tree has the following definition:

    //struct Node
    //    {
    //        int val;
    //        Node* left;
    //        Node* right;
    //        Node* next;
    //    }
    //    Populate each next pointer to point to its next right node.If there is no next right node, the next pointer should be set to NULL.

    //   Initially, all next pointers are set to NULL.



    //   Example 1:


    //Input: root = [1,2,3,4,5,6,7]
    //    Output: [1,#,2,3,#,4,5,6,7,#]
    //Explanation: Given the above perfect binary tree(Figure A), your function should populate each next pointer to point to its next right node, just like in Figure B.The serialized output is in level order as connected by the next pointers, with '#' signifying the end of each level.
    //    Example 2:


    //    Input: root = []
    //    Output: []


    //    Constraints:

    //The number of nodes in the tree is in the range[0, 212 - 1].
    //-1000 <= Node.val <= 1000


    //Follow-up:

    //You may only use constant extra space.
    //The recursive approach is fine.You may assume implicit stack space does not count as extra space for this problem.
    public class PopulatingNextRightPointersInEachNode_116
    {   
        //TC: O(m)  where m is node count
        //SC: O(h) - h - height of tree
        public Node Connect(Node root)
        {
            if (root == null || root.left == null)
                return root;

            ConnectNodes(root.left, root.right);
            return root;
        }

        private void ConnectNodes(Node node1, Node node2)
        {
            node1.next = node2;
            if (node1.left != null)
            {
                //under same node
                //   2
                // 1 -> 3
                ConnectNodes(node1.left, node1.right);
                //between 2 branches (side leaves)
                //   2    4
                //  1 3 -> 5 6
                ConnectNodes(node1.right, node2.left);
                //under same node
                ConnectNodes(node2.left, node2.right);
            }
        }

        // Definition for a Node.
        public class Node
        {
            public int val;
            public Node left;
            public Node right;
            public Node next;

            public Node() { }

            public Node(int _val)
            {
                val = _val;
            }

            public Node(int _val, Node _left, Node _right, Node _next)
            {
                val = _val;
                left = _left;
                right = _right;
                next = _next;
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.Tree
{
    /*Serialization is the process of converting a data structure or object into a sequence of bits so that it can be stored in a file or memory buffer, or transmitted across a network connection link to be reconstructed later in the same or another computer environment.

    Design an algorithm to serialize and deserialize a binary tree.There is no restriction on how your serialization/deserialization algorithm should work. You just need to ensure that a binary tree can be serialized to a string and this string can be deserialized to the original tree structure.

    Example: 

    You may serialize the following tree:

        1
       / \
      2   3
         / \
        4   5

    as "[1,2,3,null,null,4,5]"
    Clarification: The above format is the same as how LeetCode serializes a binary tree. You do not necessarily need to follow this format, so please be creative and come up with different approaches yourself.

    Note: Do not use class member/global/static variables to store states.Your serialize and deserialize algorithms should be stateless.*/
    /**
     * Definition for a binary tree node.
     * public class TreeNode {
     *     public int val;
     *     public TreeNode left;
     *     public TreeNode right;
     *     public TreeNode(int x) { val = x; }
     * }
     */
    public class Codec
    {

        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            var encoded = Encode(root);
            Console.WriteLine(encoded);
            return encoded;
        }

        string Encode(TreeNode node)
        {
            if (node == null)
                return "#,";
            else
            {
                var left = Encode(node.left);
                var right = Encode(node.right);
                return node.val.ToString() + "," + left + right;
            }
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            var nodesLeft = data.Split(',');
            return Decode(new Queue<string>(nodesLeft));
        }

        TreeNode Decode(Queue<string> nodesLeft)
        {
            var valueFromNode = nodesLeft.Dequeue();
            if (valueFromNode == "#")
                return null;

            var node = new TreeNode(int.Parse(valueFromNode));

            node.left = Decode(nodesLeft);
            node.right = Decode(nodesLeft);

            return node;
        }
    }

    // Your Codec object will be instantiated and called as such:
    // Codec codec = new Codec();
    // codec.deserialize(codec.serialize(root));
}

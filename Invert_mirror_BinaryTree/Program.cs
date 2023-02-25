using System;
using System.Xml.Linq;

namespace Invert_mirror_BinaryTree
{
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
    public class Solution
    {
        public TreeNode InvertTree(TreeNode root)
        {
            if(root == null) return null;

            TreeNode left = InvertTree(root.left);
            TreeNode right = InvertTree(root.right);
            root.left = right;
            root.right = left;
            return root;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            TreeNode tree = new TreeNode(2);
            tree.left = new TreeNode(1);
            tree.right = new TreeNode(4);
            tree.right.left = new TreeNode(3);
            tree.right.right = new TreeNode(5);
            Console.WriteLine("Hello World!");
        }
    }
}

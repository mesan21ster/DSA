using System;

namespace MaximumDepthofBinaryTree
{
    internal class Program
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
            public int MaxDepth(TreeNode root)
            {
                if(root == null) return 0;
                int left=MaxDepth(root.left);
                int right=MaxDepth(root.right);
                return Math.Max(left, right) +1;
            }
        }
        static void Main(string[] args)
        {
            TreeNode noderoot = new TreeNode();
            noderoot.left = new TreeNode(1);
            Console.WriteLine("Hello World!");
        }
    }
}

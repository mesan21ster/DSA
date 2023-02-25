using System;
using System.Collections.Generic;

namespace MinimumDistanceBetweenBSTNodes_OptimizedApproach
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
        TreeNode prev=null;
        int ans = int.MaxValue;
        public int MinDiffInBST(TreeNode root)
        {
            InOrderTraversal(root);
            return ans;
        }

        private void InOrderTraversal(TreeNode root)
        {
            if (root != null)
            {
                InOrderTraversal(root.left);
                if (prev != null)
                {
                    ans = Math.Min(ans, root.val - prev.val);
                }
                prev = root;
                InOrderTraversal(root.right);
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode();
            root.val = 1;
            root.right = new TreeNode();
            root.right.val = 5;
            root.right.left = new TreeNode();
            root.right.left.val = 3;
            root.right.left.left = new TreeNode();
            root.right.left.left.val = 2;
            root.right.left.right = new TreeNode();
            root.right.left.right.val = 4;
            Solution obj = new Solution();
            Console.WriteLine(obj.MinDiffInBST(root));
        }
    }
}

using System;
using System.Collections.Generic;

namespace MinimumDistanceBetweenBSTNodes
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
        public int MinDiffInBST(TreeNode root)
        {
            if(root== null) return 0;
            List<int> list = new List<int>();
            InOrderTraversal(root, list);
            int minDiff = int.MaxValue;

            for (int i = 0; i < list.Count -1; i++)
            {
                minDiff = Math.Min(minDiff, list[i + 1]- list[i]);
            }
            return minDiff;
        }

        private void InOrderTraversal(TreeNode root, List<int> list)
        {
            if(root == null) return;
            InOrderTraversal(root.left, list);
            list.Add(root.val);
            InOrderTraversal(root.right, list);
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
            Solution obj= new Solution();
            Console.WriteLine(obj.MinDiffInBST(root));
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;

namespace BinaryTreeZigzagLevelOrderTraversal
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
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            List<IList<int>> ints = new List<IList<int>>();

            if (root == null) return ints;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int level = 1;
            while (queue != null && queue.Count > 0)
            {
                List<int> lst = new List<int>();
                int size = queue.Count;
              
                for(int i=0;i<size;i++)
                {
                    TreeNode currentNode = queue.Dequeue();
                    lst.Add(currentNode.val);
                    if (currentNode.left != null)
                    {
                        queue.Enqueue(currentNode.left);
                    }
                    if (currentNode.right != null)
                    {
                        queue.Enqueue(currentNode.right);
                    }
                }
                if (level % 2 == 0)
                {
                    List<int> revList = new List<int>();
                    for (int i = lst.Count - 1; i >= 0; i--)
                    {
                        revList.Add(lst[i]);
                    }
                    ints.Add(revList);
                }
                else
                {
                    ints.Add(lst);
                }
                level++;
            }
            return ints;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(9);
            root.right = new TreeNode(20);
            root.right.left = new TreeNode(15);
            root.right.right = new TreeNode(7);
            Solution solution = new Solution();
            var res = solution.ZigzagLevelOrder(root);

            foreach (var item in res)
            {
                foreach (var it in item)
                {
                    Console.WriteLine(it);
                }
            }
            Console.WriteLine("Hello World!");
        }
    }
}

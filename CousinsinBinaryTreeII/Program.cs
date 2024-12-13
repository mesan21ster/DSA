namespace CousinsinBinaryTreeII
{
    // Definition for a binary tree node.
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
        public TreeNode ReplaceValueInTree(TreeNode root)
        {
            List<int> levelsum = new List<int>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                int currlevelsum = 0;
                int n = queue.Count;
                
                
                while (n > 0)
                {
                    TreeNode currnode = queue.Dequeue();
                    currlevelsum += currnode.val;
                    if (currnode.left != null)
                    {
                        queue.Enqueue((TreeNode)currnode.left);
                    }
                    if (currnode.right != null)
                    {
                        queue.Enqueue((TreeNode)currnode.right);
                    }
                    n--;
                }
                levelsum.Add(currlevelsum);
            }
            queue.Enqueue(root);
            root.val = 0;
            int index = 1;

            while (queue.Count > 0)
            {
               int n = queue.Count;
                
                while (n > 0)
                {
                    int cousinsum = 0;
                    TreeNode currnode = queue.Dequeue();
                    if (currnode.left != null)
                    {
                        cousinsum += currnode.left.val;
                    }
                    if (currnode.right != null)
                    {
                        cousinsum += currnode.right.val;
                    }

                    if (currnode.left != null)
                    {
                        currnode.left.val = levelsum[index] - cousinsum;
                        queue.Enqueue(currnode.left);
                    }

                    if (currnode.right != null)
                    {
                        currnode.right.val = levelsum[index] - cousinsum;
                        queue.Enqueue(currnode.right);
                    }
                    n--;
                }
                index++;
            }
            return root;

        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            //root = [5,4,9,1,10,null,7]

            TreeNode root = new TreeNode(5);
            root.left = new TreeNode(4);
            root.right = new TreeNode(9);
            root.left.left = new TreeNode(1);
            root.left.right = new TreeNode(10);
            root.right.right = new TreeNode(7);

            Solution solution = new Solution();
            var res = solution.ReplaceValueInTree(root);
            Console.WriteLine(res);
        }
    }
}
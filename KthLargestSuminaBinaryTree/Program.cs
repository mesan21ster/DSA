namespace KthLargestSuminaBinaryTree
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
        public long KthLargestLevelSum(TreeNode root, int k)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();

            PriorityQueue<long, long> minheap = new PriorityQueue<long, long>();

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int currentLevelSize = queue.Count;
                long currentLevelSum = 0;

                for (int i = 0; i < currentLevelSize; i++)
                {
                    TreeNode currentNode = queue.Dequeue();
                    currentLevelSum += currentNode.val;
                    if (currentNode.left != null)
                    {
                        queue.Enqueue(currentNode.left);
                    }
                    if (currentNode.right != null)
                    {
                        queue.Enqueue(currentNode.right);
                    }
                }

                minheap.Enqueue(currentLevelSum, currentLevelSum);
                
                if (minheap.Count > k)
                {
                    minheap.Dequeue();
                }

               
            }

            if (minheap.Count < k)
                return -1;

            return minheap.Peek();
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Solution solution = new Solution();
            int k = 2;
            TreeNode root = new TreeNode(5);
            root.left = new TreeNode(8);
            root.right = new TreeNode(9);
            root.left.left = new TreeNode(2);
            root.left.right = new TreeNode(1);
            root.right.left = new TreeNode(3);
            root.right.right = new TreeNode(7);
            root.left.left.left = new TreeNode(4);
            root.left.left.right = new TreeNode(6);

            var res = solution.KthLargestLevelSum(root, k);
            Console.WriteLine(res);
        }
    }
}
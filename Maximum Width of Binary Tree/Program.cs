namespace MaximumWidthofBinaryTree
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
            //BFS with level orcer traversal
            int maxWidth = 0;
            public int WidthOfBinaryTree(TreeNode root)
            {
                Queue<(TreeNode, long)> queue = new Queue<(TreeNode, long)>();//declare queue with pair
                queue.Enqueue((root, 0)); // Add root to queue and index is 0
                while (queue.Count > 0)//loop on queue
                {
                    
                    long firstIndex = queue.First().Item2; // get second item as index from pair as top from queue
                    long lastIndex = queue.Last().Item2; // get last index item from last of the queue
                    maxWidth = (int)Math.Max(maxWidth, (lastIndex - firstIndex) + 1); // calculate max , +1 is here for because it is zero index and it will to include last index as well
                    int size = queue.Count;
                    while (size-- > 0) // loop till the size of queue
                    {
                        TreeNode currentNode = queue.Peek().Item1; //  get node from top of queue
                        long rootindex = queue.Peek().Item2;// get data as index from top of queue

                        queue.Dequeue();// dequeue to remove top item from queue
                        
                        if(currentNode.left != null)
                        {
                            queue.Enqueue((currentNode.left, (2 * rootindex) + 1)); // add left node with calculated index , rootindex is prev parent node +1
                        }
                        if(currentNode.right != null)
                        {
                            queue.Enqueue((currentNode.right, (2 * rootindex) + 2));// add right node with calculated index , rootindex is prev parent node +2
                        }
                    }
                }
                return maxWidth;
            }
        }
        internal class Program
        {
            static void Main(string[] args)
            {
                TreeNode root = new TreeNode(1);
                root.left = new TreeNode(3);
                root.right = new TreeNode(4);
               root.left.left = new TreeNode(5);
                root.left.right = new TreeNode(3);
                root.right.right = new TreeNode(9);
                Solution solution = new Solution();

                 var res = solution.WidthOfBinaryTree(root);

                Console.WriteLine(res);
                Console.ReadLine();
            }
        }
    }
namespace BinaryTreeLevelOrderTraversalII
{
//Time complexity:
//O(N)

//Space complexity:
//O(N)
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
        public IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            IList<IList<int>> res = new List<IList<int>>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                int n = queue.Count;
                List<int> currNodeVal = new List<int>();
                while (n > 0)
                {
                    TreeNode currNode = queue.Dequeue();
                    currNodeVal.Add(currNode.val);

                    if (currNode.left != null)
                    {
                        queue.Enqueue(currNode.left);
                    }
                    if (currNode.right != null)
                    {
                        queue.Enqueue((TreeNode)currNode.right);
                    }
                    n--;
                }
                //Add the current level to the result at the beginning
                //of it. We could just add it and reverse the list at
                //the end before returning, but i think this is more handy
                res.Insert(0, currNodeVal);
            }
            return res;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(9);
            root.right = new TreeNode(20);
            root.right.left = new TreeNode(15);
            root.right.right = new TreeNode(7);

            Solution s = new Solution();

            var res = s.LevelOrderBottom(root);
            Console.WriteLine(res);
        }
    }
}
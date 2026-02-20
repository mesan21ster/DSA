namespace FindLargestValueinEachTreeRow
{

    /*
     Given the root of a binary tree, return an array of the largest value in each row of the tree (0-indexed).

    Example 1:
    Input: root = [1,3,2,5,3,null,9]
    Output: [1,3,9]
    
    Example 2:

    Input: root = [1,2,3]
    Output: [1,3]
     */

    //Definition for a binary tree node.
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
        public IList<int> LargestValues(TreeNode root)
        {
            if (root == null) return new List<int>();

            List<int> result = new List<int>();

            Queue<TreeNode> queue = new Queue<TreeNode>();

            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                int levelMaxVal = int.MinValue;
                int levelCount = queue.Count;

                for (int i = 0; i < levelCount; i++)
                {
                    var currNode = queue.Dequeue();

                    levelMaxVal = Math.Max(levelMaxVal, currNode.val);

                    if (currNode.left != null)
                    {
                        queue.Enqueue(currNode.left);
                    }

                    if (currNode.right != null)
                    {
                        queue.Enqueue(currNode.right);
                    }
                }

                result.Add(levelMaxVal);
            }

            return result;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(3);
            root.right = new TreeNode(2);
            root.left.left = new TreeNode(5);
            root.left.right = new TreeNode(3);
            root.right.right = new TreeNode(9);

            Solution solution = new Solution();

            var res = solution.LargestValues(root);

            foreach (var val in res)
            {
                Console.WriteLine(val);
            }
        }
    }
}
namespace FlipEquivalentBinaryTrees
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
        public bool FlipEquiv(TreeNode root1, TreeNode root2)
        {
            if(root1 == null && root2 == null) return true;

            if(root1 == null || root2 == null) return false;

            if(root1.val == root2.val)
            {
                bool withoutFlip = FlipEquiv(root1.left, root2.left) && FlipEquiv(root1.right, root2.right);
                bool withFlip = FlipEquiv(root1.left,root2.right) && FlipEquiv(root1.right,root2.left);

                return withoutFlip || withFlip;
            }
            return false;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            TreeNode root1 = new TreeNode(1);
            root1.left = new TreeNode(2);
            root1.right = new TreeNode(3);
            root1.left.left = new TreeNode(4);
            root1.left.right = new TreeNode(5);
            root1.right.left = new TreeNode(6);
            root1.left.right.left = new TreeNode(7);
            root1.left.right.right = new TreeNode(8);

            TreeNode root2 = new TreeNode(1);
            root2.left = new TreeNode(3);
            root2.right = new TreeNode(2);
            root2.left.right = new TreeNode(6);
            root2.right.left = new TreeNode(4);
            root2.right.right = new TreeNode(5);
            root2.right.right.left = new TreeNode(8);
            root2.right.right.right = new TreeNode(7);

            Solution obj = new Solution();
            var res = obj.FlipEquiv(root1, root2);
            Console.WriteLine(res);
        }
    }
}
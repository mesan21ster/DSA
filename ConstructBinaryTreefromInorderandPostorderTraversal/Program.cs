namespace ConstructBinaryTreefromInorderandPostorderTraversal
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
        Dictionary<int, int> map = new();
        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            if (inorder.Length == 0 || postorder.Length == 0) return null;

            for (int i = 0; i < inorder.Length; i++)
            {
                map.Add(inorder[i], i);
            }

            int postidx = postorder.Length - 1;
            return build(postorder, ref postidx, 0, postorder.Length - 1);
        }

        private TreeNode build(int[] postorder, ref int postidx, int startidx, int endidx)
        {
            if(startidx>endidx || postidx < 0)
            {
                return null;
            }

            TreeNode root = new TreeNode(postorder[postidx]);//postorder right to left gives us root
            postidx--;
            int rootidx = map[root.val];//this is the index from inorder,hat we already have added to map
            root.right = build(postorder, ref postidx, rootidx + 1, endidx);//all values from rootidx+1 gives us right side of treenode
            root.left = build(postorder, ref postidx, startidx, rootidx - 1);// all values from startidx to rootidx-1 gives us left side of treenode
            return root;
        }
        private int height(TreeNode root)
        {
            if(root == null) return 0;
            else
            {
                int leftHeight = height(root.left);
                int rightHeight = height(root.right);
                if(leftHeight > rightHeight)
                {
                    return leftHeight + 1;
                }
                else { return rightHeight + 1;}
            }
        }
        public void printLevelOrder(TreeNode root)
        {
            int h = height(root);
            int i;
            for (i = 1; i <= h; i++)
            {
                printCurrentLevel(root, i);
            }
        }
        private void printCurrentLevel(TreeNode root, int level)
        {
            if (root == null)
            {
                Console.Write("Null" + " ");
                return;
            }
            if(level == 1)
            {
                Console.Write(root.val + " ");
            }
            else if(level > 1)
            {
                printCurrentLevel(root.left, level - 1);
                printCurrentLevel(root.right, level - 1);
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] inorder = { 9, 3, 15, 20, 7 };
            int[] postorder = { 9, 15, 7, 20, 3 };

            var res = solution.BuildTree(inorder, postorder);
            solution.printLevelOrder(res);
            Console.ReadLine();
        }
    }
}
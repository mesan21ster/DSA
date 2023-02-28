namespace FindDuplicateSubtrees
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
        public IList<TreeNode> FindDuplicateSubtrees(TreeNode root)
        {
            var res =  new List<TreeNode>();
            if(root == null) return res;
            var dict = new Dictionary<string, int>();//the string representation of occurance
            DFS(root,res,dict);
            return res;
        }

        private string DFS(TreeNode root, List<TreeNode> res, Dictionary<string, int> dict)
        {
            if (root == null) return "#";
            var idenfifier = root.val + "," + DFS(root.left,res,dict) + "," + DFS(root.right,res,dict);
            if(dict.ContainsKey(idenfifier))
            {
                dict[idenfifier] += 1;
                // only add to the result at the second time, it means, there is duplicate. cannot use hashset here because there are different node
                if (dict[idenfifier] ==2) {
                res.Add(root);
                }
            }
            else
            {
                dict[idenfifier] = 1;
            }
            return idenfifier;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            TreeNode root = new TreeNode();
            root.val = 1;
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);   
            root.left.left = new TreeNode(4);
            root.right.left = new TreeNode(2);
            root.right.left.left = new TreeNode(4);
            root.right.right= new TreeNode(4);
            var res = solution.FindDuplicateSubtrees(root);
            Console.ReadLine();
        }
    }
}

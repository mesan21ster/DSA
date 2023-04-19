namespace LongestZigZagPathinaBinaryTree
{
  public class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
          this.val = val;
          this.left = left;
          this.right = right;
      }
  }
    public class Solution
    {
        int maxPath = 0;
        public int LongestZigZag(TreeNode root)
        {
            //initial call root will be 0 , we need to try both side that's way calling two times , first time passing true so it will start from left and next time it will start from right because we are passing false
            //maxPath will be updated from both calls and will return 
            solve(root, 0, true);
            solve(root, 0, false);
            return maxPath;
        }

        private void solve(TreeNode root, int steps, bool direction)
        {
            
            if(root == null) return;//base codition

            maxPath = Math.Max(maxPath, steps);//getting max
            
            // true means go to left
            if (direction)
            {
                solve(root.left, steps +1, false);// here going to left means , pervious call sends direction to go left to form zigzag, so we are increasing steps by 1 and sending direction to go right to next call
                solve(root.right, 1, true);// say we have direction to go to left be we go to right thn we have to start a new path , that's way here we are using 1 and sending direction to nect call to go left
            }
            else
            {
                solve(root.right, steps + 1, true);
                solve(root.left, 1, false);
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(1);
            root.right = new TreeNode(1);
            root.left.right = new TreeNode(1);
            root.left.right.left = new TreeNode(1);
            root.left.right.right = new TreeNode(1);
            root.left.right.left.right = new TreeNode(1);
            Solution solution = new Solution();

            var res =  solution.LongestZigZag(root);

            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
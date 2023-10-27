namespace UniquePaths
{
    public class Solution
    {

        public int UniquePaths(int m, int n)
        {
            int[,] temp = new int[m + 1, n + 1]; // memoization array
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    temp[i, j] = -1;
                }
            }

            return solve(0, 0, m, n, temp);
        }

        private int solve(int i, int j, int m, int n, int[,] temp)
        {
            if (i < 0 || i > m || j < 0 || j > n) return 0;//out of bound

            if (temp[i,j] != -1)
            {
                return temp[i, j];
            }
            if (i == m - 1 && j == n - 1) return 1;//found 1 path


            int right = solve(i, j + 1, m, n, temp);
            int down = solve(i + 1, j, m, n, temp);
            return temp[i, j] = right + down;
        }
    }
    //62. Unique Paths
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int m = 3;
            int n = 2;
            var res = solution.UniquePaths(m, n);
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}

namespace MinimumPathSum
{
    public class Solution
    {
        public int MinPathSum(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;

            int[,] temp = new int[m, n];//memoization array

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    temp[i, j] = -1;
                }
            }

            return solve(grid, 0, 0, m, n, temp);
        }

        //Solve using bottom up approach , using dynamic programing 

        private int solve(int[][] grid, int i, int j, int m, int n, int[,] temp)
        {
            if (i == m - 1 && j == n - 1)
            {
                return grid[i][j];
            }

            if (temp[i, j] != -1)
            {
                return temp[i, j];
            }

            if (i == m - 1)// only can go right
            {
                return temp[i, j] = grid[i][j] + solve(grid, i, j + 1, m, n, temp);
            }
            else if (j == n - 1)// only can go down 
            {
                return temp[i, j] = grid[i][j] + solve(grid, i + 1, j, m, n, temp);
            }
            else//check both options and return minumum of both
            {
                return temp[i, j] = grid[i][j] + Math.Min(solve(grid, i + 1, j, m, n, temp), solve(grid, i, j + 1, m, n, temp));
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int[][] grid = {
                new int[]{ 1,2,3},
                new int[] { 4,5,6}
            };

            var res = s.MinPathSum(grid);

            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
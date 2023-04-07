namespace NumberofEnclaves
{
    public class Solution
    {
        int m = 0;
        int n = 0;
        public int NumEnclaves(int[][] grid)
        {
            m = grid.Length;
            n = grid[0].Length;

            //first row and last row

            for (int col = 0; col < n - 1; col++)
            {
                //first row
                if (grid[0][col] == 1)
                {
                    dfs(grid, 0, col);
                }
                //last row
                if (grid[m - 1][col] == 1)
                {
                    dfs(grid, m - 1, col);
                }
            }

            //first and last column

            for (int row = 0; row < m; row++)
            {
                //first column
                if (grid[row][0] ==  1)
                {
                    dfs(grid, row, 0);
                }
                //last column
                if (grid[row][n-1] == 1)
                {
                    dfs(grid, row, n-1);
                }
            }

            int count = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        private void dfs(int[][] grid, int row, int col)
        {
            if(row<0 || row >= m || col<0  || col >= n || grid[row][col] == 0)
            {
                return;
            }

            grid[row][col] = 0;//marked visited

            dfs(grid, row, col-1);//left
            dfs(grid, row, col+1);//right
            dfs(grid,row-1, col);//up
            dfs(grid,row +1, col);//down
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution sol = new Solution();
            int[][] grid = {
                new int[]{ 0,0,0,0},
                new int[] { 1,0,1,0 },
                new int[] { 0,1,1,0 },
                new int[] {0,0,0,0 }
            };
            var res = sol.NumEnclaves(grid);
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
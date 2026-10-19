namespace No_of_Island
{
    //DFS
    //TC (R × C) each cell processed once
    //SC O(R × C) in worst case (stack holds all cells)
    public class Solution
    {
        public int NoOfIsLand(char[][] grid)
        {
            if (grid == null || grid.Length == 0 || grid[0].Length == 0)
            {
                return 0;
            }
            int m = grid.Length;
            int n = grid[0].Length;
            int count = 0;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        count++;
                        DFS(grid, i, j, m, n);
                    }
                }
            }
            return count;
        }
        private void DFS(char[][] grid, int r, int c, int m, int n)
        {
            if (r < 0 || r >= m || c < 0 || c >= n || grid[r][c] != '1')
            {
                return;
            }
            grid[r][c] = '0'; // mark visited
         
            DFS(grid, r - 1, c, m, n); // up
            DFS(grid, r + 1, c, m, n); // down
            DFS(grid, r, c - 1, m, n); // left
            DFS(grid, r, c + 1, m, n); // right
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Solution sol = new Solution();
            char[][] grid = {
                new char[] { '1', '1', '0', '0', '0' },
                new char[] { '1', '1', '0', '0', '0' },
                new char[] { '0', '0', '1', '0', '0' },
                new char[] { '0', '0', '0', '1', '1' }
            };
            int result = sol.NoOfIsLand(grid);
            Console.WriteLine(result); // Output: 3
        }
    }
}
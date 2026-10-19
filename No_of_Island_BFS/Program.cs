namespace No_of_Island_BFS
{
    public class Solution
    {
        public int NoofIsland(char[][] grid)
        {
            if (grid == null || grid.Length == 0 || grid[0].Length == 0)
            {
                return 0;
            }
            int m = grid.Length;
            int n = grid[0].Length;
            int count = 0;
            Queue<(int, int)> queue = new Queue<(int, int)>();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        count++;
                        queue.Enqueue((i, j));
                        grid[i][j] = '0'; // mark visited
                        while (queue.Count > 0)
                        {
                            var (r, c) = queue.Dequeue();
                            //boundry check and land check
                            if (r - 1 >= 0 && grid[r - 1][c] == '1')
                            {
                                queue.Enqueue((r - 1, c));
                                grid[r - 1][c] = '0';
                            }
                            if (r + 1 < m && grid[r + 1][c] == '1')
                            {
                                queue.Enqueue((r + 1, c));
                                grid[r + 1][c] = '0';
                            }
                            if (c - 1 >= 0 && grid[r][c - 1] == '1')
                            {
                                queue.Enqueue((r, c - 1));
                                grid[r][c - 1] = '0';
                            }
                            if (c + 1 < n && grid[r][c + 1] == '1')
                            {
                                queue.Enqueue((r, c + 1));
                                grid[r][c + 1] = '0';
                            }
                        }
                    }
                }
            }
            return count;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Solution sol = new Solution();
            char[][] grid = new char[][] {
            new char[] {'1', '1', '0', '0', '0'},
            new char[] {'1', '1', '0', '0', '0'},
            new char[] {'0', '0', '1', '0', '0'},
            new char[] {'0', '0', '0', '1', '1'}
            };
            int result = sol.NoofIsland(grid);
            Console.WriteLine(result); // Output: 3
        }
    }
}
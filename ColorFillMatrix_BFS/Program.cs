namespace ColorFillMatrix_BFS
{
//    Time: O(R × C) (each cell processed once)
//Space: O(R × C) in worst case (queue holds all cells)
    public class Solution
    {
        public void ChangeColor(int[][] grid, int row, int col, int newcolor)
        {
            if (grid == null || grid.Length == 0 || grid[0].Length == 0)
            {
                return;
            }
            int n = grid.Length;
            int m = grid[0].Length;
            if (row < 0 || row >= n || col < 0 || col >= m)
            {
                return;
            }

            int oldcolor = grid[row][col];
            if (oldcolor == newcolor)
            {
                return;
            }

            Queue<(int, int)> queue = new Queue<(int, int)>();
            queue.Enqueue((row, col));
            while (queue.Count > 0)
            {
                var (r, c) = queue.Dequeue();
                //boundry check and color check
                if (r < 0 || r >= n || c < 0 || c >= m || grid[r][c] != oldcolor)
                {
                    continue;
                }
                grid[r][c] = newcolor; // mark visited and change color
                //add neighbors to the queue
                queue.Enqueue((r - 1, c)); // up
                queue.Enqueue((r + 1, c)); // down
                queue.Enqueue((r, c - 1)); // left
                queue.Enqueue((r, c + 1)); // right
            }
        }

        public class Program
        {
            static void Main(string[] args)
            {
                Solution sol = new Solution();
                int[][] grid = {
                new int[] { 0, 0, 1,100,100,100 },
                new int[] { 0, 100, 1,100,100,100 },
                new int[] { 1, 1, 1,100,3,3 },
                new int[] { 1, 100, 100,100,3,3 },
                new int[] { 1, 100, 100,100,3,3 }
            };
                int sr = 2;
                int sc = 3;
                int newColor = 999;
                sol.ChangeColor(grid, sr, sc, newColor);
                //Print the modified grid
                for (int i = 0; i < grid.Length; i++)
                {
                    Console.WriteLine(string.Join(", ", grid[i]));
                }
            }
        }
    }
}
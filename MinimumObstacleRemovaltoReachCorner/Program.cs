namespace MinimumObstacleRemovaltoReachCorner
{
    /*
     You are given a 0-indexed 2D integer array grid of size m x n. Each cell has one of two values:

0 represents an empty cell,
1 represents an obstacle that may be removed.
You can move up, down, left, or right from and to an empty cell.

Return the minimum number of obstacles to remove so you can move from the upper left corner (0, 0) to the lower right corner (m - 1, n - 1).
     
    Input: grid = [[0,1,1],[1,1,0],[1,1,0]]
Output: 2
Explanation: We can remove the obstacles at (0, 1) and (0, 2) to create a path from (0, 0) to (2, 2).
It can be shown that we need to remove at least 2 obstacles, so we return 2.
Note that there may be other ways to remove 2 obstacles to create a path.



    Input: grid = [[0,1,0,0,0],[0,1,0,1,0],[0,0,0,1,0]]
Output: 0
Explanation: We can move from (0, 0) to (2, 4) without removing any obstacles, so we return 0.


Time Complexity:
O(m × n × log(m × n)): The number of nodes is m×n, and each node operation in the priority queue costs O(log(m×n)).

Space Complexity:
O(m × n): For the res matrix and priority queue storage.


     */
    public class Solution
    {
        public int MinimumObstacles(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            int[][] directions = { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };
            // Initialize cost array with max value
            int[,] res = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    res[i, j] = int.MaxValue;
                }
            }

            // Priority queue to process nodes based on minimum cost
            PriorityQueue<(int x, int y, int cost), int> pq = new PriorityQueue<(int x, int y, int cost), int>();
            pq.Enqueue((0, 0, 0), 0);
            res[0, 0] = 0;

            while (pq.Count > 0)
            {
                var (x, y, cost) = pq.Dequeue();

                // Skip processing if we've already found a better path
                if (cost > res[x, y]) continue;

                foreach (var dir in directions)
                {
                    int dx = x + dir[0];
                    int dy = y + dir[1];

                    // Skip invalid cells
                    if (dx < 0 || dx >= m || dy < 0 || dy >= n) continue;

                    int newCost = cost + (grid[dx][dy] == 1 ? 1 : 0);

                    // Update and enqueue if a better cost is found
                    if (newCost < res[dx, dy])
                    {
                        res[dx, dy] = newCost;
                        pq.Enqueue((dx, dy, newCost), newCost);
                    }
                }

            }
            return res[m - 1, n - 1];
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Solution s = new Solution();
            int[][] grid = {
            new int[] { 0, 1, 1 },
            new int[] { 1,1,0 },
            new int[] { 1, 1, 0 }
            };

            var res = s.MinimumObstacles(grid);
            Console.WriteLine(res);
        }
    }
}
namespace NumberofClosedIslands
{
    public class Solution
    {
        int m = 0;
        int n = 0;
        public int ClosedIsland(int[][] grid)
        {
            m = grid.Length;
            n = grid[0].Length;
            int count = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 0)//found land
                    {
                        if (dfs(grid, i, j) == true)
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }

        private bool dfs(int[][] grid, int row, int col)
        {
            if (row >= m || row < 0 || col >= n || col < 0)//condition for out of bound
            {
                return false; // not closed island
            }
            if (grid[row][col] == 1) // water found at this postion
            {
                return true; // closed at this side with the given row and column
            }

            grid[row][col] = 1; // marked visited

            bool left_closed = dfs(grid, row, col - 1);// decrease column, row will be consistent because we are moving towards left
            bool right_closed = dfs(grid, row, col + 1);// increase column, row will be consistent because we are moving towards right
            bool up_closed = dfs(grid, row - 1, col);// decrease row, column will be consistent because we are moving towards up
            bool down_closed = dfs(grid, row + 1, col);// increase row, column will be consistent because we are oving towards down

            return left_closed && right_closed && up_closed && down_closed;// all side returns true
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution sol = new Solution();
            int[][] grid = {
                new int[]{ 1,1,1,1,1,1,1,0},
                new int[] { 1, 0, 0, 0, 0, 1, 1, 0 },
                 new int[] { 1,0,1,0,1,1,1,0 },
                  new int[] {1,0,0,0,0,1,0,1 },
                   new int[] { 1,1,1,1,1,1,1,0 },
            };
            var res = sol.ClosedIsland(grid);
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
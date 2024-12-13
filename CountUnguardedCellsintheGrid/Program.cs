using System.Collections.Generic;

namespace CountUnguardedCellsintheGrid
{
    public class Solution
    {
        public int CountUnguarded(int m, int n, int[][] guards, int[][] walls)
        {
            int[,] grid = new int[m, n];

            //fill the grid with 0
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    grid[i, j] = 0;
                }
            }

            //marked guards
            foreach (var guard in guards)
            {
                int i = guard[0];
                int j = guard[1];
                grid[i, j] = 2;//guards
            }
            //marked walls

            foreach (var wall in walls)
            {
                int i = wall[0];
                int j = wall[1];
                grid[i, j] = 3;
            }

            //check guarded positions , looping to guard and marking in grid
            foreach (var guarded in guards)
            {
                int i = guarded[0];
                int j = guarded[1];
                //for iteritive method
                //markedGuarded(grid, i, j);//check in all the 4 direction
                DFS(grid, i - 1, j, m, n, 1);//1 for up
                DFS(grid, i + 1, j, m, n, 2);//2 for down
                DFS(grid, i, j - 1, m, n, 3);//3 for left
                DFS(grid, i, j + 1, m, n, 4);//4 for right
            }

            int count = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i, j] == 0)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        private void DFS(int[,] grid, int row, int col, int i, int j, int direction)
        {
            int rowlength = grid.GetLength(0);
            int collength = grid.GetLength(1);
            if (row < 0 || col < 0 || row >= i || col >= j )
            {
                return;
            }
            grid[i, j] = 1;

            if (direction == 1)
            {
                DFS(grid, i - 1, j, row, col, direction);//1 for up
            }
            else if (direction == 2) {
                DFS(grid, i + 1, j, row, col, direction);//2 for down
            }
            else if (direction == 3)
            {
                DFS(grid, i, j-1, row, col, direction);//3 for left
            }
            else
            {
                DFS(grid, i, j + 1, row, col, direction);//3 for left
            }

        }
        private void markedGuarded(int[,] grid, int row, int col)
        {
            int rowlength = grid.GetLength(0);
            int collength = grid.GetLength(1);
            //check up
            for (int i = row - 1; i >= 0; i--)
            {
                if (grid[i, col] == 2 || grid[i, col] == 3)
                {
                    break;
                }
                grid[i, col] = 1;
            }

            //check down
            for (int i = row + 1; i < rowlength; i++)
            {
                if (grid[i, col] == 2 || grid[i, col] == 3)
                {
                    break;
                }
                grid[i, col] = 1;
            }

            //check left
            for (int i = col - 1; i >= 0; i--)
            {
                if (grid[row, i] == 2 || grid[row, i] == 3)
                {
                    break;
                }
                grid[row, i] = 1;
            }

            //check right
            for (int i = col + 1; i < collength; i++)
            {
                if (grid[row, i] == 2 || grid[row, i] == 3)
                {
                    break;
                }
                grid[row, i] = 1;
            }
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Solution s = new Solution();
            int m = 4;
            int n = 6;
            int[][] guards =
            {
                new int[] { 0, 0 },
                new int[] { 1, 1 },
                new int[] { 2, 3 }
            };
            int[][] walls =
            {
                new int[] { 0, 1 },
                new int[] { 2, 2 },
                new int[] { 1, 4 }
            };

            var res = s.CountUnguarded(m, n, guards, walls);

            Console.WriteLine(res);
        }
    }
}
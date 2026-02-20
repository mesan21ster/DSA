public class Solution
{
    public int LargestMagicSquare(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        if (m < 2 || n < 2) return 0;

        int smaller = m == n ? m : Math.Min(m, n);
        int maxsize = 0;
        for (int size = smaller; size >= 2; size--)//size of magic square
        {
            if(maxsize >= size)//if maxsize is already greater than size, break
            {
                break;
            }
            for (int i = 0; i <= m - size; i++)//row
            {
                for (int j = 0; j <= n - size; j++)//column
                {
                    if (isMagicSquare(grid, i, j, size))//check if magic square
                    {
                        maxsize = Math.Max(maxsize, size);//check maxsize
                    }
                }
            }
        }

        return maxsize;//return maxsize
    }
    private bool isMagicSquare(int[][] grid, int r, int c, int size)
    {
        int targetSum = 0;
        for (int j = 0; j < size; j++)
        {
            targetSum += grid[r][c + j];
        }
        // Check rows
        for (int i = 0; i < size; i++)
        {
            int rowSum = 0;
            for (int j = 0; j < size; j++)
            {
                rowSum += grid[r + i][c + j];
            }
            if (rowSum != targetSum) return false;
        }
        // Check columns
        for (int j = 0; j < size; j++)
        {
            int colSum = 0;
            for (int i = 0; i < size; i++)
            {
                colSum += grid[r + i][c + j];
            }
            if (colSum != targetSum) return false;
        }
        // Check main diagonal
        int diagSum1 = 0;
        for (int i = 0; i < size; i++)
        {
            diagSum1 += grid[r + i][c + i];
        }
        if (diagSum1 != targetSum) return false;
        // Check secondary diagonal
        int diagSum2 = 0;
        for (int i = 0; i < size; i++)
        {
            diagSum2 += grid[r + i][c + size - 1 - i];
        }
        if (diagSum2 != targetSum) return false;
        return true;
    }
}

public class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[][] grid = new int[][]
        {
            new int[]{7,1,4,5,6},
            new int[]{2,5,1,6,4},
            new int[]{1,5,4,3,2},
            new int[]{1,2,7,3,4}
        };
        var res = solution.LargestMagicSquare(grid);
        Console.WriteLine(res);
        Console.ReadLine();
    }
}
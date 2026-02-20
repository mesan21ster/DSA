public class Solution
{
    /*
     A 3 x 3 magic square is a 3 x 3 grid filled with distinct numbers from 1 to 9 such that each row, column, and both diagonals all have the same sum.

Given a row x col grid of integers, how many 3 x 3 magic square subgrids are there?

Note: while a magic square can only contain numbers from 1 to 9, grid may contain numbers up to 15.
     */
    //Time O(M*N)
    //Space O(1)
    public int NumMagicSquaresInside(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;

        if (m < 3 || n < 3) return 0;

        int count = 0;

        //Iterate over all possible top-left corners
        for (int i = 0; i <= m - 3; i++)
        {
            for (int j = 0; j <= n - 3; j++)
            {
                //Optimization: Center must be 5

                if (isMagic(grid, i, j))
                {
                    count++;
                }
            }
        }
        return count;
    }

    private bool isMagic(int[][] grid, int r, int c)
    {
        //Step 1: Check the uniqueness and range (1-9)
        bool[] seen = new bool[10];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                int num = grid[r + i][c + j];
                if (num < 1 || num > 9 || seen[num])
                {
                    return false;
                }
                else
                {
                    seen[num] = true;
                }
            }
        }
        //Step 2: check the total of each row should be equals to 15

        for (int i = 0; i < 3; i++)
        {
            int rowtotal = 0;
            for (int j = 0; j < 3; j++)
            {
                rowtotal += grid[r + i][c + j];
            }
            if (rowtotal != 15)
            {
                return false;
            }
        }
        //Step 3: check the total of each column should be equals to 15
        for(int i =0; i<3; i++)
        {
            int coltotal = 0;
            for(int j=0; j<3; j++)
            {
                coltotal += grid[r + j][c + i];
            }
            if(coltotal !=15)
            {
                return false;
            }
        }
        //Step 4: check the total of both diagonals should be equals to 15
        int diag1 = grid[r][c] + grid[r + 1][c + 1] + grid[r + 2][c + 2];
        int diag2 = grid[r][c + 2] + grid[r + 1][c + 1] + grid[r + 2][c];
        if (diag1 != 15 || diag2 != 15)
        {
            return false;
        }

        return true;
    }
}

public class program
{
    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[][] grid = new int[][]
        {
            new int[] {4,3,8,4},
            new int[] {9,5,1,9},
            new int[] {2,7,6,2}
        };
        int result = solution.NumMagicSquaresInside(grid);
        Console.WriteLine(result); // Output: 1
        Console.ReadLine();
    }
}
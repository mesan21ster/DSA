namespace MatrixDiagonalSum
{
    public class Solution
    {
        //Time O(N)
        //space O(1)
        public int DiagonalSum(int[][] mat)
        {
            int n = mat.Length;
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                //add diagonal to sum
                //mat[i][i] means primary diagonal rows like [0,0] [1,1] and so on
                //mat[i][n-i-1] means , secondary diagonal , starting from last element from row, row will be i and column will be [n-i-1],[n-i-2] and so on
                sum += mat[i][i] + mat[i][n - i - 1];
            }
            if (n % 2 == 1)
            {// if matrix is odd the remove the middle element from sum
                sum -= mat[n / 2][n / 2];
            }
            return sum;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
          Solution solution = new Solution();
            int[][] matrix = {
                new int[]{1,2,3},
                new int[]{4,5,6},
                new int[]{7,8,9},
            };
            var res = solution.DiagonalSum(matrix);
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
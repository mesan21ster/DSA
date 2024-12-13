namespace MaximumMatrixSum
{
    /*
     You are given an n x n integer matrix. You can do the following operation any number of times:

Choose any two adjacent elements of matrix and multiply each of them by -1.
Two elements are considered adjacent if and only if they share a border.

Your goal is to maximize the summation of the matrix's elements. Return the maximum sum of the matrix's elements using the operation mentioned above.

    Input: matrix = [[1,-1],[-1,1]]
Output: 4
Explanation: We can follow the following steps to reach sum equals 4:
- Multiply the 2 elements in the first row by -1.
- Multiply the 2 elements in the first column by -1.

    Input: matrix = [[1,2,3],[-1,-2,-3],[1,2,3]]
Output: 16
Explanation: We can follow the following step to reach sum equals 16:
- Multiply the 2 last elements in the second row by -1.
     */
    public class Solution
    {
        public long MaxMatrixSum(int[][] matrix)
        {
            /*
                step 1 = get the total sum of matrix absulute value
                step 2 = count the number of negative value
                step 3 = find the minimum smallest absolute value in matrix
                step 4 = if number of negative value is even than result will be total sum of matrix, else totalsum - 2*smallest absolute value
            //why 2 * = because while adding totalsum you already have added one time of smallest value , so you have to minus that and then again you have to minus the smallest value to get the maximun sum 
             */

            long totalsum = 0;
            long absSmallestNumber = long.MaxValue;
            int countofNegativeValue = 0;
            int n = matrix.Length;
            int m = matrix[0].Length;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    totalsum += Math.Abs(matrix[i][j]);
                    if (matrix[i][j] < 0)
                    {
                        countofNegativeValue++;
                    }

                    absSmallestNumber = Math.Min(absSmallestNumber, Math.Abs(matrix[i][j]));
                }
            }

            if(countofNegativeValue % 2 == 0)
            {
                return totalsum;
            }

            return totalsum - (2 * absSmallestNumber);
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Solution s = new Solution();
            int[][] matrix =
            {
                new int[]{ 1, -1 },
                new int[]{ -1, 1 }
            };

            var res = s.MaxMatrixSum(matrix);
            Console.WriteLine(res);
        }
    }
}
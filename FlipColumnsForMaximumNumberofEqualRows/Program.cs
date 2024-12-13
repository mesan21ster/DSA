
using System.Text;

namespace FlipColumnsForMaximumNumberofEqualRows
{

    /*
     You are given an m x n binary matrix matrix.

You can choose any number of columns in the matrix and flip every cell in that column (i.e., Change the value of the cell from 0 to 1 or vice versa).

Return the maximum number of rows that have all values equal after some number of flips.

 

Example 1:

Input: matrix = [[0,1],[1,1]]
Output: 1
Explanation: After flipping no values, 1 row has all values equal.
Example 2:

Input: matrix = [[0,1],[1,0]]
Output: 2
Explanation: After flipping values in the first column, both rows have equal values.
Example 3:

Input: matrix = [[0,0,0],[0,0,1],[1,1,0]]
Output: 2
Explanation: After flipping values in the first two columns, the last two rows have equal values.
     */

    public class Solution
    {
        public int MaxEqualRowsAfterFlipsOptimized(int[][] matrix)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;
            int maxcount = 0;

            Dictionary<string, int> map = new Dictionary<string, int>();

            //go to each row of martix

            foreach (var currrow in matrix)
            {
                //find the pattern of row value

                StringBuilder pattern = new StringBuilder();
                int firstrow = currrow[0];
                for (int i = 0; i < n; i++)
                {
                    pattern.Append(currrow[i] == firstrow ? "0" : "1");
                }

                if (map.ContainsKey(pattern.ToString()))
                {
                    map[pattern.ToString()]++;
                }
                else
                {
                    map.Add(pattern.ToString(), 1);
                }
            }

            foreach (var kv in map)
            {
                maxcount = Math.Max(maxcount, kv.Value);
            }

            return maxcount;
        }
        public int MaxEqualRowsAfterFlips(int[][] matrix)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;


            /*
            pick each row
            same rows
            inverted rows
            keep track of max count
             */
            int maxrow = 0;
            foreach (var currrow in matrix)
            {
                int[] inverted = new int[n];
                int count = 0;

                //generate the inverted row

                for (int col = 0; col < n; col++)
                {
                    inverted[col] = currrow[col] == 0 ? 1 : 0;
                }

                //count matching rows either equal to currrow or inverted row

                foreach (var row in matrix)
                {
                    if (AreRowsEqual(row, currrow) || AreRowsEqual(row, inverted))
                    {
                        count++;
                    }
                }

                maxrow = Math.Max(maxrow, count);

            }
            return maxrow;
        }

        private bool AreRowsEqual(int[] row, int[] currrow)
        {
            if (row.Length != currrow.Length)
            {
                return false;
            }

            for (int i = 0; i < row.Length; i++)
            {
                if (row[i] != currrow[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[][] matrix = {
            new int[] {0,0,0},
            new int[] {0,0,1},
            new int[] {1,1,0}
            };

            var res = solution.MaxEqualRowsAfterFlipsOptimized(matrix);
            Console.WriteLine(res);
        }
    }
}

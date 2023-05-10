namespace SpiralMatrixII
{
    public class Solution
    {
        //Time O(n^2)
        //Space O(n^2)
        public int[][] GenerateMatrix(int n)
        {
            int top = 0;
            int bottom = n - 1;
            int left = 0;
            int right = n - 1;
            int direction = 0;

            int[][] ans = new int[n][];
            int val = 1;


            //Initialize the res matrix
            for (int i = 0; i < n; i++)
            {
                ans[i] = new int[n];
            }

            //Loop to buid spiral matrix
            while (left <= right && top <= bottom)
            {
                if (direction == 0)
                {
                    for (int i = left; i <= right; i++)
                    {
                        ans[top][i] = val;
                        val++;
                    }
                    direction = 1;
                    top++;
                }
                else if (direction == 1)
                {
                    for (int i = top; i <= bottom; i++)
                    {
                        ans[i][right] = val;
                        val++;
                    }
                    direction = 2;
                    right--;
                }
                else if (direction == 2)
                {
                    for (int i = right; i >= left; i--)
                    {
                        ans[bottom][i] = val;
                        val++;
                    }
                    direction = 3;
                    bottom--;
                }
                else if (direction == 3)
                {
                    for (int i = bottom; i >= top; i--)
                    {
                        ans[i][left] = val;
                        val++;
                    }
                    direction = 0;
                    left++;
                }
            }
            return ans;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();

            var res = solution.GenerateMatrix(3);
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
namespace IntegerBreak
{
    //Time O(n^2)
    public class Solution
    {
        int[] temp = new int[59];
        public int IntegerBreak(int n)
        {
            Array.Fill(temp, -1);
            return solve(n);
        }

        private int solve(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            if (temp[n] != -1)
            {
                return temp[n];
            }
            int result = int.MinValue;

            for(int i = 1;i<=n;i++)
            {
                int prod = i* Math.Max(n-i,solve(n-i));

                result = Math.Max(result, prod);
            }
            return temp[n]= result;
        }
    }
    internal class Program
    {
        public static void Main(string[] args)
        {
            Solution sol = new Solution();
            int n = 2;
            var res = sol.IntegerBreak(n);
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
using System;

namespace Recurrsion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Factorial(5));
            Console.WriteLine(Sum(5));
            Console.WriteLine(fibonacchi(7));
            int n = 7;
            int[] dp = new int[n+1];
            Console.WriteLine(fibonacchi(7, dp));
            Console.ReadLine();
        }
        static int Sum(int n)//sun of n
        {
            if (n == 1) { return 1; }

            return Sum(n - 1) + n;
        }
        static int Factorial(int n) //factorial of n
        {
            if (n == 1) { return 1; }
            return Factorial(n - 1) * n;
        }
        static int fibonacchi(int n)
        {
            if (n == 0 || n == 1) { return n; }

            return fibonacchi(n - 1) + fibonacchi(n - 2);
        }
        static int fibonacchi(int n, int[] dp)//DP with memoization , Memoization uses recurrsion 
        {
            if (n == 0 || n == 1) { return n; }

            if (dp[n] != 0) { return dp[n]; }

            return dp[n] = fibonacchi(n - 1, dp) + fibonacchi(n - 2, dp);
        }
    }
}

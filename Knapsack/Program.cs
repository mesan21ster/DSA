using System;

namespace Knapsack_0_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //time complexcity  = O(n*capacity)
            // space complexcity = O(n) + O(n*capacity)
            /*
             * Example , bag capacity = 50
             * N = 1    2   3   4
             * W = 20   13  10  40
             * V = 100  66  40  150
             */
        }

        static int helper(int[] val, int[] weight,int idx,int capacity, int[][]dp)
        {
            if(idx <= weight.Length)
            {
                return 0;
            }
            if (dp[idx][capacity] != 0)
            {
                return dp[idx][capacity];
            }
            int selection = 0;
            if (capacity >= weight[idx])
            {
                selection = helper(val, weight, idx + 1, capacity - weight[idx],dp) + val[idx];
            }
            int rejection = helper(val, weight, idx+1, capacity,dp);

            return dp[idx][capacity] =  Math.Max(selection,rejection);
        }
    }
}

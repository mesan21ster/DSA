namespace ReducingDishes
{
    //Recursion + Memo : Knapsack
    public class Solution
    {
        int[,] dp = new int[501, 501];
        public int MaxSatisfaction(int[] satisfaction)
        {
            int n = satisfaction.Length;
            Array.Sort(satisfaction);
            for (int i = 0; i < 501; i++)
            {
                for (int j = 0; j < 501; j++)
                {
                    dp[i, j] = -1;
                }
            }
            return solve(satisfaction, 0, 1, n);//0=index, 1= time
        }

        private int solve(int[] satisfaction, int i, int time, int n)
        {
            if (i >= n)
            {
                return 0;
            }

            if (dp[i, time] != -1)
            {
                return dp[i, time];
            }

            int include = satisfaction[i] * time + solve(satisfaction, i + 1, time + 1, n);//every recursion increase index and time
            int exclude = solve(satisfaction, i + 1, time, n);//we are not including dishes this time so index will increase but time will not, because we have skiped dish so next dish will start at pervious time

            return dp[i, time] = Math.Max(include, exclude);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int[] satisfaction = { -1, -8, 0, 5, -9 };
            var res = s.MaxSatisfaction(satisfaction);
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
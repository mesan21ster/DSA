namespace MaximumAmountofMoneyRobotCanEarn
{
    public class Solution
    {
        int m, n;
        int[,,] memo = new int[501, 501, 3];
        public int MaximumAmount(int[][] coins)
        {
            m = coins.Length;
            n = coins[0].Length;

            for (int i = 0; i < 501; i++)
            {
                for (int j = 0; j < 501; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        memo[i, j, k] = int.MinValue;
                    }
                }
            }

            return solve(coins, 0, 0, 2);
        }

        private int solve(int[][] coins, int row, int col, int neu)
        {
            if (row == m - 1 && col == n - 1) // you have reached to destination
            {
                if (coins[row][col] < 0 && neu > 0)
                {
                    return 0;
                }
                return coins[row][col];
            }

            //base case
            if (row >= m || col >= n)
            {
                return int.MinValue;
            }

            if (memo[row, col, neu] != int.MinValue)
            {
                return memo[row, col, neu];
            }
            //Take the current cell value
            int take = coins[row][col] + Math.Max(solve(coins, row + 1, col, neu), solve(coins, row, col + 1, neu));

            //skip the current cell value if you can

            int skip = int.MinValue;
            if (coins[row][col] < 0 && neu > 0)
            {
                int skipDown = solve(coins, row + 1, col, neu - 1);
                int skipRight = solve(coins, row, col + 1, neu - 1);
                skip = Math.Max(skipDown, skipRight);
            }

            return memo[row, col, neu] = Math.Max(take, skip);
        }

        //public long MaxPoints(int[][] points)
        //{
        //    int m = points.Length;
        //    int n = points[0].Length;
        //    long maxPoints = 0;
        //    for (int j = 0; j < n; j++)
        //    {
        //        maxPoints = Math.Max(maxPoints, points[0][j]);
        //    }
        //    for (int i = 1; i < m; i++)
        //    {
        //        long[] dp = new long[n];
        //        for (int j = 0; j < n; j++)
        //        {
        //            dp[j] = maxPoints + points[i][j];
        //        }
        //        maxPoints = 0;
        //        for (int j = 0; j < n; j++)
        //        {
        //            maxPoints = Math.Max(maxPoints, dp[j]);
        //        }
        //    }
        //    return maxPoints;
        //}
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Solution solution = new Solution();

            int[][] coins = new int[][]
            {
                new int[]{0,1,-1 },
                new int[]{ 1,-2,3 },
                new int[]{2,-3,4 }
            };

            var res = solution.MaximumAmount(coins);

            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}

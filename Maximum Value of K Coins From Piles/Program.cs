namespace MaximumValueofKCoinsFromPiles
{
    public class Solution
    {
        int n = 0;
        int[,] temp = new int[1001, 2001];
        private int solve(int i, IList<IList<int>> piles, int k)
        {
            if (i >= n)
            {
                return 0;
            }
            if (temp[i, k] != -1)
            {

                return temp[i, k];
            }
            int not_taken = solve(i + 1, piles, k); //increase i to 1 because we are not considering i

            int taken = 0;
            int sum = 0;

            for (int j = 0; j < Math.Min((int)piles[i].Count, k); j++)
            {
                sum += piles[i][j];
                taken = Math.Max(taken, sum + solve(i + 1, piles, k - (j + 1))); //recursive call with next index to i and decrease k with j+1 //here j index start with 0 so + 1 means exact count
            }
            return temp[i, k] = Math.Max(taken, not_taken);//memoization
        }
        public int MaxValueOfCoins(IList<IList<int>> piles, int k)
        {
            n = piles.Count;
            for (int i = 0; i < 1001; i++)
            {
                for (int j = 0; j < 2001; j++)
                {
                    temp[i, j] = -1;
                }
            }
            return solve(0, piles, k);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[][] piles = {
                new int[]{1, 100, 3 },
                new int[]{7, 8, 9 }
            };
            int k = 2;
            var res = solution.MaxValueOfCoins(piles, k);
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
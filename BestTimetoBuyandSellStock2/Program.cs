namespace BestTimetoBuyandSellStockTwoPointer2
{
    //you can sell or buy multiple times but you cannot hold more than one stock at a time
    public class Solution
    {
        public int MaxProfit(int[] prices)
        {
            int maxProfit = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] > prices[i - 1])
                {
                    maxProfit += prices[i] - prices[i - 1];
                }
            }
            return maxProfit;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            int[] prices = { 7, 1, 5, 3, 6, 4 };
            Solution solution = new Solution();
            var res = solution.MaxProfit(prices);
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }   
}
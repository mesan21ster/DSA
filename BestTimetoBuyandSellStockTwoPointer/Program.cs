namespace BestTimetoBuyandSellStockTwoPointer
{
    public class Solution
    {
        public int MaxProfit(int[] prices)
        {
            int left = 0;
            int right = 1;
            int maxProfit = 0;
            while (right < prices.Length)
            {
                if (prices[left] < prices[right])
                {
                    int profit = prices[right] - prices[left];
                    maxProfit = Math.Max(maxProfit, profit);
                }
                else
                {
                    left = right;
                }
                right++;
            }
            return maxProfit;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] prices = { 7, 1, 5, 3, 6, 4 };
            Solution solution = new Solution();
            var res = solution.MaxProfit(prices);
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
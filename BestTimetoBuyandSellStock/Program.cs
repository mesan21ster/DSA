namespace BestTimetoBuyandSellStock
{
    /*
     * 
     * steps :-
firstly we check if size of prices array is 1 or not if so then return 0.

we declare two varibale low and maxprofit ,here low is index pointing to that index which is giving minimum price in prices array so far . maxprofit stores maximumprofit till now.

Iterate through each elements of prices array and observe it .
a) if we encounter price lesser than assumed(we assumes minimum price is first element of array) then we store that index into low and continue
b) if it is not less , then we need to calculate maxprofit , it is simply max of (maxprofit so far calculated) and (current price - minimum prices so far encountered),

return maxprofit .
     * 
     * 
     Time Complexity: O(n)
Space complexity: O(1)
     */
    public class Solution
    {
        public int MaxProfit(int[] prices)
        {
            if(prices.Length == 0) return 0;
            int minprice = int.MaxValue;
            int maxProfit = 0;

            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < minprice)
                {
                    minprice = prices[i];
                }
                else
                {
                    maxProfit= Math.Max(maxProfit, prices[i] - minprice);
                }
            }
            return maxProfit;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] prices = { 7, 6, 4, 3, 1 };
            Solution solution = new Solution();
            var res = solution.MaxProfit(prices);
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
namespace MinimumTimetoMakeRopeColorful
{
    public class Solution
    {
        //"aaabbbabbbb"
        //neededTime =[3,5,10,7,5,3,5,5,4,8,1]
        public int MinCost(string colors, int[] neededTime)
        {
            string prevColor = "";
            int minCost = 0;
            int prevCost = 0;
            for (int i = 0; i < colors.Length; i++)
            {
                if (Convert.ToString(colors[i]) == prevColor)
                {
                    minCost += Math.Min(prevCost, neededTime[i]);
                    prevColor = Convert.ToString(colors[i]);
                    prevCost = Math.Max(prevCost, neededTime[i]);
                }
                else
                {
                    prevColor = Convert.ToString(colors[i]);
                    prevCost = neededTime[i];
                }
            }
            return minCost;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            string colors = "aaabbbabbbb";
            int[] neededTime = { 3, 5, 10, 7, 5, 3, 5, 5, 4, 8, 1 };
            var res = solution.MinCost(colors, neededTime);

            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
namespace MinimumCostForTickets_DP
{
    public class Solution
    {
        public int MincostTickets(int[] days, int[] costs)
        {
            HashSet<int> set = new HashSet<int>();

            for (int i = 0; i < days.Length; i++)
            {
                set.Add(days[i]);
            }

            int last_day = days[days.Length - 1];

            List<int> DP = new List<int>();

            for (int i = 0; i <= last_day; i++)
            {
                DP.Add(0);
            }

            //DP[i] = min cost to travel till day i of your travel plan
            DP[0] = 0;

            for (int i = 1; i <= last_day; i++)
            {
                //check if you have to travel on ith day or not
                if (!set.Contains(i))
                {
                    DP[i] = DP[i - 1];
                    continue;
                }

                DP[i] = int.MaxValue;

                int day_1_pass = costs[0] + DP[Math.Max(i - 1,0)];
                int day_7_pass = costs[1] + DP[Math.Max(i - 7,0)];
                int day_30_pass = costs[2] + DP[Math.Max(i - 30, 0)];

                DP[i] = Math.Min(day_1_pass,Math.Min(day_7_pass,day_30_pass));
            }

            return DP[last_day];
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();

            int[] days = { 1, 4, 6, 7, 8, 20 };
            int[] costs = { 2, 7, 15 };
            var result = s.MincostTickets(days, costs);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
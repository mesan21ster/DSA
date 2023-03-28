namespace MinimumCostForTickets
{
    public class Solution
    {
        //solve using recursion and memoization
        //Time O(n)
        //Space O(n)
        private List<int>? temp;
        public int MincostTickets(int[] days, int[] costs)
        {
            int n = days.Length;

            temp = new List<int>();
            for (int i = 0; i < 366; i++)
            {
                temp.Add(-1);
            }
            return solve(days, costs, n, 0);
        }

        private int solve(int[] days, int[] costs, int n, int index)
        {
            if (index >= n) { return 0; }

            //day 1 pass
            int day_1 = costs[0] + solve(days, costs, n, index + 1);

            //day 7 pass
            int j = index;
            int max_day = days[index] + 7;

            while (j < n && days[j] < max_day)
            {
                j++;
            }

            int day_7 = costs[1] + solve(days, costs, n, j);

            //day 30 pass

            j = index;
            max_day = days[index] + 30;
            while(j < n && days[j] < max_day) { j++; }
            int day_30 = costs[2] + solve(days,costs, n, j);

            return temp[index] = Math.Min(day_1,Math.Min(day_7,day_30));
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
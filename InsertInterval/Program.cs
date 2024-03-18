namespace InsertInterval
{//57. Insert Interval
    public class Solution
    {
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            int i = 0;
            int n = intervals.Length;
            var res = new List<int[]>();
            while (i < n)
            {
                if (intervals[i][1] < newInterval[0])
                {
                    res.Add(intervals[i]);
                }else if (intervals[i][0] > newInterval[1])
                {
                    break;
                }
                else
                {
                    newInterval[0] = Math.Min(newInterval[0], intervals[i][0]);
                    newInterval[1] = Math.Max(newInterval[1], intervals[i][1]);
                }
                i++;
            }
            res.Add(newInterval);

            while(i < n)
            {
                res.Add(intervals[i]);
                i++;
            }

            return res.ToArray();
        }
    }

    internal class Program(string[] args)
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();

            int[][] intervals =
            [
                [1,2],[3,5],[6,7],[8,10],[12,16]
            ];

            int[] newInterval = [4,8];
            
            var res = solution.Insert(intervals, newInterval);

            foreach (var item in res)
            {
                foreach (var it in item)
                {
                    Console.Write(it + " ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
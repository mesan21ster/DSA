namespace TheNumberoftheSmallestUnoccupiedChair
{
    public class Solution
    {
        public int SmallestChair(int[][] times, int targetFriend)
        {
            int[] chair = new int[times.Length];
            int targetFriendArrival = times[targetFriend][0];

            Array.Sort(times, (a, b) =>
            {
                return a[0].CompareTo(b[0]);
            });

            foreach (var time in times)
            {
                int arrival = time[0];
                int depart = time[1];

                for (int i = 0; i < times.Length; i++)
                {
                    if (chair[i] <= arrival)
                    {
                        chair[i] = depart;
                        if (arrival == targetFriendArrival)
                        {
                            return i;
                        }
                        break;
                    }

                }
            }
            return -1;
        }
        public class Program
        {
            public static void Main(string[] args)
            {
                Solution solution = new Solution();
                int[][] times =
                {
                    new int[] { 3, 10 },
                    new int[] { 1, 5 },
                    new int[] { 2, 6 }
                };
                int targetFriend = 0;
                var res = solution.SmallestChair(times, targetFriend);
                Console.WriteLine(res);
                Console.ReadLine();

            }
        }
    }
}
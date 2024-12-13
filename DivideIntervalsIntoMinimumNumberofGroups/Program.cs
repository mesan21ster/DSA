namespace DivideIntervalsIntoMinimumNumberofGroups
{
    public class Solution
    {
        public int MinGroups(int[][] intervals)
        {
            Array.Sort(intervals, (a, b) =>
            {
                return a[0].CompareTo(b[0]);
            });

            PriorityQueue<int, int> minheap = new PriorityQueue<int, int>();

            foreach (var interval in intervals)
            {
                int start = interval[0];
                int end = interval[1];

                if (minheap.Count > 0 && start > minheap.Peek()) //start should be greater than end of top value of minheap
                {
                    minheap.Dequeue();
                }

                minheap.Enqueue(end, end);
                
            }
            return minheap.Count;
        }
        public class Program
        {
            public static void Main(string[] args)
            {
                Solution s = new Solution();
                int[][] intervales = {
                    new int[]{
                        5,10
                    },
                    new int[]{
                        6,8
                    },
                    new int[]{
                        1,5
                    },
                    new int[]{
                        2,3
                    },
                    new int[]{
                        1,10
                    }
                };

                var res = s.MinGroups(intervales);
                Console.WriteLine(res);
            }
        }
    }
}




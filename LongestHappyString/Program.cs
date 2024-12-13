using System.Text;

namespace LongestHappyString
{
    public class Solution
    {
        public string LongestDiverseString(int a, int b, int c)
        {
            StringBuilder res = new StringBuilder();

            PriorityQueue<(int, char), int> maxheap = new PriorityQueue<(int, char), int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));
            if (a > 0) maxheap.Enqueue((a, 'a'), a);
            if (b > 0) maxheap.Enqueue((b, 'b'), b);
            if (c > 0) maxheap.Enqueue((c, 'c'), c);

            while (maxheap.Count > 0)
            {
                int currItemCount = maxheap.Peek().Item1;
                char currItemChar = maxheap.Peek().Item2;
                maxheap.Dequeue();
                
                if (res != null && res.Length != 0 && res.Length > 1 && res[res.Length - 1] == currItemChar && res[res.Length - 2] == currItemChar)
                {
                    if (maxheap.Count == 0)
                    {
                        break;
                    }
                    if (maxheap.Count > 0)
                    {
                        var nextItem = maxheap.Peek();
                        maxheap.Dequeue();
                        res.Append(nextItem.Item2);
                        int nextUpdateCount = nextItem.Item1 - 1;

                        if (nextUpdateCount > 0)
                        {
                            maxheap.Enqueue((nextUpdateCount, nextItem.Item2), nextUpdateCount);
                        }
                    }
                }
                else
                {
                    res.Append(currItemChar);

                    currItemCount--;
                    //maxheap.Enqueue((currUpdatedItem, currItemChar), currUpdatedItem);
                }

                if (currItemCount > 0)
                {
                    maxheap.Enqueue((currItemCount, currItemChar), currItemCount);
                }

            }
            return res.ToString();
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Solution s = new Solution();
            var res = s.LongestDiverseString(1, 1, 7);
            Console.WriteLine(res);
        }
    }
}
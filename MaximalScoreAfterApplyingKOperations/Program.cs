namespace MaximalScoreAfterApplyingKOperations
{
    public class Solution
    {
        public long MaxKelements(int[] nums, int k)
        {
            PriorityQueue<int, int> maxheap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));

            foreach (int num in nums)
            {
                maxheap.Enqueue(num, num);
            }
            long score = 0;
            for (int i = 0; i < k; i++)
            {
                int val = maxheap.Dequeue();
                score += val;
                int updateVal = (int)Math.Ceiling(val / 3.0);
                maxheap.Enqueue(updateVal, updateVal);
            }
            return score;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] nums = { 10, 10, 10, 10, 10 };
            int k = 5;
            Solution solution = new Solution();
            var res = solution.MaxKelements(nums, k);
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
namespace MonotonicArray
{
    //Time O(n)
    public class Solution
    {
        public bool IsMonotonic(int[] nums)
        {
            int n = nums.Length;
            bool increasing = false;
            bool decreasing = false;

            for (int i = 0; i < n - 1; i++)
            {
                if (nums[i] < nums[i + 1]) { increasing = true; }
                if (nums[i] > nums[i + 1]) { decreasing = true; }
            }

            if (increasing && decreasing)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
        internal class Program
        {
            public static void Main(string[] args)
            {
                Solution s = new Solution();
                int[] nums = { 1, 2, 2, 3 };
                var res = s.IsMonotonic(nums);
                Console.WriteLine(res);
                Console.ReadLine();
            }
        }
    }
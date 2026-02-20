using System.Collections.Specialized;

namespace SlidingSubarrayBeauty
{
    public class Solution
    {
        //nums = [1,-1,-3,-2,3], k = 3, x = 2
        public int[] GetSubarrayBeauty(int[] nums, int k, int x)
        {
            int i = 0;
            int j = 0;
            List<int> res = new();
            List<int> tmp = new();
            int n = nums.Length;
            int count = 0;
            while (j < n)
            {
                tmp.Add(nums[j] < 0 ? nums[j] : 0);
                count++;
                while (count >= k)
                {
                    count--;
                    tmp.Sort();
                    res.Add(tmp[x - 1]);
                    tmp.RemoveAt(i);
                    i++;
                }
               
                j++;
            }
            return res.ToArray();
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] nums = { 1, -1, -3, -2, 3 };
            int k = 3;
            int x = 2;
            var res = solution.GetSubarrayBeauty(nums, k, x);
            foreach (int i in nums)
            {
                Console.WriteLine(i);
            }
        }
    }
}
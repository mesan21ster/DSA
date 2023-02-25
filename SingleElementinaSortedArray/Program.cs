using System;

namespace SingleElementinaSortedArray
{
    public class Solution
    {
        public int SingleNonDuplicate(int[] nums)
        {
            int low = 0;
            int high = nums.Length - 1;

            while (low < high) {
                int mid = (low + high) / 2;
                if((mid % 2 == 0 && nums[mid] == nums[mid + 1]) || (mid % 2 == 1 && nums[mid] == nums[mid - 1]))
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid;
                }
            }
            return nums[low];
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] nums = { 1, 1, 2, 3, 3, 4, 4, 8, 8 };
            Console.WriteLine(solution.SingleNonDuplicate(nums));
            Console.ReadLine();
        }
    }
}

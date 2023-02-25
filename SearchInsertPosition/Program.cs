using System;

namespace SearchInsertPosition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] num = { 1, 3, 5, 6 };
            int target = 5;
            var res = SearchInsert(num, target);
            Console.WriteLine(res);
            Console.WriteLine("Hello World!");
        }

        public static int SearchInsert(int[] nums, int target)
        {
            int end = nums.Length-1;
            int start = 0;
           
           while(start<=end)
            {
                int mid = (start + end) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }
                if (nums[mid] > target) { 
                end = mid-1;
                }
                else
                {
                    start = mid + 1;
                }
            }
            
            return end+1;
        }
    }
}

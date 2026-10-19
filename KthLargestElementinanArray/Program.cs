namespace KthLargestElementinanArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 3, 2, 1, 5, 6, 4 };
            int k = 2;
            int result = FindKthLargest(nums, k);
            Console.WriteLine($"The {k}th largest element is: {result}");
        }
        public static int FindKthLargest(int[] nums, int k)
        {
            Array.Sort(nums);
            return nums[nums.Length - k];
        }
    }
}
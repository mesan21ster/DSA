namespace RemoveDuplicatesfromSortedArrayII
{
    public class Solution
    {
        public int RemoveDuplicates(int[] nums)
        {
            int k = 2;

            for (int i = 2; i < nums.Length; i++)
            {
                if (nums[i] != nums[k - 2]) {
                    nums[k] = nums[i];
                    k++;
                }
                
            }
            return k;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] nums = { 1, 1, 1, 2, 2, 3 };
            Solution solution = new Solution();
            var res = solution.RemoveDuplicates(nums);
            Console.WriteLine(res);
        }
    }
}
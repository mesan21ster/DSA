namespace RemoveDuplicatesfromSortedArray
{
    /*
     * Approach
    By iterating through the array and checking if nums at the current index i is less than nums at i + 1, 
    we can find an index for all unique numbers in the array. We can then insert each of these numbers to the beginning of the array, 
    at addIndex. addIndex starts at 0 as the first element in the array is always unique.
     
    Time complexity:O(n)
    Space complexity:O(1)
     */
    public class Solution
    {
        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0) return 0;

            int k = 1;
            for (int i = 0; i < nums.Length -1; i++)
            {
                
                if (nums[i] < nums[i + 1])
                {
                    nums[k] = nums[i + 1];
                    k++;
                }
            }
            return k;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] nums = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            Console.WriteLine(solution.RemoveDuplicates(nums));
            Console.ReadLine();
        }
    }
}
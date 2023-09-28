namespace SortArrayByParity
{
    //Time O(n)
    //space O(1)
    public class Solution
    {
        public int[] SortArrayByParity(int[] nums)
        {
            int j = 0;
            for(int i=0;i<nums.Length; i++)
            {
                if (nums[i] %2==0)
                {
                    swap(nums, i, j);
                    j++;
                }
            }
            return nums;
        }

        private void swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }
    internal class Program
    {
        public static void Main(string[] args)
        {
            Solution s = new Solution();
            int[] nums = { 3, 1, 2, 4 };
            var res = s.SortArrayByParity(nums);
            foreach(int i in nums)
            {
                Console.WriteLine(i);
            }
            
            Console.ReadLine();
        }
    }
}
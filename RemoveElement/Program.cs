namespace RemoveElement
{
    /*
     Time complexity:O(n)
Space complexity:O(1)
     */
    public class Solution
    {
        public int RemoveElement(int[] nums, int val)
        {
            int k = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val)
                {
                    nums[k] = nums[i];
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
            int[] nums = { 0, 1, 2, 2, 3, 0, 4, 2 };
            int val = 2;
            Console.WriteLine(solution.RemoveElement(nums,val));
            Console.ReadLine();
        }
    }
}

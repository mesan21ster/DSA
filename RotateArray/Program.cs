namespace RotateArray
{
    public class Solution
    {
        public void Rotate(int[] nums, int k)
        {
            k = k % nums.Length;

            int left = 0;
            int right = nums.Length - 1;
            while (left < right)
            {
                int temp1 = nums[left];
                nums[left] = nums[right];
                nums[right] = temp1;
                left++;

                right--;
            }

            left = 0;
            right = k - 1;
            while (left < right)
            {
                int temp1 = nums[left];
                nums[left] = nums[right];
                nums[right] = temp1;
                right--;
                left++;
            }

            left = k ;
            right = nums.Length - 1;
            while (left < right)
            {
                int temp1 = nums[left];
                nums[left] = nums[right];
                nums[right] = temp1;
                right--;
                left++;
            }
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7 };
            int k = 3;
            Solution solution = new Solution();
            solution.Rotate(nums, k);
            Console.ReadLine();
        }
    }
}
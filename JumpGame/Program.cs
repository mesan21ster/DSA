interface JumpGame
{
    public class Solution
    {
        public bool CanJump(int[] nums)
        {
            int goal = nums.Length - 1;
            for (int i = nums.Length - 2; i >= 0; i--)
            {
                if (i + nums[i] >= goal)
                {
                    goal = i;
                }
            }
            return goal == 0;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] arr = { 2, 3, 1, 1, 4 };
            Console.WriteLine(solution.CanJump(arr));
            Console.ReadLine();
        }
    }
}
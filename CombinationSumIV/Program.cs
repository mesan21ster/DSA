namespace CombinationSumIV
{
    public class Solution
    {
        int n = 0;
        int[,] temp = new int[201, 1001];
        public int CombinationSum4(int[] nums, int target)
        {
            n = nums.Length;
            for(int i = 0; i < 201; i++)
            {
                for(int j = 0; j < 1001; j++)
                {
                    temp[i, j] = -1;
                }
            }
            return solve(0, nums, target);
        }

        private int solve(int idx, int[] nums, int target)
        {
            if(target == 0)
            {
                return 1;
            }
            if(idx >=n || target < 0)
            {
                return 0;
            }

            if (temp[idx,target] != -1)
            {
                return temp[idx,target];
            }

            int take_idx = solve(0,nums,target - nums[idx]);
            int reject_idx = solve(idx+1,nums,target);
            return temp[idx,target] = take_idx + reject_idx;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] nums = { 1, 2, 3 };
            int target = 4;
            var res = solution.CombinationSum4(nums, target);
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
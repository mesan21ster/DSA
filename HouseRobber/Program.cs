
namespace HouseRobber
{
    /*
     You are a professional robber planning to rob houses along a street. Each house has a certain amount of money stashed, the only constraint stopping you from robbing each of them is that adjacent houses have security systems connected and it will automatically contact the police if two adjacent houses were broken into on the same night.

Given an integer array nums representing the amount of money of each house, return the maximum amount of money you can rob tonight without alerting the police.

 

Example 1:

Input: nums = [1,2,3,1]
Output: 4
Explanation: Rob house 1 (money = 1) and then rob house 3 (money = 3).
Total amount you can rob = 1 + 3 = 4.
Example 2:

Input: nums = [2,7,9,3,1]
Output: 12
Explanation: Rob house 1 (money = 2), rob house 3 (money = 9) and rob house 5 (money = 1).
Total amount you can rob = 2 + 9 + 1 = 12.
     */
    public class Solution
    {

        public int Rob(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;
            int[] memo = new int[nums.Length + 1];
            Array.Fill(memo, -1);
            return Solve(nums, 0, memo);
        }

        private int Solve(int[] nums, int index, int[] memo)
        {
            if (index >= nums.Length) return 0;

            if (memo[index] != -1)
            {
                return memo[index];
            }
            int take = nums[index] + Solve(nums, index + 2, memo);
            int skip = Solve(nums, index + 1, memo);

            return memo[index] = Math.Max(take, skip);
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Solution s = new Solution();
            int[] nums = { 2, 7, 9, 3, 1 };

            var res = s.Rob(nums);
            Console.WriteLine(res);
        }
    }
}
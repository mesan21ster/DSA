using System;
using System.Collections.Generic;

namespace TwoSum
{
    public class Solution
    {
        public int[] TwoSUm(int[] nums, int target)
        {
            int[] result = new int[2];

            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (map.ContainsKey(complement))
                {
                    result[0] = i;
                    result[1] = map[complement];
                    return result;
                }
                else
                {
                    map[nums[i]] = i;
                }
            }

            return result;
        }
    }
    internal class Program
    {
        //Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
        //You may assume that each input would have exactly one solution, and you may not use the same element twice.
        /*
         Example 1:

        Input: nums = [2,7,11,15], target = 9
        Output: [0,1]
        Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].

        Example 2:

        Input: nums = [3,2,4], target = 6
        Output: [1,2]

        Example 3:

        Input: nums = [3,3], target = 6
        Output: [0,1]
         */
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] nums = { 2, 7, 11, 15 };
            int target = 9;
            var res = solution.TwoSUm(nums, target);
            foreach (int i in res)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }

    }
}

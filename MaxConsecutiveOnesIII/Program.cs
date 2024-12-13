using System.ComponentModel.DataAnnotations;

namespace MaxConsecutiveOnesIII
{
    /*
     1004. Max Consecutive Ones III
Medium
Topics
Companies
Hint
Given a binary array nums and an integer k, return the maximum number of consecutive 1's in the array if you can flip at most k 0's.

 

Example 1:

Input: nums = [1,1,1,0,0,0,1,1,1,1,0], k = 2
Output: 6
Explanation: [1,1,1,0,0,1,1,1,1,1,1]
Bolded numbers were flipped from 0 to 1. The longest subarray is underlined.
Example 2:

Input: nums = [0,0,1,1,0,0,1,1,1,0,1,1,0,0,0,1,1,1,1], k = 3
Output: 10
Explanation: [0,0,1,1,1,1,1,1,1,1,1,1,0,0,0,1,1,1,1]
Bolded numbers were flipped from 0 to 1. The longest subarray is underlined.
     */
    public class Solution
    {
        public int LongestOnes(int[] nums, int k)
        {
            int res = 0;
            int i = 0;
            int j = 0;
            int n = nums.Length;
            int zeros = 0;

            while (j < n)
            {
                if (nums[j] == 0)
                {
                    zeros++;
                }

                if (zeros > k)
                {
                    if (nums[i] == 0)
                    {
                        zeros--;
                    }
                    i++;
                }
                if (zeros <= k)
                {
                    res = Math.Max(res, j - i + 1);
                }
                j++;
            }

            return res;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] nums = { 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1 };
            int k = 3;

            var res = solution.LongestOnes(nums, k);

            Console.WriteLine(res);
        }
    }
}
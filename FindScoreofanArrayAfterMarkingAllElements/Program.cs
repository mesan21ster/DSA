namespace FindScoreofanArrayAfterMarkingAllElements
{
    //O(n log n)
    /*
     You are given an array nums consisting of positive integers.

Starting with score = 0, apply the following algorithm:

Choose the smallest integer of the array that is not marked. If there is a tie, choose the one with the smallest index.
Add the value of the chosen integer to score.
Mark the chosen element and its two adjacent elements if they exist.
Repeat until all the array elements are marked.
Return the score you get after applying the above algorithm.

 

Example 1:

Input: nums = [2,1,3,4,5,2]
Output: 7
Explanation: We mark the elements as follows:
- 1 is the smallest unmarked element, so we mark it and its two adjacent elements: [2,1,3,4,5,2].
- 2 is the smallest unmarked element, so we mark it and its left adjacent element: [2,1,3,4,5,2].
- 4 is the only remaining unmarked element, so we mark it: [2,1,3,4,5,2].
Our score is 1 + 2 + 4 = 7.
Example 2:

Input: nums = [2,3,5,1,3,2]
Output: 5
Explanation: We mark the elements as follows:
- 1 is the smallest unmarked element, so we mark it and its two adjacent elements: [2,3,5,1,3,2].
- 2 is the smallest unmarked element, since there are two of them, we choose the left-most one, so we mark the one at index 0 and its right adjacent element: [2,3,5,1,3,2].
- 2 is the only remaining unmarked element, so we mark it: [2,3,5,1,3,2].
Our score is 1 + 2 + 2 = 5.
     */
    public class Solution
    {
        public long FindScore(int[] nums)
        {

            SortedDictionary<(int val, int idx), int> map = new SortedDictionary<(int, int), int>();
            for (int i = 0; i < nums.Length; i++)
            {
                map.Add((nums[i], i), i);
            }
            long score = 0;

            #region not simplified version
            //foreach (var item in map)
            //{
            //    int currKey = item.Key.idx;
            //    int currValue = item.Key.val;

            //    if (nums[currKey] < 0)
            //    {
            //        continue;
            //    }
            //    score += currValue;
            //    if (currValue != -currValue)
            //    {
            //        nums[currKey] = -currValue;
            //    }

            //    if (currKey == 0 && currKey + 1 <= nums.Length - 1 && nums[currKey + 1] >0)
            //    {
            //        nums[currKey + 1] = -nums[currKey + 1];
            //    }

            //    if (nums[currKey] == nums[nums.Length - 1] && currKey > 0 && nums[currKey - 1] > 0)
            //    {
            //        nums[currKey - 1] = -nums[currKey - 1];
            //    }

            //    if (currKey > 0 && currKey < nums.Length - 1 && currKey + 1 <= nums.Length - 1 && nums[currKey + 1] > 0)
            //    {
            //        nums[currKey + 1] = -nums[currKey + 1];
            //    }

            //    if (currKey > 0 && currKey < nums.Length - 1 && nums[currKey - 1] > 0)
            //    {
            //        nums[currKey - 1] = -nums[currKey - 1];
            //    }

            //}
            #endregion
            bool[] marked = new bool[nums.Length];
            foreach (var item in map)
            {
                int currKey = item.Key.idx;
                int currValue = item.Key.val;

                if (marked[currKey])
                {
                    continue;
                }

                score += currValue;
                marked[currKey] = true;

                if (currKey > 0)
                {
                    marked[currKey - 1] = true;
                }

                if (currKey < nums.Length - 1)
                {
                    marked[currKey + 1] = true;
                }

            }
            return score;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] nums = { 2, 1, 3, 4, 5, 2 };
            var res = solution.FindScore(nums);

            Console.WriteLine(res);
        }
    }
}
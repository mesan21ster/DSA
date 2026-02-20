namespace TransformedArray
{
    /*
     You are given an integer array nums that represents a circular array. Your task is to create a new array result of the same size, following these rules:

For each index i (where 0 <= i < nums.length), perform the following independent actions:
If nums[i] > 0: Start at index i and move nums[i] steps to the right in the circular array. Set result[i] to the value of the index where you land.
If nums[i] < 0: Start at index i and move abs(nums[i]) steps to the left in the circular array. Set result[i] to the value of the index where you land.
If nums[i] == 0: Set result[i] to nums[i].
Return the new array result.

Note: Since nums is circular, moving past the last element wraps around to the beginning, and moving before the first element wraps back to the end.
     */
    public class Solution
    {
        public int[] ConstructTransformedArray(int[] nums)
        {
            int[] res = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < 0)
                {

                }
            }
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] nums = { -4, -1, 0, 3, 10 };
            int[] transformedArray = solution.ConstructTransformedArray(nums);
            Console.WriteLine("Transformed Array: " + string.Join(", ", transformedArray));
        }
    }
}

namespace MinimumNumberofRemovalstoMakeMountainArray
{
    public class Solution
    {
        public int MinimumMountainRemovals(int[] nums)
        {

            return 0;
        }
    }
    public class Program
    {
        public static void Main(string[] args) 
        {
            int[] nums = { 1, 3, 1 };
            Solution s = new Solution();
            var res = s.MinimumMountainRemovals(nums);
            Console.WriteLine(res);
        }
    }
}
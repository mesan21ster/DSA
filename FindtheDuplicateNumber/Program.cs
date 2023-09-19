namespace FindtheDuplicateNumber
{
    public class Solution
    {
        public int FindDuplicate(int[] nums)
        {
            int slow = nums[0];
            int fast = nums[0];

            slow = nums[slow];//move one
            fast = nums[nums[fast]];//move twice

            while(slow != fast)// this is to detect cycle
            {
                slow = nums[slow];
                fast = nums[nums[fast]];
            }

            slow = nums[0];

            while(fast != slow)
            {
                slow = nums[slow];
                fast = nums[fast];
            }
            return slow;//we can slow return fast, both will be pointing to same value 
        }
    }
    internal class Program
    {
        public static void Main(string[] args)
        {
            Solution s = new Solution();
            int[] nums = { 3, 1, 3, 4, 2 };
            var res = s.FindDuplicate(nums);
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
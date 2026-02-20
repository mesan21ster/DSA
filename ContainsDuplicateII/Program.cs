namespace ContainsDuplicateII
{
    public class Solution
    {
        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            HashSet<int> seen = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (seen.Contains(nums[i]))
                {
                    return true;
                }
                seen.Add(nums[i]);
                if (seen.Count > k)
                {
                    seen.Remove(nums[i - k]);// Remove the element that is now out of the k range
                }
            }
            return false;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] nums = { 1, 2, 3, 1 };
            int k = 3;
            bool result = solution.ContainsNearbyDuplicate(nums, k);
            Console.WriteLine("Contains nearby duplicate: " + result);
        }
    }
}
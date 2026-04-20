namespace MinimumAbsoluteDistanceBetweenMirrorPairs
{
    //final Time: O(n * log10(num))
    public class Solution
    {
        public int MinMirrorPairDistance(int[] nums)
        {
            int res = int.MaxValue;
            Dictionary<int, int> mirrotMap = new Dictionary<int, int>();
            //Time  : O(n) for iterate 

            for (int i = 0; i < nums.Length; i++)
            {
                int rev = getReverse(nums[i]);
                if (mirrotMap.ContainsKey(nums[i]))
                {
                    res = Math.Min(res, i - mirrotMap[nums[i]]);

                }

                mirrotMap[rev] = i;

            }
            return res == int.MaxValue ? -1 : res;
        }

        private int getReverse(int num) //time : log10(num) for reverse the number
        {
            int rev = 0;
            while(num > 0)
            {
                int rem = num % 10;//get last digit
                rev = rev * 10 + rem; // append to rev variable
                num /= 10; // remove last digit
            }
            return rev;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            int[] nums = { 12, 21, 45, 33, 54 };
            Solution solution = new Solution();
            var res = solution.MinMirrorPairDistance(nums);
            Console.WriteLine(res);
        }
    }
}
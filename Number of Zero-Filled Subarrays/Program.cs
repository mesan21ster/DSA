namespace NumberofZeroFilledSubarrays
{
    //n(n+1)/2 this is the formula to get all the count of subarray in a contigues value
    //increase count of contiguous  zero's from array , if any other number comes in beetween then continue with last count of zeros
    // index   0  1  2  3  4  5  6  7  8   9   10  11
    // array   1, 0, 0, 0, 2, 2, 0, 0, 0,  0,  1,  0
    // count   0, 1, 2, 3, 0, 0, 1, 2, 3,  4,  0,  1 // count of contiguous  zero's
    // ans     0, 1, 3, 6, 6, 6, 7, 9, 12, 16, 16, 17 // 17 is the ans (sum of contiguous  zero's)//index pos 4,5 and 10 is non zeor so they are carring previous sum of zeros
    // contiguous value follow n(n+1)/2 formula to get total subarray 
    //ex. till index 1 to 3 ans is 6 and count is 3 so as per formula it would be 3(3+1)/2 = 6
    /// </summary>
    public class Solution
    {
        public long ZeroFilledSubarray(int[] nums)
        {
            long ans = 0;
            long numberOfZeros = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    numberOfZeros++;
                }
                else
                {
                    numberOfZeros = 0;
                }
                ans += numberOfZeros;
            }
            return ans;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int[] nums = { 1, 3, 0, 0, 2, 0, 0, 4 };
            Console.WriteLine(s.ZeroFilledSubarray(nums));
            Console.ReadLine();
        }
    }
}
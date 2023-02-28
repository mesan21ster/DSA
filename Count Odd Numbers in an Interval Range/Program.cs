namespace CountOddNumbersinanIntervalRange
{
    /*
     * 
     * 
     * Given two non-negative integers low and high. Return the count of odd numbers between low and high (inclusive).
     * 
     Complexity
Time complexity:O(1)
Space complexity:O(1)

     */
    public class Solution
    {
        public int CountOdds(int low, int high)
        {
            if(low %2 ==1 && high %2 ==1) {//high and low both are odd so adding 2 and then half is odd so divide by 2 and substract 1; 
                return 2 + (high - low) / 2 - 1;
            }
            else if(low%2==1 || high%2 ==1)//either of one is odd
            {
                return 1+ (high- low) / 2;
            }
            else//both are even
            {
                return (high - low) / 2;
            }

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            var res = solution.CountOdds(3, 7);
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}

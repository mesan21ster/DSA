namespace SeparateBlackandWhiteBalls
{
    /*
     Example 1:

        Input: s = "101"
        Output: 1
        Explanation: We can group all the black balls to the right in the following way:
        - Swap s[0] and s[1], s = "011".
        Initially, 1s are not grouped together, requiring at least 1 step to group them to the right.
     */

    public class Solution
    {
        public long MinimumSteps(string s)
        {
            if (s == null)
                return -1;

            int black = 0;
            int swap = 0;

            for(int i = 0; i < s.Length; i++)
            {
                if (s[i] == '1')
                {
                    black++;
                }
                else
                {
                    swap = swap + black;
                }
            }

            return swap;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Solution obj = new Solution();
            string s = "101";
            var res  = obj.MinimumSteps(s);
            Console.WriteLine(res);
        }
    }
}
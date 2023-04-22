namespace MinimumInsertionStepstoMakeaStringPalindrome
{
    //Time complexity: O(n^2)
    //Space complexity:O(n^2)

    public class Solution
    {
        int[,] dp = new int[501, 501];
        public int MinInsertions(string s)
        {
            int n = s.Length;
            for (int i = 0; i < 501; i++)
            {
                for (int j = 0; j < 501; j++)
                {
                    dp[i, j] = -1;// initialize dp array with -1
                }
            }
            return solve(s, 0, n - 1);// pointer on 0th index and las index
        }

        private int solve(string s, int start, int end)
        {
            if (start >= end)// this is the terminating condition
            {
                return 0;
            }
            else if (dp[start, end] != -1)
            {
                return dp[start, end];// return from dp 
            }
            else 
            {
                if (s[start] == s[end]) // if both char match of both indexes than increment start index and decrement end index
                {
                    return dp[start, end] = solve(s, start + 1, end - 1);
                }
                else // there are two chioses 1) insert at beginning 2) insert at end
                {
                    int insertAtBegining = solve(s, start, end - 1);// insert char at begining will keep start index constent to same postion but end index will decrease
                    int insertAtEnd = solve(s, start + 1, end); // insert at end will keep end index constent but start index will increase
                    return dp[start, end] = Math.Min(insertAtBegining, insertAtEnd) + 1;// get the minimum step out of both , +1 means no of char inserted
                }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            string s = "leetcode";
            var res = solution.MinInsertions(s);

            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
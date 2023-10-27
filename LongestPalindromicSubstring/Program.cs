namespace LongestPalindromicSubstring
{
    //TC O(n^2)
    public class Solution
    {
        int[,] dp = new int[1001, 1001];
        private int isPalindrom(string s, int i, int j)
        {
            if (i >= j)
            {
                return 1;
            }
            if (dp[i, j] != -1)
            {
                return dp[i, j];
            }
            if (s[i] == s[j])
            {
                return dp[i, j] = isPalindrom(s, i + 1, j - 1);
            }
            return dp[i, j] = 0;
        }
        public string LongestPalindrome(string s)
        {
            int n= s.Length;
            int maxLength = int.MinValue;
            int sp = 0;

            for (int i = 0; i < 1001; i++)
            {
                for (int j = 0; j < 1001; j++)
                {
                    dp[i, j] = -1;
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    if(isPalindrom(s, i, j) ==1)
                    {
                        if (j - i + 1 > maxLength)
                        {
                            maxLength = j - i + 1;
                            sp = i;
                        }
                    }
                }
            }

            return s.Substring(sp, maxLength);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            string s = "babad";
            var res = solution.LongestPalindrome(s);
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
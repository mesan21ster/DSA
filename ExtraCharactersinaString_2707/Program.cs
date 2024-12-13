
namespace ExtraCharactersinaString_2707
{
    public class Solution
    {
        HashSet<string>? dictionarySet;
        int[] dp = new int[51];
        public int MinExtraChar(string s, string[] dictionary)
        {
            int n = s.Length;
            dictionarySet = new (dictionary);
            Array.Fill(dp, -1);
            return solve(0, s, dictionarySet, n);
        }

        private int solve(int i, string s, HashSet<string> st,int n)
        {
            if (i >= n)
            {
                return 0;
            }
            if (dp[i] != -1)
            {
                return dp[i];
            }

            int res = 1 + solve(i+1, s, st, n);//skip ith char , than you have a add 1 in res and pass i+1(next)char to recurrertion 

            for (int j = i; j < n; j++) {
                string sub = s.Substring(i, j - i + 1);
                if (st.Contains(sub)) {
                    //valid substring in dictionary

                    res = Math.Min(res, solve(j + 1, s, st, n));
                }
            }

            return dp[i] = res;

        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            string s = "leetscode";
            string[] dictionary = { "leet", "code", "leetcode" };

            var res = solution.MinExtraChar(s, dictionary);
            Console.WriteLine(res);

            Console.ReadLine();
        }
    }
}
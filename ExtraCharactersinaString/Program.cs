using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;

namespace ExtraCharactersinaString
{
    public class Solution
    {
        HashSet<string> dictionarySet;
        int[] dp;
        public int MinExtraChar(string s, string[] dictionary)
        {

            dp = new int[s.Length];
            Array.Fill(dp, int.MaxValue);
            dictionarySet = new(dictionary);
            return Helper(s, 0);
        }
    
        private int Helper(string s, int idx)
        {
            if (idx >= s.Length)
            {
                return 0;
            }

            if (dp[idx] != int.MaxValue)
            {
                return dp[idx];
            }

            dp[idx] = s.Length;
            int len = 1;

            for (int i = idx; i < s.Length; i++, len++)
            {
                if (dictionarySet.Contains(s.Substring(idx, len)))
                {
                    dp[idx] = Math.Min(dp[idx], Helper(s, i + 1));
                }
                else
                {
                    dp[idx] = Math.Min(dp[idx], len + Helper(s, i + 1));
                }
            }

            return dp[idx];
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            string s = "leetscode";
            string[] dictionary = {"leet", "code", "leetcode"};

            var res = solution.MinExtraChar(s, dictionary);
            Console.WriteLine(res);

            Console.ReadLine();
        }
    }
}

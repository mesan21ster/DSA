using System.Net.Http.Headers;

namespace WordSubsets
{
    /*
     You are given two string arrays words1 and words2.

A string b is a subset of string a if every letter in b occurs in a including multiplicity.

For example, "wrr" is a subset of "warrior" but is not a subset of "world".
A string a from words1 is universal if for every string b in words2, b is a subset of a.

Return an array of all the universal strings in words1. You may return the answer in any order.

 

Example 1:

Input: words1 = ["amazon","apple","facebook","google","leetcode"], words2 = ["e","o"]
Output: ["facebook","google","leetcode"]
Example 2:

Input: words1 = ["amazon","apple","facebook","google","leetcode"], words2 = ["l","e"]
Output: ["apple","google","leetcode"]
     */
    public class Solution
    {
        public IList<string> WordSubsets(string[] words1, string[] words2)
        {
            List<string> result = new List<string>();
            int[] freq2 = new int[26];
            foreach (var word in words2)
            {
                int[] tmp = new int[26];

                foreach (char ch in word)
                {
                    tmp[ch - 'a']++;
                    freq2[ch - 'a'] = Math.Max(freq2[ch - 'a'], tmp[ch - 'a']);
                }
            }


                foreach (string word in words1)
                {
                    int[] tmp = new int[26];
                    foreach (char ch in word)
                    {
                        tmp[ch - 'a']++;
                    }

                    if (isSubSet(freq2, tmp) == true)
                    {
                        result.Add(word);
                    }
                }

            return result;
        }

        private bool isSubSet(int[] freq2, int[] tmp)
        {
            for (int i = 0; i < 26; i++) {
                if (tmp[i] < freq2[i]) {
                    return false;
                }
            }
            return true;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Solution s = new Solution();

            string[] words1 = { "amazon", "apple", "facebook", "google", "leetcode" };
            string[] words2 = { "e", "o" };

            var res = s.WordSubsets(words1, words2);
            foreach (string word in res)
            {
                Console.WriteLine(word);
            }

        }
    }
}
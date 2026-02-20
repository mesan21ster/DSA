namespace NumberofSubstringsContainingAllThreeCharacters
{
    /*
     Given a string s consisting only of characters a, b and c.

Return the number of substrings containing at least one occurrence of all these characters a, b and c.


    Example 1:

Input: s = "abcabc"
Output: 10
Explanation: The substrings containing at least one occurrence of the characters a, b and c are "abc", "abca", "abcab", "abcabc", "bca", "bcab", "bcabc", "cab", "cabc" and "abc" (again). 
Example 2:

Input: s = "aaacb"
Output: 3
Explanation: The substrings containing at least one occurrence of the characters a, b and c are "aaacb", "aacb" and "acb". 
Example 3:

Input: s = "abc"
Output: 1


     */
    public class Solution
    {
        public int NumberOfSubstrings(string s)
        {
            int n = s.Length;

            Dictionary<char, int> map = new Dictionary<char, int>
            {
                { 'a', 0 },
                { 'b', 0 },
                { 'c', 0 }
            };
            int res = 0;
            int i = 0;
            int j = 0;

            while (j < n)
            {
                map[s[j]]++;

                while (map['a'] >0 && map['b'] >0 && map['c'] > 0)
                {
                    res += (n - j);
                    map[s[i]]--;
                    i++;
                }
                j++;
            }

            return res;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Solution solution = new Solution();
            string s = "abcabc";
            var res = solution.NumberOfSubstrings(s);
            Console.WriteLine(res);
        }
    }
}
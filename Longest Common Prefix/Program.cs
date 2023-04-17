namespace LongestCommonPrefix
{
    public class Solution
    {
        //time complexity is O(Nlog(N) + M)
        //Iterating over the characters of the first and last strings takes O(M) time. This is because the code compares the characters of the two strings until it finds the first mismatch.
        public string LongestCommonPrefix(string[] strs)
        {
            Array.Sort(strs, StringComparer.OrdinalIgnoreCase);

            string s1 = strs[0];
            string s2 = strs[strs.Length -1];
            string res = "";

            for (int i = 0; i < strs[0].Length; i++)
            {
                if (s1[i] == s2[i])
                {
                    res += s1[i];
                }
                else
                {
                    break;
                }
            }
            return res;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();

            string[] strs = { "flower", "flow", "flight" };
            Console.WriteLine(solution.LongestCommonPrefix(strs));
            Console.ReadLine();
        }
    }
}
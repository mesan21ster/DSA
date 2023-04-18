namespace MergeStringsAlternately
{
    public class Solution
    {
        /*
         Initialize an empty string to store the merged result.
Traverse both input strings together, picking each character alternately from both strings and appending it to the merged result string.
Continue the traversal until the end of the longer string is reached.
Return the merged result string.
        Time O(N)
        Space O(N)
         */
        public string MergeAlternately(string word1, string word2)
        {
            int i = 0;
            string res = "";
            while (i < word1.Length || i < word2.Length)
            {
                if(i < word1.Length)
                {
                    res += word1[i];
                }
                if(i < word2.Length)
                {
                    res += word2[i];
                }
                i++;
            }

            return res;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();

            string word1 = "ab";
            string word2 = "pqrs";
            var res = solution.MergeAlternately(word1, word2);
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
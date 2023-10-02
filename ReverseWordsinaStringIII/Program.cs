namespace ReverseWordsinaStringIII
{
    public class Solution
    {
        public string ReverseWords(string s)
        {
            string[] words = s.Split(' ');
            string[] result = new string[words.Length];
            for (int i = 0; i < words.Length; i++) {
                char[] wordChar = words[i].ToCharArray();
                Array.Reverse(wordChar);
                result[i] = string.Join("", wordChar); 
            }
            return string.Join(" ", result);
        }
    }
    internal class Program
    {
        public static void Main(string[] args)
        {
            Solution sol = new Solution();
            string s = "God Ding";
            var res = sol.ReverseWords(s);
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
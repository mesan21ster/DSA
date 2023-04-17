namespace LengthofLastWord
{
    public class Solution
    {
        public int LengthOfLastWord(string s)
        {
            string[] words = s.Split(' ',StringSplitOptions.RemoveEmptyEntries);
            string lastword = words[words.Length - 1];

            return lastword.Length;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();

            string s = "   fly me   to   the moon  ";
            Console.WriteLine(solution.LengthOfLastWord(s));
            Console.ReadLine();
        }
    }
}
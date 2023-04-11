using System.Runtime.InteropServices;
using System.Text;

namespace RemovingStarsFromaString
{
    public class Solution
    {
        public string RemoveStars(string s)
        {
            StringBuilder t = new StringBuilder();
            foreach (var c in s)
            {
                if (c != '*')
                    t.Append(c);
                else
                    t.Remove(t.Length - 1, 1);
            }
            return t.ToString();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            string s = "leet**cod*e";
            Console.WriteLine(solution.RemoveStars(s));
            Console.ReadLine();
        }
    }
}
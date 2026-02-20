using System.Text.RegularExpressions;

namespace ValidPalindrome
{
    public class Solution
    {
        public bool IsPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return true;
            }
            string cleaned = Regex.Replace(s, @"[^a-zA-Z0-9]", "");
            string first = cleaned.ToLower();

            string second = "";
            char[] rev = first.ToCharArray();
            
            for(int i = rev.Length - 1; i >= 0; i--)
            {
                second += rev[i];
            }

            //string second = new string(rev);
            Console.WriteLine($"First: {first}, Second: {second}");
            if (first == second)
            {
                return true;
            } else {
                return false;
            }

            //int i = 0;
            //int j = s.Length - 1;
            //while (i < j)
            //{
            //    while (i < j && !char.IsLetterOrDigit(s[i]))
            //    {
            //        i++;
            //    }
            //    while (i < j && !char.IsLetterOrDigit(s[j]))
            //    {
            //        j--;
            //    }
            //    if (char.ToLower(s[i]) != char.ToLower(s[j]))
            //    {
            //        return false;
            //    }
            //    i++;
            //    j--;
            //}
            //return true;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Solution solution = new Solution();
            //Console.WriteLine(solution.IsPalindrome("A man, a plan, a canal: Panama")); // True
            Console.WriteLine(solution.IsPalindrome("race a car")); // False
            Console.ReadLine();
        }
    }
}
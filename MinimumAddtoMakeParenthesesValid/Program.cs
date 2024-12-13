namespace MinimumAddtoMakeParenthesesValid
{
    public class Solution
    {
        public int MinAddToMakeValid(string s)
        {
            int openingP = 0;
            int closingP = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    openingP++;
                }
                else if (s[i] == ')' && openingP > 0)
                {
                    openingP--;
                }
                else
                {
                    closingP++;
                }
            }

          return openingP + closingP;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            string s = "()))((";
            // s= "()))(("  output should be 4
            var res = solution.MinAddToMakeValid(s);
            Console.WriteLine(res);

            Console.ReadLine();
        }
    }
}

using System.Text;

namespace ThekthLexicographicalStringofAllHappyStringsofLengthn
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = 1;
            int k = 4;

            Solution solution = new Solution();

            var res = solution.GetHappyString(n, k);

            Console.WriteLine(res);
        }
    }
    public class Solution
    {
        public string GetHappyString(int n, int k)
        {
            //{"a","b","c"}

            List<string> res = new List<string>();
            StringBuilder hstring = new StringBuilder();
            solve(n, hstring, res);
            if(res.Count < k)
            {
                return "";
            }
            return res[k - 1];
        }

        private void solve(int n, StringBuilder hstring, List<string> res)
        {
            if (hstring.Length == n)
            {
                res.Add(hstring.ToString());
                return;
            }

            for (char ch = 'a'; ch <= 'c'; ch++)
            {
                if (!string.IsNullOrEmpty(hstring.ToString()) && hstring.ToString().Substring(hstring.Length - 1, 1) == ch.ToString()) {
                    continue;
                }

                //DO
                hstring.Append(ch);

                //explore
                solve(n, hstring, res);

                //undo

                hstring.Length--;
            }
        }
    }
}
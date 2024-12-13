using System.Text;

namespace RotateString
{
    public class Solution
    {
        public bool RotateString(string s, string goal)
        {
            StringBuilder sb = new StringBuilder(s);


            int n = s.Length;
            //int i = 0;
            while (n > 0)
            {
                //"abcde" "-->" "bcdea"

                char item = sb.ToString()[0];
                sb.Remove(0, 1);
                sb.Append(item);
                if (sb.ToString() == goal)
                {

                    return true;
                }
                n--;
            }
            return false;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {

            Solution solution = new Solution();
            string s = "abcde";
            string goal = "cdeab";
            var res = solution.RotateString(s, goal);
            Console.WriteLine(res);
        }
    }
}
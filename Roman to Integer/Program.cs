namespace RomantoInteger
{
    public class Solution
    {
        public int RomanToInt(string s)
        {
            int ans = 0;
            int number = 0;
            int prev = 0;
            for (int i = s.Length - 1; i >= 0;i--)
            {
                if (s[i] == 'M')
                {
                    number = 5000;
                }else if (s[i] == 'D')
                {
                    number = 500;
                }else if (s[i] == 'C')
                {
                    number = 100;
                }else if (s[i] == 'L')
                {
                    number = 50;
                }else if (s[i] == 'X')
                {
                    number = 10;
                }else if (s[i] == 'V')
                {
                    number = 5;
                }
                else if (s[i] == 'I')
                {
                    number = 1;
                }

                if(number < prev)
                {
                    ans -= number;
                }
                else { ans += number; 
                }
                prev = number;
            }
            return ans;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            string s = "MCMXCIV";
            Console.WriteLine(solution.RomanToInt(s));
            Console.ReadLine();
        }
    }
}
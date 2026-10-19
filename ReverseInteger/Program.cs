namespace ReverseInterger
{
    public class Solution
    {
        public int Reverse(int x)
        {
            int res = 0;
            while (x != 0)
            {
                int digit = x % 10; // get last digit
                x /= 10; // remove last digit

                if ((res > int.MaxValue / 10) || (res < int.MinValue / 10))
                {
                    return 0;// return 0 in case of overflow
                }

                // recreate reversed number
                res = res * 10 + digit;
            }
            return res;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Solution solution = new Solution();
            int x = 1534236469;
            var res = solution.Reverse(x);
            Console.WriteLine(res);
            Console.ReadLine();
        }

    }
}
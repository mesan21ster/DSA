using System.Text;

namespace AddBinary
{
    //Given two binary strings a and b, return their sum as a binary string.
    /*
     Input: a = "11", b = "1"
Output: "100"
     */
    public class Solution
    {
        public string AddBinary(string a, string b)
        {

            StringBuilder sb = new StringBuilder();
            int carry = 0;
            int i = a.Length - 1;
            int j = b.Length - 1;
            while (i >= 0 || j >= 0 || carry == 1)
            {
                if (i >= 0)
                {
                    carry += a[i--] - '0';
                }
                if (j >= 0)
                {
                    carry += b[j--] - '0';
                }

                sb.Append(carry % 2);
                carry /= 2;
            }
            return new string(sb.ToString().Reverse().ToArray());


        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            var res = solution.AddBinary("1010", "1011");
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}

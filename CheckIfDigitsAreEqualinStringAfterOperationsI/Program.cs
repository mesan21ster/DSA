namespace CheckIfDigitsAreEqualinStringAfterOperationsI
{
    public class Solution
    {
        public bool HasSameDigits(string s)
        {
            char[] s1 = s.ToCharArray();
            int n = s1.Length;
            while (n > 2)
            {
                for (int i = 0; i < n - 1; i++)
                {
                    s1[i] = (char)((((s1[i] - '0') + (s1[i + 1] - '0')) % 10) + '0');
                }
                n--;
            }
            return s1[0] == s1[1];
        }

    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Solution solution = new Solution();
            string s = "1234";
            bool result = solution.HasSameDigits(s);
            Console.WriteLine(result); 
        }

    }
}
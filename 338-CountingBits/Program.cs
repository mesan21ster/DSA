namespace CountingBits
{
    public class Solution
    {
        public int[] CountBits(int n)
        {
            int[] result = new int[n+1];
            if (n == 0)
            {
                return result;
            }
            result[0] = 0;//binary of 0 has 0 numbers of bits set of 1 //

            for(int i=1;i<=n;i++)
            {
                if(i%2 != 0)
                {
                    result[i] = result[i / 2] + 1;
                }
                else
                {
                    result[i] = result[i / 2];
                }
            }
            return result;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();

            var n = 5;
            var res = solution.CountBits(n);
            foreach(int i in res)
            {
                Console.WriteLine(i);
            }

            Console.ReadLine();
        }
    }
}
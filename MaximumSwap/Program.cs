using System.Text;

namespace MaximumSwap
{
    public class Solution
    {
        public int MaximumSwap(int num)
        {
            //int[] mapindex = new int[num];
            //StringBuilder snum = new StringBuilder(num.ToString());
            //mapindex[snum.Length - 1] = snum.Length - 1;

            //for(int i=snum.Length -2;i >= 0; i--)
            //{
            //    int rMaxId = mapindex[i+1];
            //    int rMaxEelement = snum[rMaxId];


            //    if(snum[i]< snum[i + 1])
            //    {
            //        mapindex[i] = i + 1;
            //    }
            //    else
            //    {
            //        mapindex[i] = i;
            //    }
            //}

            //for(int i = 0; i < snum.Length; i++)
            //{
            //    int maxRightIdx = (int)mapindex[i];
            //    char maxRightElement = snum[maxRightIdx];
            //    if ((char)snum[i] < maxRightElement)
            //    {
            //        char temp = snum[maxRightIdx];
            //        snum[maxRightIdx] = snum[i];
            //        snum[i] = temp;
            //        return int.Parse(new string(snum.ToString()));
            //    }
            //}

            //return num;


            char[] digits = num.ToString().ToCharArray();
            int n = digits.Length;

            int maxPos = n - 1;
            int x = -1, y = -1;

            for (int i = n - 2; i >= 0; i--)
            {
                if (digits[i] < digits[maxPos])
                {
                    x = i;
                    y = maxPos;
                }
                else if (digits[i] > digits[maxPos])
                {
                    maxPos = i;
                }
            }
            if (x != -1 && y != -1)
            {

                char temp = digits[x];
                digits[x] = digits[y];
                digits[y] = temp;

                return int.Parse(new string(digits));
            }
            return num;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            //        1133 //01344
            int num = 98368;
            Solution solution = new Solution();
            var res = solution.MaximumSwap(num);
            Console.WriteLine(res);
        }
    }
}
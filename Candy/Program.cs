namespace Candy
{
    public class Solution
    {

        #region with two extra space O(N)
        /*
        public int Candy(int[] ratings)
        {
            int size = ratings.Length;
            int[] L2R = new int[size];
            int[] R2L = new int[size];
            Array.Fill(L2R, 1);
            Array.Fill(R2L, 1);

            for (int i = 1; i < size; i++)
            {
                if (ratings[i] > ratings[i - 1])
                {
                    L2R[i] = Math.Max(L2R[i], L2R[i - 1] + 1);
                }
            }

            for (int i = size - 2; i >= 0; i--)
            {
                if (ratings[i] > ratings[i + 1])
                {
                    R2L[i] = Math.Max(R2L[i], R2L[i + 1] + 1);
                }
            }

            int res = 0;
            for (int i = 0; i < size; i++)
            {
                res += Math.Max(L2R[i], R2L[i]);
            }
            return res;
        }
    }
     */
        #endregion

        #region with single extra space O(N)
        public int Candy(int[] ratings)
        {
            int size = ratings.Length;
            int[]count = new int[size];
            Array.Fill(count, 1);//everyone should have 1 candy

            for(int i = 1;i<size;i++)
            {
                if (ratings[i] > ratings[i - 1])
                {
                    count[i] = Math.Max(count[i], count[i - 1] + 1);
                }
            }
            for(int i = size - 2; i >= 0; i--)
            {
                if (ratings[i] > ratings[i + 1])
                {
                    count[i] = Math.Max(count[i], count[i+1] + 1);
                }
            }
            int res = 0;
            for(int i = 0; i < size; i++)
            {
                res+= count[i];
            }
            return res;
        }
        #endregion
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] ratings = { 1, 0, 2 };
            var res = solution.Candy(ratings);
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
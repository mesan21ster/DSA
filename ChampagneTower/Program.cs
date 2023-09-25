namespace ChampagneTower
{
    public class Solution
    {
        double[,] temp = new double[101, 101];
        public double ChampagneTower(int poured, int query_row, int query_glass)
        {
            for (int i = 0; i < 101; i++)
            {
                for (int j = 0; j < 101; j++)
                {
                    temp[i, j] = -1;
                }
            }
            return Math.Min(1.0, solve(poured, query_row, query_glass));
        }

        private double solve(int poured, int i, int j)
        {
            if (i < 0 || j < 0 || i < j)
            {
                return 0.0;
            }

            if (i == 0 && j == 0)
            {
                return poured;
            }
            if (temp[i, j] != -1)
            {
                return temp[i, j];
            }
            double left_up = (solve(poured, i - 1, j - 1) - 1) / 2.0;
            double right_up = (solve(poured, i - 1, j) - 1) / 2.0;

            if (left_up < 0)
            {
                left_up = 0.0;
            }

            if (right_up < 0)
            {
                right_up = 0.0;
            }
            return temp[i, j] = left_up + right_up;
        }
    }
    internal class Program
    {
        public static void Main(string[] args)
        {
            Solution s = new Solution();
            var res = s.ChampagneTower(2, 1, 1);
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
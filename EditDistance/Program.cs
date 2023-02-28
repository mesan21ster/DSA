namespace EditDistance
{
    public class Solution
    {
        public int MinDistance(string word1, string word2)
        {
            if(word1 == null || word2 == null) return -1;
            if (word1.Length == 0) return word2.Length;
            if(word2.Length==0) return word1.Length;

            char[] c1 = word1.ToCharArray();
            char[] c2 = word2.ToCharArray();
            int[,] match = new int[c1.Length + 1, c2.Length + 1];

            for (int i = 0; i <= c1.Length; i++)
            {
                match[i, 0] = i;
            }

            for (int j = 0; j <= c2.Length; j++)
            {
                match[0,j] = j;
            }

            for (int i = 0; i < c1.Length; i++)
            {
                for (int j = 0; j < c2.Length; j++)
                {
                    if (c1[i] == c2[j])
                    {
                        match[i + 1, j + 1] = match[i, j];
                    }
                    else
                    {
                        match[i + 1, j + 1] = Math.Min(Math.Min(match[i, j + 1], match[i + 1, j]), match[i, j]) + 1;
                    }
                }
            }
            return match[c1.Length,c2.Length];
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int res = solution.MinDistance("horse", "ros");
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}

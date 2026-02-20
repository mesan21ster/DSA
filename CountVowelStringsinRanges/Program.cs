namespace CountVowelStringsinRanges
{
    public class Solution
    {
        public int[] VowelStrings(string[] words, int[][] queries)
        {
            int q = queries.Length;
            int n = words.Length;

            List<int> res = new List<int>();

            int[] cums = new int[n];

            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                if (isVowel(words[i][0]) && isVowel(words[i][words[i].Length - 1]))
                {
                    sum++;
                }
                cums[i] = sum;
            }

            for (int i = 0; i < q; i++)
            {
                int l = queries[i][0];
                int r = queries[i][1];

                res.Add(cums[r] - (l>0? cums[l - 1]:0));
            }
            return res.ToArray();

        }

        private bool isVowel(char ch)
        {
            if (ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u')
            {
                return true;
            }
            return false;
        }
    }
    public class Program
    {
        public static void Main(string[] args) {

            string[] words = { "aba", "bcb", "ece", "aa", "e" };
            int[][] queries = [[0, 2], [1, 4], [1, 1]];

            Solution solution = new Solution();

            var res = solution.VowelStrings(words, queries);

            foreach (int i in res)
            {
                Console.WriteLine(i);
            }

        }
    }
}
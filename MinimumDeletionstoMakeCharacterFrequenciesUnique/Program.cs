namespace MinimumDeletionstoMakeCharacterFrequenciesUnique
{
    public class Solution
    {
        public int MinDeletions(string s)
        {
            int res = 0;
            int n = s.Length;
            int[] frequency = new int[26];
            HashSet<int> set = new HashSet<int>();
            Array.Fill(frequency, 0);
            foreach (char ch in s) {
                frequency[ch - 'a'] += 1;
            }

            for (int i = 0; i < 26; i++)
            {
                while (frequency[i] > 0 && set.Contains(frequency[i])) {

                    frequency[i]--;
                    res++;
                }
                set.Add(frequency[i]);
            }
            return res;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            string s = "aaabbbcc";
            var res = solution.MinDeletions(s);
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
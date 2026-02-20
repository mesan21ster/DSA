namespace FindAllAnagramsinaString
{
    public class Solution
    {
        public IList<int> FindAnagrams(string s, string p)
        {
            List<int> result = new List<int>();
            int n = s.Length;
            int k = p.Length;
            if(n < k) return result;
            int[] freq = new int[26];
            //step 1: build frequency array for p
            foreach(char c in p)
            {
                freq[c - 'a']++;
            }
            //step 2: sliding window over s
            int i = 0;
            int j = 0;
            while(j < n)
            {
                freq[s[j] - 'a']--;
                if(j -i + 1 == k)
                {
                    //check if all frequnecys are zero
                    if (allZero(freq))
                    {
                        result.Add(i);
                    }
                    freq[s[i] - 'a']++;
                    i++;
                }
                j++;
            }
            return result;
        }
        private bool allZero(int[] freq)
        {
            foreach(int count in freq)
            {
                if(count != 0) return false;
            }
            return true;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Solution solution = new Solution();
            string s = "cbaebabacd";
            string p = "abc";
            IList<int> result = solution.FindAnagrams(s, p);
            Console.WriteLine(string.Join(", ", result)); // Output: [0, 6]
        }
    }
}
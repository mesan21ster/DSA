public class Solution
{
    public IList<int> FindAnagrams(string s, string p)
    {
        List<int> result = new List<int>();
        int n = s.Length;
        int m = p.Length;
        if (n < m) return result;
        int[] freq = new int[26];
        
        // Step 1: Frequency of p
        foreach (char c in p)
        {
            freq[c - 'a']++;
        }
        // Step 2: Sliding window on s
        int i = 0;
        int j = 0;
        
        while (j < n)
        {
            freq[s[j] - 'a']--;
            if(j - i + 1 == m)
            {
                if(allZero(freq))
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
        foreach (int count in freq)
        {
            if (count != 0) return false;
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
        Console.WriteLine("Anagram starting indices: " + string.Join(", ", result));
    }
}
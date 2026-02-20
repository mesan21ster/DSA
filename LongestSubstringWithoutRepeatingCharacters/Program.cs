namespace LongestSubstringWithoutRepeatingCharacters
{
    //Problem: Find the length of the longest substring without repeating characters.
    public class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            // string s = "abcabcbb";
            Dictionary<char, int> map = new Dictionary<char, int>();
            int maxLength = 0;
            int start = 0;

            for (int end = 0; end < s.Length; end++)
            {
                if (map.ContainsKey(s[end]))
                {
                    // Move start pointer if character was seen inside current window
                    start = Math.Max(start, map[s[end]] + 1);
                }
                map[s[end]] = end;// Update last seen index
                maxLength = Math.Max(maxLength, end - start + 1);// Update max length
            }
            return maxLength;
        }
        public int LengthOfLongestSubstringMethod2(string s)
        {
            HashSet<char> map = new HashSet<char>();
            int maxLength = 0;
            int left = 0, right = 0;

            while (right < s.Length)
            {

                if (!map.Contains(s[right]))
                {
                    map.Add(s[right]);
                    right++;
                    maxLength = Math.Max(maxLength, map.Count);
                }
                else
                {
                    map.Remove(s[left]);
                    left++;
                }
            }

            return maxLength;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Solution solution = new Solution();
            string s = "abcbacbb";
            var res = solution.LengthOfLongestSubstringMethod2(s);
            Console.WriteLine(res);
        }
    }
}

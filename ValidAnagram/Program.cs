namespace ValidAnagram
{
    public class Solution
    {
        public bool IsAnagram(string s, string t)
        {
            if(s.Length != t.Length) return false;
            #region Method 1 sort and compare
            //string sordered = new string(s.OrderBy(c => c).ToArray());
            //string tordered = new string(t.OrderBy(c => c).ToArray());
            //if (sordered != tordered) return false;
            //return true;
            #endregion

            #region Method 2 using frequency map
            int[] freq = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                freq[s[i] - 'a']++;
                freq[t[i] - 'a']--;
            }
            foreach (int count in freq)
            {
                if(count != 0) return false;
            }
            return true;
            #endregion
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Solution obj = new Solution();
            string s = "anagram";
            string t = "nagaram";
            var res = obj.IsAnagram(s, t);
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
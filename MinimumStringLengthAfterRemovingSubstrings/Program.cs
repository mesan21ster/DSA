namespace MinimumStringLengthAfterRemovingSubstrings
{
    public class Solution
    {
        public int MinLength(string s)
        {
            Stack<char> st = new Stack<char>();
            st.Push(s[0]);

            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == 'B' && st.Count > 0 && st.Peek() == 'A')
                {
                    st.Pop();
                    continue;
                }
                if (s[i] == 'D' && st.Count > 0 && st.Peek() == 'C')
                {
                    st.Pop();
                    continue;
                }

                st.Push(s[i]);
            }

            return st.Count;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            string s = "CCDDLLDW";

            var res = solution.MinLength(s);
            Console.WriteLine(res);

            Console.ReadLine();
        }
    }
}
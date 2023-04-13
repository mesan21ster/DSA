namespace ValidateStackSequences
{
    //946. Validate Stack Sequences
    //Time O(N)
    //Space O(N)
    //https://leetcode.com/problems/validate-stack-sequences/description/
    public class Solution
    {
        public bool ValidateStackSequences(int[] pushed, int[] popped)
        {
            Stack<int> st = new Stack<int>();
            int m = pushed.Length;
            int i = 0, j = 0;

            while (i < m && j < m)
            {
                st.Push(pushed[i]);
                while (st.Count > 0 && j < m && st.Peek() == pushed[j])
                {
                    st.Pop();
                    j++;
                }
                i++;
            }
            return st.Count == 0;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] pushed = { 1, 2, 3, 4, 5 };
            int[] popped = { 4, 5, 3, 2, 1 };
            var res = solution.ValidateStackSequences(pushed, popped);
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
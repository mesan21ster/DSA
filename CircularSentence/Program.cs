namespace CircularSentence
{
    public class Solution
    {
        public bool IsCircularSentence(string sentence)
        {
           int n = sentence.Length;

            if (sentence[0] != sentence[n - 1])
            {
                return false;
            }

            for (int i = 1; i < n; i++) {
                if (sentence[i] == ' ') { 
                if(sentence[i - 1] != sentence[i + 1])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            string sentence = "eetcode";
            Solution solution = new Solution();
            var res = solution.IsCircularSentence(sentence);
            Console.WriteLine(res);
        }
    }
}
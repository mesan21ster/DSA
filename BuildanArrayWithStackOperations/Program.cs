namespace BuildanArrayWithStackOperations
{
    public class Solution
    {
        public IList<string> BuildArray(int[] target, int n)
        {
            List<string> res = new List<string>();
   
            int index = 0;
            int stream = 1;
            while(index<target.Length && stream <= n)
            {
                if (stream == target[index])
                {
                    res.Add("Push");
                    index++;
                }
                else
                {
                    res.Add("Push");
                    res.Add("Pop");
                }
                stream++;
            }

            return res;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] target = { 1, 3 };
            int n = 3;
            var res = solution.BuildArray(target, n);
            Console.ReadLine();
        }
    }
}
namespace LargestNumber_179
{
    public class Solution
    {
        public string LargestNumber(int[] nums)
        {
            List<string> list = new List<string>();
            foreach (int num in nums)
            {
                list.Add(num.ToString());
            }

            string[] stringList = list.ToArray();
            Array.Sort(stringList, new StringComparer());

            var res = string.Join("", stringList);

            if(Convert.ToInt32(res) == 0)
            {
                return "0";
            }
            return res;
        }
    }

    public class StringComparer : IComparer<string>
    {
        public int Compare(string? x, string? y)
        {
            string firstOrder = x + y;
            string secondOrder = y + x;

            var res = secondOrder.CompareTo(firstOrder);
            return res;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();

            int[] input = { 3, 30, 34, 5, 9 };

            var res = s.LargestNumber(input);
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
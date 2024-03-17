namespace ConvertanArrayIntoa2DArrayWithConditions
{
    public class Solution
    {
        public IList<IList<int>> FindMatrix(int[] nums)
        {
            List<IList<int>> result = new()
        {
            new List<int>()
        };
            int[] frequency = new int[nums.Length + 1];
            int maxFrequency = 0;

            foreach (int num in nums)
            {
                int currentFrequency = frequency[num]++;

                if (currentFrequency > maxFrequency)
                {
                    maxFrequency = currentFrequency;
                    result.Add(new List<int> { num });
                }
                else
                {
                    result[currentFrequency].Add(num);
                }
            }

            return result;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();

            int[] nums = { 6, 4, 6, 4, 3, 3, 6, 2 };
            var res = solution.FindMatrix(nums);
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
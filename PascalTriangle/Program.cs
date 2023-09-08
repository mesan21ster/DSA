namespace PascalTriangle
{
    public class Solution
    {
        public IList<IList<int>> Generate(int numRows)
        {
            List<IList<int>> results = new List<IList<int>>();

            if (numRows == 0) return results;

            results.Add(new List<int>(1) { 1 });

            if (numRows == 1) return results;

            results.Add(new List<int>(2) { 1, 1 });

            if (numRows == 2) return results;

            for (int i = 2; i < numRows; i++)
            {
                IList<int> result = new List<int>
                {
                    1
                };

                for (int j = 1; j < i; j++)
                {
                    var calculate = results[i - 1][j] + results[i - 1][j - 1];
                    result.Add(calculate);
                }
                result.Add(1);
                results.Add(result);
            }
            return results;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            var res = solution.Generate(10);
            foreach (var item in res)
            {
                foreach (var item2 in item)
                {
                    Console.Write(item2 + " ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
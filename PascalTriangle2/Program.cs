namespace PascalTriangle2
{
    public class Solution
    {
        public IList<int> GetRow(int rowIndex)
        {
            List<IList<int>> results = new List<IList<int>>();
            results.Add(new List<int>(1) { 1 });

            for (int i = 1; i <= 34; i++)
            {
                IList<int> row = new List<int>();
                row.Add(1);
                for (int j = 1; j < i; j++)
                {
                    var calculate = results[i - 1][j] + results[i - 1][j - 1];
                    row.Add(calculate);
                }
                row.Add(1);
                results.Add(row);
            }
            return results[rowIndex];
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            var res = solution.GetRow(3);
            foreach (var item in res)
            {

                Console.Write(item + " ");

            }
            Console.ReadLine();
        }
    }
}
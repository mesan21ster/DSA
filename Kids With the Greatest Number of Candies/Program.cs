namespace KidsWiththeGreatestNumberofCandies
{
    //Time O(N)
    //Space O(N)
    public class Solution
    {
        public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
        {
            List<bool> res = new List<bool>();
            int m = candies.Length;
            int max = candies.Max();

            for (int i = 0; i < m; i++)
            {
                res.Add(false);
            }

            for (int i = 0; i < m; i++)
            {
                if (candies[i] + extraCandies >= max)
                {
                    res[i] = true;
                }
            }
            return res;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] candies = { 2, 3, 5, 1, 3 };
            int extraCandies = 3;
            var res = solution.KidsWithCandies(candies, extraCandies);
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
            
            Console.ReadLine();
        }
    }
}
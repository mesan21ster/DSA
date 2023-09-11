namespace GroupthePeopleGiventheGroupSizeTheyBelongTo
{
    public class Solution
    {
        public IList<IList<int>> GroupThePeople(int[] groupSizes)
        {
            Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
            int n = groupSizes.Length;
            List<IList<int>> res = new List<IList<int>>();
            for (int i = 0; i < n; i++)
            {
                var size = groupSizes[i];
                if (!map.ContainsKey(size))
                {
                    map[size] = new List<int>();
                }
                map[size].Add(i);
                if (map[size].Count == size)
                {
                    res.Add(map[size]);
                    map.Remove(size);
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
            int[] groupSizes = { 3, 3, 3, 3, 3, 1, 3 };
           
            var res = solution.GroupThePeople(groupSizes);
            foreach (var size in res)
            {
                foreach (var item in size) {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
           
            Console.ReadLine();
        }
    }
}
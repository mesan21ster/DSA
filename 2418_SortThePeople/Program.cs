namespace SortthePeople
{
    public class Solution
    {

        //time O(nlogn)
        //space O(n)
        public string[] SortPeople(string[] names, int[] heights)
        {

            #region WorkingCode with array.sort
            Array.Sort(heights, names);
            Array.Reverse(names);
            return names;
            #endregion


        }
    }

    static class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();

            string[] names = { "Mary", "John", "Emma" };
            int[] heights = { 180, 165, 170 };

            var res = s.SortPeople(names, heights);

            foreach (string name in res)
            {
                Console.WriteLine(name);
            }
            Console.ReadLine();
        }
    }
}
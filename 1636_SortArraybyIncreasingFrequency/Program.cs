using System.Collections.Specialized;

namespace SortArraybyIncreasingFrequency
{
    //Given an array of integers nums, sort the array in increasing order based on the frequency of the values. If multiple values have the same frequency, sort them in decreasing order.
    public class Solution
    {
        //Expected output : 3,1,1,2,2,2
        public int[] FrequencySort(int[] nums)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                if (!map.ContainsKey(num))
                {
                    map.Add(num,0);
                }
                map[num]++;
            }

            List<int> result = new List<int>();

            var lst  = map.OrderBy(x => x.Value).ThenByDescending(x => x.Key).ToList();

            foreach (KeyValuePair<int,int> num in lst) {
                int count = num.Value;

                for (int i = 0; i < count; i++) { 
                    result.Add(num.Key);
                }
            }
            return result.ToArray();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 1, 2, 2, 2, 3 };

            Solution obj = new Solution();

            var res = obj.FrequencySort(nums);

            foreach (int i in nums)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }
    }
}
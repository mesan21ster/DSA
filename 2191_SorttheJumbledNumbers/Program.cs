using System.Text;

namespace SorttheJumbledNumbers
{
    //2192 - Sort the Jumbled number

    /*
     Input: mapping = [8,9,4,0,2,1,3,5,7,6], nums = [991,338,38]
     Output: [338,38,991]
     */
    public class Solution
    {
        public int[] SortJumbled(int[] mapping, int[] nums)
        {
            //Dictionary<int, int> map = new Dictionary<int, int>();
            //List<int> list = new List<int>();
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    string num = nums[i].ToString();

            //    for (int j = 0; j < num.Length; j++)
            //    {
            //        int n = num[j] -'0';
            //        if (!map.ContainsKey(nums[i]))
            //        {

            //            map.Add(nums[i], mapping[n]);
            //        }
            //        else
            //        {
            //            int getOldVal = map[nums[i]];
            //            string newValStr = getOldVal.ToString() + mapping[n].ToString();
            //            map[nums[i]] = Convert.ToInt32(newValStr);
            //        }
            //    }
            //}
            //map = map.OrderBy(x=>x.Value).ToDictionary<int,int>();

            //foreach (int i in map.Keys)
            //{
            //    list.Add(i);
            //}

            //return list.ToArray();

            string number = "";
            int sum = 0,
            arrayIncrement = 0,
            key = 0;

            Dictionary<int, int> mapval = new Dictionary<int, int>();

            int[] array = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                number = nums[i].ToString();
                foreach (var k in number)
                {
                    sum = sum * 10 + mapping[(int)k - (int)'0'];
                }

                mapval.Add(key, sum);
                sum = 0;
                key++;
            }

            mapval = mapval.OrderBy(x => x.Value).ToDictionary<int, int>();

            foreach (KeyValuePair<int, int> i in mapval)
            {
                array[arrayIncrement] = nums[i.Key];
                arrayIncrement++;
            }

            return array;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] mapping = { 8, 2, 9, 5, 3, 7, 1, 0, 6, 4 };
            int[] nums = { 418, 4191, 916, 948, 629641556, 574, 111171937, 28250, 42775632, 6086, 85796326, 696292542, 186, 67559, 2167, 366, 854, 2441, 78176, 621, 4257, 2250097, 509847, 7506, 77, 50, 4135258, 4036, 59934, 59474, 3646243, 9049356, 85852, 90298188, 2448206, 30401413, 33190382, 968234660, 7973, 668786, 992777977, 77, 355766, 221, 246409664, 216290476, 45, 87, 836414, 40952 };
            Solution solution = new Solution();
            var res = solution.SortJumbled(mapping, nums);

            foreach (int i in res)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }
    }
}
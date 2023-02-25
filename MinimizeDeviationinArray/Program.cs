
namespace MinimizeDeviationinArray
{
    /*
     Solution
    Double odd numbers and put all numbers into a SortedSet. Track the smallest number. 
    Track the minimum difference between the top of the SortedSet  and the smallest number. 
    While the top of the SortedSet  is even, remove it, divide, and put back to the SortedSet .

    Time complexity: O(NlogM * logN) where N is the length of nums and M is the maximum number.
Inserting a number to the SortedSet has O(logN) time complexity. Since there are N numbers, time complexity of the 1st part is O(NlogN).
For the 2nd part, in the worst case M is the power of 2, so max can be decreased logM times. Since there are N numbers, so we could decrease all the possible max NlogM times. For each max, SortedSet.Add() takes O(logN) to insert it, so the total time complexity of the 2nd part is O(NlogMlogN).
Since O(NlogM * logN) > O(NlogN), the time complexity of this implementation is dominated by the 2nd part, which is O(NlogM * logN).

     */
    public class Solution
    {
        public int MinimumDeviation(int[] nums)
        {
            var set=new SortedSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] % 2 == 0)
                {
                    set.Add(nums[i]);//already maximum value
                }
                else
                {
                    set.Add(nums[i] *2);//maximum value of odd
                }
            }
            var min = set.Max - set.Min;//initial deviation

            //step 2: while the maximum value is divisiable by 2, divide and repeat with the resulting maximum value.
            while(set.Max %2 == 0)
            {
                var max = set.Max;
                set.Remove(max);
                set.Add(max/2);
                min = Math.Min(min, set.Max - set.Min);//find minimum deviation
            }
            return min;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
           
            Solution solution = new Solution();
            //var maxCap = solution.FindMaximizedCapital(k, w, profits, capital);
            var minimum = solution.MinimumDeviation(new int[] { 1, 2, 3, 4 });
            //var minimum2 = solution.MinimumDeviation(new int[] { 4, 1, 5, 20, 3 });
            Console.WriteLine(minimum);
            Console.ReadLine();
        }
    }
}
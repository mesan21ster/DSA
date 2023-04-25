using System;

namespace SmallestNumberinInfiniteSet
{
    /*
     * This is approach 1
     Time O(N)
     Space O(N)
     */
    //public class SmallestInfiniteSet
    //{

    //    bool[] nums = new bool[1001];//by default all elements are false in c#
    //    int i = 0;

    //    public SmallestInfiniteSet()
    //    {
    //        i = 1; // initilize i, this is the smallest value
    //    }

    //    public int PopSmallest()
    //    {
    //        int result = i;
    //        nums[i] = true;//mark true if you pop
    //        for (int j = i + 1; j < 1001; j++)
    //        { // loop till the next item that is false to point i over that 
    //            if (nums[j] == false)
    //            {
    //                i = j;
    //                break;
    //            }
    //        }
    //        return result;//this will be always smallest because i is pointing to smallest
    //    }

    //    public void AddBack(int num)
    //    {
    //        nums[num] = false;//while add mark false 
    //        if (num < i)
    //        { // check added number is less than switch i to that number
    //            i = num;
    //        }
    //    }
    //}


    //This is approach 2
    //Time O(1)
    //Space O(N)
    public class SmallestInfiniteSet
    {
        SortedSet<int> set;
        public SmallestInfiniteSet()
        {
            int[] n = Enumerable.Range(1, 1000).ToArray();
            set = new SortedSet<int>(n);

        }

        public int PopSmallest()
        {
            int num = set.First();
            set.Remove(num);
            return num;
        }

        public void AddBack(int num)
        {
            set.Add(num);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            SmallestInfiniteSet obj= new SmallestInfiniteSet();
            int param_1 = obj.PopSmallest();
            Console.WriteLine(param_1);
            //obj.AddBack(2);
            Console.ReadLine();
        }
    }
}
namespace BoatstoSavePeople
{
    public class Solution
    {
        //Time O(NlongN)
        //Wrose case time would be O(N)
        //Space O(LogN) for sorting
        public int NumRescueBoats(int[] people, int limit)
        {
            //Sort people array 
            Array.Sort(people);

            //Compare sum of low + high and check if within limit

            int i = 0;
            int j = people.Length - 1;
            int req = 0;
            while(i<= j)
            {
                if (people[i] + people[j]<= limit)
                {
                    req++;// in limit so pair and increase i pointer and decrease j pointer
                    i++; 
                    j--;
                }
                else
                {
                    req++;
                    j--; // if not in limit so we need extra boat 
                }
            }
            return req;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();

            int[] people = { 3, 5, 3, 4 };
            int limit = 5;
            var res = s.NumRescueBoats(people, limit);
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
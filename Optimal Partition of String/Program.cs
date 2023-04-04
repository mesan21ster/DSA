namespace OptimalPartitionofString
{
    public class Solution
    {
        //time O(N)
        //space O(1)
        public int PartitionString(string s)
        {
            int[] lastseen = new int[26];// space = O(1) fixed with size 26 char
            for (int i = 0; i < lastseen.Length; i++)
            {
                lastseen[i] = -1;// initialize with -1
            }

            int count = 0;
            int currSubStringStartIndex = 0;// this veriable is to check if repeated char is a part of current substring 

            for (int i = 0; i < s.Length; i++)
            {
                char ch = s[i];
                if (lastseen[ch -'a'] >= currSubStringStartIndex)//if lastseen char is greate or equal to current substring start index it means we have to break and set current substring start index = i
                {
                    count++;
                    currSubStringStartIndex = i;
                }
                lastseen[ch - 'a'] = i;// for each iteration of loop keep adding char index in lastseen array to keep track of chars
            }
            return count + 1;// +1 means to add last substring, because after coming out of loop, there would be one substring pending to add in count
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution sol = new Solution();
            string s = "ssssss";
            var res = sol.PartitionString(s);
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
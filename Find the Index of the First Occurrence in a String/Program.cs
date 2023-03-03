namespace FindtheIndexoftheFirstOccurrenceinaString
{
    public class Solution
    {
        public int StrStr(string haystack, string needle)
        {
            //if (haystack.Contains(needle))
            //{
            //    return haystack.IndexOf(needle); //this will also work
            //}


            int hayLength = haystack.Length;
            int needleLength = needle.Length;
            int index = 0;
            if (hayLength < needleLength) return -1;

            for (int i = 0; i < hayLength; i++)
            {
                // as long as the characters are equal, increment needleIndex
                if (haystack[i] == needle[index])
                {
                    index++;
                }
                else
                {
                    // start from the next index of previous start index
                    i = i - index;
                    // needle should start from index 0
                    index = 0;
                }
                // check if Index reached needle length
                if(index == needleLength)
                {
                    //return the first index;
                    return i - index + 1;
                }
            }
            return -1;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            string haystack = "sadbutsad";
            string needle = "sad";
            Console.WriteLine(solution.StrStr(haystack, needle));
            Console.ReadLine();
        }
    }
}
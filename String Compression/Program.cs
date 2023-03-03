namespace StringCompression
{
    public class Solution
    {
        public int Compress(char[] chars)
        {

            /*
             
             string s="";
        char prev= chars[0]; //first char
        int prevFrequency = 1; //count will be 1 for first char
        int indx=0;
        for(int i=1;i<chars.Length;i++){//loop to array
            if(chars[i] == prev){ // if match , increase count
                prevFrequency++;
            }
            else{ // create string 
                s+=prev;
                if(prevFrequency>1){ // append count in string
                    s+= Convert.ToString(prevFrequency);
                }
                prev = chars[i]; // assign new char to prev 
                prevFrequency = 1;// set count 1
            }
        }
        s+=prev; // this is for last char
        if(prevFrequency > 1){
            s+= Convert.ToString(prevFrequency);
        }
        chars = new char[s.ToCharArray().Length]; // assign array with new length
        foreach(var item in s.ToCharArray()){
            chars[indx++] = item;
        }
        return chars.Length; 

             */

            int res = 0,
                        cnt = 0;
            char cur = chars[0];

            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == cur)
                {
                    cnt++;
                }
                else
                {
                    chars[res++] = cur;

                    if (cnt > 1)
                    {
                        foreach (var d in cnt.ToString())
                        {
                            chars[res++] = d;
                        }
                    }

                    cur = chars[i];
                    cnt = 1;
                }
            }

            chars[res++] = cur;

            if (cnt > 1)
            {
                foreach (var d in cnt.ToString())
                {
                    chars[res++] = d;
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
            char[] chars = { 'a', 'a', 'b', 'b', 'c', 'c', 'c' };
            Console.WriteLine(solution.Compress(chars));
            Console.ReadLine();
        }
    }
}
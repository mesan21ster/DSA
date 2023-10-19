namespace BackspaceStringCompare
{
    public class Solution
    {
        public bool BackspaceCompare(string s, string t)
        {
            string temp1 = "";
            string temp2 = "";

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '#')
                {
                    if (temp1.Length > 0)
                    {
                        temp1 = temp1.Substring(0, temp1.Length - 1);
                    }
                }
                else
                {
                    temp1 += s[i];
                }
            }


            for (int i = 0; i < t.Length; i++)
            {
                if (t[i] == '#')
                {
                    if (temp2.Length > 0)
                    {
                        temp2 = temp2.Substring(0, temp2.Length - 1);
                    }
                }
                else
                {
                    temp2 += t[i];
                }
            }

            return string.Equals(temp1, temp2);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            var res = solution.BackspaceCompare("xywrrmp", "xywrrmu#p");
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
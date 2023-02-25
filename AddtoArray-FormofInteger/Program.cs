using System;
using System.Collections.Generic;
using System.Numerics;

namespace AddtoArray_FormofInteger
{
    internal class Program
    {
        public IList<int> AddToArrayForm(int[] num, int k)
        {
            List<int> result = new List<int>();
            //string s = "";
            //foreach (var item in num)
            //{
            //    s = s + item;
            //}
            //long firstnum = Convert.ToInt64(s);
            //long total = firstnum + k;

            //char[] charArr= total.ToString().ToCharArray();


            //foreach (var item in charArr)
            //{
            //    result.Add((int)Char.GetNumericValue(item));
            //}
            int n = num.Length;
          
            for (int i = n-1; i >=0 || k>0; i--)
            {
                if (i >= 0)
                {
                    result.Add((num[i] + k) % 10);
                    k = (num[i] + k) / 10;
                }
                else
                {
                    result.Add(k % 10);
                    k=k/10;
                }
            }
            result.Reverse();
            return result;
        }
        static void Main(string[] args)
        {
            int[] num = { 2, 1, 5 };
            Program p = new Program();
            var output =  p.AddToArrayForm(num, 806);
            Console.WriteLine("Hello World!");
        }
    }
}

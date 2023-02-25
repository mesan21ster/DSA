using System;

namespace Karat_pair_of_2sAnd3s
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //examples: pair of 2s and 3s but only 2s not allow and atleast one 3s should be there, one or more pairs of 2s and 3s are allowed
            //11 - false
            //1122222 - true
            //222333444 - true
            //556655 - false
            //8 - false
            //0001100221113340556007466677 - true
            //444 - true
            //550221100 - true
            //00000000 - true 

       
            string filecontents = "a\nf";
            string[] rows = filecontents.Split(Environment.NewLine.ToCharArray());
            if (rows.Length > 1)
            {
                Console.WriteLine("Hello World!");
            }
            Console.ReadLine();
        }
        
    }
}

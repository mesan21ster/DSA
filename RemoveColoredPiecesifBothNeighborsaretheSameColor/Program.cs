namespace RemoveColoredPiecesifBothNeighborsaretheSameColor
{
    public class Solution
    {
        public bool WinnerOfGame(string colors)
        {
            int n = colors.Length;
            int alice = 0;
            int bob = 0;
            for (int i = 1; i < n - 1; i++)
            {
                if (colors[i - 1] == colors[i] && colors[i] == colors[i + 1])
                {
                    if (colors[i] == 'A')
                    {
                        alice++;
                    }
                    else
                    {
                        bob++;
                    }
                }
            }
            return alice> bob;
        }
    }
    internal class Program
    {
        public static void Main(string[] args)
        {
            Solution sol = new Solution();
            string colors = "ABBBBBBBAAA";
            var res = sol.WinnerOfGame(colors);
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
namespace MinimumNumberofArrowstoBurstBalloons
{ 
    //TC O(nlogn)
    public class Solution
    {
        public int FindMinArrowShots(int[][] points)
        {
            Array.Sort(points,(a,b)=> a[1].CompareTo(b[1]));
            
            int count = 1;

            int prev = points[0][1];

            for(int i=1;i<points.Length; i++)
            {
                if (points[i][0] > prev) // if start point of current is greater than prev's end
                {
                    count++;
                    prev = points[i][1];
                }
            }
            return count;
        }
    }
    static class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();

            int[][] points= [
                [10,16],[2,8],[1,6],[7,12]
            ];

            var res = s.FindMinArrowShots(points);
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
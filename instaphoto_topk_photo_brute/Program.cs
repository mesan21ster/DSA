namespace instaphoto_topk_maxLikePhotos_brute
{
    public class Solution
    {
        //photos = [p1, p2, p3, p4, p5, p6]
        //likes  = [100, 50, 90, 80, 95, 60]
        public string[] getTopKMostLikePhotos(string[] photos, int[] likes, int k)
        {
            List<(string photo, int like)> grouped = new List<(string, int)>();

            for (int i = 0; i < photos.Length; i++)
            {
                grouped.Add((photos[i], likes[i]));
            }

            grouped.Sort((a, b) => b.like.CompareTo(a.like));

            List<string> res = new List<string>();
            for(int i =0; i< k; i++)
            {
                res.Add(grouped[i].photo);
            }
            return res.ToArray();
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Solution solution = new Solution();
            string[] photos = { "p1", "p2", "p3", "p4", "p5", "p6" };
            int[] likes = { 100, 50, 90, 80, 95, 60 };
            int k = 3;

            var res = solution.getTopKMostLikePhotos(photos, likes, k);

            foreach(var item in res)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}
namespace instaphoto_topk_maxLikePhotos_MinHeap_Optimal
{
    //Time: O(n log k) where n is the number of photos and k is the number of top photos we want to return. We iterate through all the photos once, which takes O(n) time. For each photo, we perform an enqueue operation on the min-heap, which takes O(log k) time. Since we maintain a heap of size at most k, the overall time complexity is O(n log k).
    //Space: O(k) for the min-heap, which stores at most k photos. The space complexity is O(k) because we only keep the top k photos in the heap at any given time.
    public class Solution
    {
        //photos = [p1, p2, p3, p4, p5, p6]
        //likes  = [100, 50, 90, 80, 95, 60]
        public string[] getTopKMostLikePhotos(string[] photos, int[] likes, int k)
        {
            PriorityQueue<(string photo, int like), int> minheap = new PriorityQueue<(string photo, int like), int>();

            for(int i =0; i< photos.Length; i++)
            {
                minheap.Enqueue((photos[i], likes[i]), likes[i]);

                if(minheap.Count > k)
                {
                    minheap.Dequeue();
                }
            }

            List<string> res = new List<string>();

            while(minheap.Count > 0)
            {
                res.Add(minheap.Dequeue().photo);
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
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}
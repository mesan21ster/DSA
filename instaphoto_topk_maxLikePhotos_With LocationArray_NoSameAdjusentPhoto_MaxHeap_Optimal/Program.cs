namespace topk_maxLikePhotos_With_Location_NoSameAdjusentPhoto_MaxHeap
{
    //time: O(n log n) it is Building full heap
    //space: O(n)
    public class Solution
    {
        public string[] getTopKMostLikePhotos(string[] photos, int[] likes, string[] locations, int k)
        {
            PriorityQueue<(string photo, string location, int like), int> maxheap = 
                new PriorityQueue<(string photo, string location,int like), int>();

            for (int i = 0; i < photos.Length; i++)
            {
                maxheap.Enqueue((photos[i], locations[i], likes[i]), -likes[i]);
            }
            List<string> res = new List<string>();
            string prevLoc = string.Empty;
            while (maxheap.Count > 0 && res.Count < k)
            {
                var skipped = new List<((string photo, string loc,int like), int priority)>();
                bool found = false;
                //try to find the valid photo

                while (maxheap.Count > 0)
                {
                    var item = maxheap.Dequeue();
                    int prio = -item.like; // keep maintaing the priority otherwise we will loose best max like photo if skipped
                    string currLoc = item.location;
                    if (currLoc != prevLoc)
                    {
                        //select the valid photo
                        res.Add(item.photo);
                        prevLoc = currLoc;
                        found = true;
                        break;
                    }
                    else
                    {
                        //skip temporarly because location is same, we can reuse this later when push back
                        skipped.Add((item, prio));
                    }
                }
                
                //push back skipped items , so that we do not miss any valid photo
                foreach (var s in skipped)
                {
                    maxheap.Enqueue(s.Item1, -s.Item1.like);
                }
                // If no valid photo → break
                if (!found)
                {
                    break;
                }
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
            string[] locations = { "l1", "l2", "l2", "l3", "l1", "l4" };
            int k = 4;
            var res = solution.getTopKMostLikePhotos(photos, likes, locations, k);
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}
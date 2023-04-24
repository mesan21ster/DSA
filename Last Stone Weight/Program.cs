namespace LastStoneWeight
{
    public class Solution
    {
        //Time O(NlogN)
        //Space O(N)
        public int LastStoneWeight(int[] stones)
        {
            PriorityQueue<int, int> queue = new PriorityQueue<int, int>();
            foreach (int stone in stones)
            {
                queue.Enqueue(stone, -stone);// add to queue
            }

            while (queue.Count > 1)// loop till at most there are 2 items in queue
            {
                int firstStone = queue.Dequeue();// take top as first stone
                int secondStone = queue.Dequeue();//take top as second stone
                if (firstStone != secondStone)// as per question if both not equal
                {
                    int newStone = Math.Abs(firstStone - secondStone);// smash and take abslaute value as new stone 
                    queue.Enqueue(newStone, -newStone);// add newStone to queue
                }
            }
            if(queue.Count == 0)
            {
                return 0;// return zero if no items left in queue
            }
            return queue.Dequeue();// return last item from queue
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] stones = { 2, 7, 4, 1, 8, 1 };
            var res = solution.LastStoneWeight(stones);
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
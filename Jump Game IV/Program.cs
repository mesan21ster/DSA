using System.Text.RegularExpressions;

namespace JumpGameIV
{
    /*
     he problem requires us to find the minimum number of steps needed to reach the last index of a given array of integers. Each step can be one of the following:

Move one step forward to the next index (i+1) if it exists.
Move one step backward to the previous index (i-1) if it exists.
Move to any index j where the element at index i is equal to the element at index j (i.e., arr[i] == arr[j]).
Below diagram is based on above 3 conditions

    Approach for this Problem:
Create an unordered_map called indices to store the indices of each value in the input array.
For each value in the input array, add its index to the corresponding vector in the indices map.
Create a queue called storeIndex to store the indices of adjacent elements and a vector called visited to mark visited indices.
Push the first index of the array to the storeIndex queue and mark it as visited in the visited vector.
Initialize a steps variable to 0.
While the storeIndex queue is not empty, do the following:
a. Get the size of the storeIndex queue.
b. For each index in the storeIndex queue, do the following:
i. If the index is the last index of the array, return the number of steps.
ii. Get the vector of indices for the current value from the indices map.
iii. Add the indices of the adjacent elements to the vector.
iv. For each index in the vector, if it is within the array bounds and has not been visited, push it to the storeIndex queue and mark it as visited in the visited vector.
v. Clear the vector of indices.
c. Increment the steps variable.
If the last index of the array is not reached, return -1.
     */
    public class Solution
    {
        public int MinJumps(int[] arr)
        {
            if(arr == null || arr.Length <= 1)
                return 0;

            Dictionary<int,List<int>> map = new Dictionary<int,List<int>>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (!map.ContainsKey(arr[i]))
                {
                    map.Add(arr[i], new List<int>() { i });
                }
                else
                {
                    map[arr[i]].Add(i);
                }
            }

            bool[] visited = new bool[arr.Length];
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0);//enqueue index 0
            visited[0] = true;//marked visited 0th index true
            int res = 0;

            while(queue.Count > 0)
            {
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    int curr = queue.Dequeue();
                    if (curr == arr.Length - 1) return res;

                    int left = curr - 1;
                    int right = curr + 1;
                    if(left >= 0 && !visited[left])// we can go left
                    {
                        queue.Enqueue(left);
                        visited[left] = true;
                    }
                    if(right < arr.Length && !visited[right])//we can go right
                    {
                        queue.Enqueue(right);
                        visited[right] = true;
                    }

                    foreach (var next in map[arr[curr]])// jump to matched element
                    {
                        if (!visited[next])
                        {
                            queue.Enqueue(next);
                            visited[next] = true;
                        }
                    }
                    map[arr[curr]].Clear();//once all the cells with the current value are visisted, no need to check again 
                }
                res++;
            }
            return -1;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] arr = { 100, -23, -23, 404, 100, 23, 23, 23, 3, 404 };
            Console.WriteLine(solution.MinJumps(arr));
            Console.ReadLine();
        }
    }
}
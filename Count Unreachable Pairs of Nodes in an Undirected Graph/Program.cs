namespace CountUnreachablePairsofNodesinanUndirectedGraph
{
    public class Solution
    {
        //time O(V+E)
        //space O(V+E)
        public long CountPairs(int n, int[][] edges)
        {
            var visited = new HashSet<int>();
            Dictionary<int, List<int>> adj = new();//create graph
            for (int i = 0; i < n; i++)
            {
                adj.Add(i, new());
            }
            foreach (var edge in edges)
            {
                adj[edge[0]].Add(edge[1]); //bidirectional
                adj[edge[1]].Add(edge[0]);//bidirectional
            }

            

            long remainingNodes = n; // initially n is the remaining node
            long result = 0;
            for (int i = 0; i < n; i++) // loop till the n 
            {
                if (!visited.Contains(i)) // if not visited node
                {
                    long size = 0;
                    DFS(i, adj, visited, ref size); // call dfs with ref size 
                    //BFS(i, adj, visited, ref size); // call BFS with ref size 
                    result += (size) * (remainingNodes - size); // result will be calculated 
                    remainingNodes -= size; // less size otherwise it will be duplicate in next itiratioon 
                }
            }
            return result; // return result;
        }
        private void DFS(int u, Dictionary<int, List<int>> adj, HashSet<int> visited, ref long size)
        {
            visited.Add(u); // add unvisited node
            size++; // everytime increase size;

            foreach (var v in adj[u]) // get all the edges from graph
            {
                if (!visited.Contains(v))
                {
                    DFS(v, adj, visited, ref size); // call recursivly
                }
            }
        }

        private void BFS(int u, Dictionary<int, List<int>> adj, HashSet<int> visited, ref long size) // BFS solution 
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(u);
            visited.Add(u); // add unvisited node
            size++; // everytime increase size;

            while (queue.Count > 0)
            {
                int x = queue.Dequeue();

                foreach (var v in adj[x]) // get all the edges from graph
                {
                    if (!visited.Contains(v))
                    {
                        visited.Add((int)v);
                        queue.Enqueue(v);
                        size++;
                    }
                }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            var connections = new int[3][];
            connections[0] = new int[] { 0, 1 };
            connections[1] = new int[] { 2, 3 };
            connections[2] = new int[] { 4, 5 };

            var count = s.CountPairs(6, connections);

            Console.WriteLine(count);
            Console.ReadLine();
        }
    }
}

namespace ShortestDistanceAfterRoadAdditionQueriesI
{
    /*
     You are given an integer n and a 2D integer array queries.

There are n cities numbered from 0 to n - 1. Initially, there is a unidirectional road from city i to city i + 1 for all 0 <= i < n - 1.

queries[i] = [ui, vi] represents the addition of a new unidirectional road from city ui to city vi. After each query, you need to find the length of the shortest path from city 0 to city n - 1.

Return an array answer where for each i in the range [0, queries.length - 1], answer[i] is the length of the shortest path from city 0 to city n - 1 after processing the first i + 1 queries.

 

Example 1:

Input: n = 5, queries = [[2,4],[0,2],[0,4]]

Output: [3,2,1]

    Example 2:

Input: n = 4, queries = [[0,3],[0,2]]

Output: [1,1]


    Time  = O(N+Q∗N)
     */
    public class Solution
    {
        public int[] ShortestDistanceAfterQueries(int n, int[][] queries)
        {
            // 0 to n-1
            //0->1->2->3
            Dictionary<int, List<int>> adj = new Dictionary<int, List<int>>();

            for (int i = 0; i <= n - 2; i++)
            {
                adj.Add(i, new List<int>());
            }

            //fill the adj

            for (int i = 0; i <= n - 2; i++)
            {
                adj[i].Add(i + 1);
            }

            int q = queries.Length;

            List<int> result = new List<int>();

            foreach (int[] query in queries)
            {
                int u = query[0];
                int v = query[1];

                adj[u].Add(v);
                int d = bfs(n, adj);

                result.Add(d);
            }

            return result.ToArray();
        }

        private int bfs(int n, Dictionary<int, List<int>> adj)
        {
            Queue<int> queue = new Queue<int>();

            int level = 0;

            queue.Enqueue(0);//source

            bool[] visited = new bool[n];
            Array.Fill(visited, false);

            visited[0] = true;

            while (queue.Count > 0)
            {
                int size = queue.Count;
                while (size > 0)
                {
                    int node = queue.Dequeue();
                    if (node == n - 1)
                    {
                        return level;
                    }

                    foreach (int nbr in adj[node])
                    {
                        if (!visited[nbr])
                        {
                            queue.Enqueue(nbr);
                            visited[nbr] = true;
                        }
                    }
                    size--;
                }
                level++;
            }
            return -1;
        }

        public class Program
        {
            public static void Main(string[] args)
            {
                Solution s = new Solution();
                int n = 5;
                int[][] queries =
                {
                    new int[] {2,4 },
                    new int[] {0,2 },
                    new int[] {0,4}
                };

                var res = s.ShortestDistanceAfterQueries(n, queries);

                for (int i = 0; i < res.Length; i++)
                {
                    Console.WriteLine(res[i]);
                }
            }
        }
    }
}
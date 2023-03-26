namespace LongestCycleinaGraph
{
    public class Solution
    {
        int result = -1;
        public int LongestCycle(int[] edges)
        {
            int n = edges.Length;
            List<bool> visited = new List<bool>();
            List<bool> inRecursion = new List<bool>();
            List<int> count = new List<int>();
            for (int i = 0; i < n; i++)
            {
                visited.Add(false);
                count.Add(1);
                inRecursion.Add(false);
            }

            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    dfs(i, edges, ref visited, ref count, ref inRecursion);
                }
            }
            return result;
        }

        private void dfs(int u, int[] edges, ref List<bool> visited, ref List<int> count, ref List<bool> inRecursion)
        {
            if(u != -1)
            {
                visited[u] = true;
                inRecursion[u] = true;
                int v= edges[u]; // get vertices from edges of current node

               if(v != -1 && !visited[v])
                {
                    count[v] = count[u] + 1;
                    dfs(v, edges, ref visited, ref count,ref inRecursion);
                }else if(v != -1 && inRecursion[v] == true)//cycle with inRecursion is also true
                {
                    result = Math.Max(result, count[u] - count[v] + 1); // count of last visited node - current node + 1
                }
            }
            inRecursion[u] = false; // if out of recursion thn mark false again
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int[] edges = { 2, -1, 3, 1 };

            var count = s.LongestCycle(edges);

            Console.WriteLine(count);
            Console.ReadLine();
        }
    }
}
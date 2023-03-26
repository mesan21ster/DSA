namespace ReorderRoutestoMakeAllPathsLeadtotheCityZero
{
    public class Solution
    {
        private Dictionary<int, List<(int, int)>> graph;
        public int MinReorder(int n, int[][] connections)
        {
            graph = new();
            var res = 0;
            var visited = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                graph.Add(i, new List<(int, int)>());
            }

            foreach (var i in connections)
            {
                graph[i[0]].Add((i[1], 1));
                graph[i[1]].Add((i[0], 0));
            }

            DFS(0, 0);

            return res;

            void DFS(int node, int dir)
            {
                if (visited.Contains(node)) return;

                visited.Add(node);

                if (dir == 1) res++;

                foreach (var i in graph[node])
                {
                    DFS(i.Item1, i.Item2);
                }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            var connections = new int[5][];
            connections[0] = new int[] { 0, 1 };
            connections[1] = new int[] { 1, 3 };
            connections[2] = new int[] { 2, 3 };
            connections[3] = new int[] { 4, 0 };
            connections[4] = new int[] { 4, 5 };

            var count = s.MinReorder(6, connections);

            Console.WriteLine(count);
            Console.ReadLine();
        }
    }
}
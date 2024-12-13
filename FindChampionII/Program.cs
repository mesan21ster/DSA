namespace FindChampionII
{
    /*
     There are n teams numbered from 0 to n - 1 in a tournament; each team is also a node in a DAG.

You are given the integer n and a 0-indexed 2D integer array edges of length m representing the DAG, where edges[i] = [ui, vi] indicates that there is a directed edge from team ui to team vi in the graph.

A directed edge from a to b in the graph means that team a is stronger than team b and team b is weaker than team a.

Team a will be the champion of the tournament if there is no team b that is stronger than team a.

Return the team that will be the champion of the tournament if there is a unique champion, otherwise, return -1.

Notes

A cycle is a series of nodes a1, a2, ..., an, an+1 such that node a1 is the same node as node an+1, the nodes a1, a2, ..., an are distinct, and there is a directed edge from the node ai to node ai+1 for every i in the range [1, n].
A DAG is a directed graph that does not have any cycle.

    Input: n = 3, edges = [[0,1],[1,2]]
Output: 0
Explanation: Team 1 is weaker than team 0. Team 2 is weaker than team 1. So the champion is team 0.

    Input: n = 4, edges = [[0,2],[1,3],[1,2]]
Output: -1
Explanation: Team 2 is weaker than team 0 and team 1. Team 3 is weaker than team 1. But team 1 and team 0 are not weaker than any other teams. So the answer is -1.

    TC = O(m+n)
    SC = O(n)
     */
    public class Solution
    {
        public int FindChampion(int n, int[][] edges)
        {
            int[] indegree = new int[n];
            Array.Fill(indegree, 0);

            foreach (int[] edge in edges)
            {
                int u = edge[0];
                int v = edge[1];

                //u-->v  DAG
                indegree[v]++;
            }

            int champ = -1;
            int count = 0;

            for (int i = 0; i < n; i++)
            {
                if (indegree[i] == 0)
                {
                    champ = i;
                    count++;
                    if (count > 1)
                    {
                        return -1;
                    }
                }
            }
            return champ;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Solution s = new Solution();
            int n = 4;
            int[][] edges = {
            new int[] { 0,2 },
            new int[] {1,3 },
            new int[] {1,2}
            };

            var res = s.FindChampion(n, edges);
            Console.WriteLine(res);
        }
    }
}
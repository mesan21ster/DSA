namespace CourseScheduleII
{
    //210. Course Schedule II

    /*
     There are a total of numCourses courses you have to take, labeled from 0 to numCourses - 1. You are given an array prerequisites where prerequisites[i] = [ai, bi] indicates that you must take course bi first if you want to take course ai.

For example, the pair [0, 1], indicates that to take course 0 you have to first take course 1.
Return the ordering of courses you should take to finish all courses. If there are many valid answers, return any of them. If it is impossible to finish all courses, return an empty array.

 

Example 1:

Input: numCourses = 2, prerequisites = [[1,0]]
Output: [0,1]
Explanation: There are a total of 2 courses to take. To take course 1 you should have finished course 0. So the correct course order is [0,1].
Example 2:

Input: numCourses = 4, prerequisites = [[1,0],[2,0],[3,1],[3,2]]
Output: [0,2,1,3]
Explanation: There are a total of 4 courses to take. To take course 3 you should have finished both courses 1 and 2. Both courses 1 and 2 should be taken after you finished course 0.
So one correct course order is [0,1,2,3]. Another correct ordering is [0,2,1,3].
Example 3:

Input: numCourses = 1, prerequisites = []
Output: [0]


    Time = O(V + E)
    Space = O(V)
     */
    public class Solution
    {
        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            Dictionary<int, List<int>> adj = new Dictionary<int, List<int>>();

            for (int i = 0; i < numCourses; i++)
            {
                adj.Add(i, new List<int>());
            }

            int[] indegree = new int[numCourses];
            Array.Fill(indegree, 0);

            //fill the adj

            foreach (int[] pre in prerequisites)
            {
                int a = pre[0];
                int b = pre[1];

                //b-->a

                adj[b].Add(a);

                indegree[a]++;
            }

            return topologicalsort(adj, numCourses, indegree);
        }

        private int[] topologicalsort(Dictionary<int, List<int>> adj, int numCourses, int[] indegree)
        {
            //implement khan's algo
            List<int> res = new List<int>();
            Queue<int> queue = new Queue<int>();

            int count = 0;//to check if we can visit to all the nodes equal to numCourses

            for (int i = 0; i < numCourses; i++)
            {
                if (indegree[i] == 0)
                {
                    count++;
                    queue.Enqueue(i);
                    //res.Add(i);
                }
            }

            while (queue.Count > 0)
            {
                int u = queue.Dequeue();
                res.Add(u);
                //where we can go with this u - lets loop to neighbour in adj

                foreach (int v in adj[u])
                {
                    indegree[v]--;
                    if (indegree[v] == 0)
                    {
                        count++;

                        queue.Enqueue(v);
                    }
                }
            }

            if (count == numCourses)
            {
                return res.ToArray();
            }

            return new int[] { };
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Solution s = new Solution();
            int numCourses = 4;
            int[][] prerequisites =
            {
                new int[] { 1, 0 },
                new int[] { 2, 0 },
                new int[] { 3, 1 },
                new int[] { 3, 2 }
            };

            var res = s.FindOrder(numCourses, prerequisites);
            for (int i = 0; i < res.Length; i++)
            {
                Console.WriteLine(res[i]);
            }
        }
    }
}
namespace CourseScheduleIIDFS
{
    //210. Course Schedule II Time = O(V + E) , Space = O(V)
    /*
     There are a total of numCourses courses you have to take, labeled from 0 to numCourses - 1. You are given an array prerequisites where prerequisites[i] = [ai, bi] indicates that you must take course bi first if you want to take course ai.
    */

    public class Solution
    {
        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            Dictionary<int, List<int>> adj = new Dictionary<int, List<int>>();//adjency list
            List<int> res = new List<int>();//for storing the topological sort order
            HashSet<int> visited = new HashSet<int>();// for fully visited node
            HashSet<int> visiting = new HashSet<int>();//for cycle detection

            //initialise the adjency list

            for (int i = 0; i < numCourses; i++)
            {
                adj.Add(i, new List<int>());
            }

            //fill the adjency list

            foreach (var pre in prerequisites)
            {
                int courseToTake = pre[0];
                int courseDependsOn = pre[1];
                adj[courseToTake].Add(courseDependsOn);
            }

            //recursive call to check all the courses

            for (int i = 0; i < numCourses; i++)
            {
                if (!dfs(i, adj, visited, visiting, res))
                {
                    return new int[0]; // cycle detected, return empty array
                }
            }

            return res.ToArray();
        }

        private bool dfs(int n, Dictionary<int, List<int>> adj, HashSet<int> visited, HashSet<int> visiting, List<int> res)
        {
            if (visiting.Contains(n))
            {
                return false;// cycle detected
            }

            if (visited.Contains(n))
            {
                return true; // already fully visited, no need to do anything
            }

            visiting.Add(n); // mark the current node as visiting

            foreach(var ad in adj[n])
            {
                if (!dfs(ad, adj, visited, visiting, res))
                {
                    return false; // cycle detected in the recursive call
                }
            }

            visiting.Remove(n); // mark the current node as not visiting
            visited.Add(n); // mark the current node as fully visited
            res.Add(n); // add the current node to the result list
            return true;
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
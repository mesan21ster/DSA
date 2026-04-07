namespace CourseScheduleDFS
{
    //207. Course Schedule
    /*
     There are a total of numCourses courses you have to take, labeled from 0 to numCourses - 1. You are given an array prerequisites where prerequisites[i] = [ai, bi] indicates that you must take course bi first if you want to take course ai.
    */
    public class Solution
    {
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            //using DFS
            //T: O(V+E)
            //S: O(V)

            //make the adjency List with the length set as the total number of courses.
            Dictionary<int,List<int>> adj = new Dictionary<int, List<int>>();

            //initialise the adjency list

            for(int i = 0; i< numCourses; i++)
            {
                adj.Add(i, new List<int>());
            }

            // fir the adj

            foreach(var pre in prerequisites)
            {
                int courseToTake = pre[0];
                int courseDependsOn = pre[1];

                adj[courseToTake].Add(courseDependsOn);
            }

            //visited array

            HashSet<int> visisted = new HashSet<int>();

            //check all the courses recursevly 

            for(int i = 0; i < numCourses; i++)
            {
                if (!dfs(i, adj, visisted))
                {
                    return false;
                }
            }
            return true;
        }

        private bool dfs(int n, Dictionary<int, List<int>> adj, HashSet<int> visisted)
        {
            if (visisted.Contains(n))
            {
                return false; // cycle detected
            }

            if (adj[n] == new List<int>())
            {
                return true; // empty list means, no course depends on 
            }
            visisted.Add(n);//visiting current node
            foreach(var ad in adj[n])
            {
                if (!dfs(ad, adj, visisted)) // call recursive to check all the course depends on
                {
                    return false;
                }
            }

            visisted.Remove(n);// remove course, because we have already visted means completed this course
            adj[n] = new List<int>();// make the current node empty list , so no need to run the dfs on the same dependened courses
            return true;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Solution solution = new Solution();
            int numCources = 2;
            int[][] prerequisites = {
            new int[] { 1, 0 }
            };

            var res = solution.CanFinish(numCources, prerequisites);
            Console.WriteLine(res);
        }
    }
}
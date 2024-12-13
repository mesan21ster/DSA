namespace CourseSchedule
{
    //207. Course Schedule

    /*
     There are a total of numCourses courses you have to take, labeled from 0 to numCourses - 1. You are given an array prerequisites where prerequisites[i] = [ai, bi] indicates that you must take course bi first if you want to take course ai.

For example, the pair [0, 1], indicates that to take course 0 you have to first take course 1.
Return true if you can finish all courses. Otherwise, return false.

 

Example 1:

Input: numCourses = 2, prerequisites = [[1,0]]
Output: true
Explanation: There are a total of 2 courses to take. 
To take course 1 you should have finished course 0. So it is possible.
Example 2:

Input: numCourses = 2, prerequisites = [[1,0],[0,1]]
Output: false
Explanation: There are a total of 2 courses to take. 
To take course 1 you should have finished course 0, and to take course 0 you should also have finished course 1. So it is impossible.


    Time = O(V + E)
    Space = O(V)
     */
    public class Solution
    {
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            //make the adjency List with the length set as the total number of courses.
            Dictionary<int, List<int>> adj = new Dictionary<int, List<int>>();

            int[] indegree = new int[numCourses];//kahn's algo
            Array.Fill(indegree, 0);

            for (int i = 0;i< numCourses; i++)
            {
                adj.Add(i, new List<int>());
            }

            foreach (int[] num in prerequisites)
            {
                int a = num[0];
                int b = num[1];

                //b-->a

                adj[b].Add(a);

                //arrow is moving towards a
                indegree[a]++;
            }

            //if cycle is present , not possible

            return topologicalSort(adj, numCourses, indegree);
        }

        private bool topologicalSort(Dictionary<int, List<int>> adj, int numCourses, int[] indegree)
        {
            //using BFS

            Queue<int> queue = new Queue<int>();
            int count = 0; //how many nodes I have visited, if there are no cycle than I can visist all the nodes and we can write topological sort, if not than there is a cycle 

            //add to queue if indegree is 0, as per khan's algo
            for (int i = 0; i < numCourses; i++)
            {
                if (indegree[i] == 0)
                {
                    count++;//mark visted the node 
                    queue.Enqueue(i);
                }
            }

            while (queue.Count > 0)
            {
                int u = queue.Dequeue();

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

            if (count == numCourses) // I was able to visit all the nodes
            {
                return true; // able to finish all the cources
            }
            return false;
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
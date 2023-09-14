namespace ReconstructItinerary
{
    public class Solution
    {
        //time complexity is O(NlogN) for graph construction and O(N) for DFS, resulting in O(NlogN) in total.
        //the space complexity is O(N).
        public IList<string> FindItinerary(IList<IList<string>> tickets)
        {
            Dictionary<string, List<string>> adj = new Dictionary<string, List<string>>();
            List<string> result = new List<string>();

            //Build the adj

            foreach (var ticket in tickets)
            {
                string from = ticket[0];
                string to = ticket[1];

                if (!adj.ContainsKey(from))
                {
                    adj[from] = new List<string>();
                }
                adj[from].Add(to);
            }

            //Sort the destination in lexical order

            foreach (var dest in adj.Keys)
            {
                adj[dest].Sort();
            }

            //start DFS to explore other options 

            DFS(adj, "JFK", result);

            //sort the result in reverse order , since DFS appends in reverse order

            result.Reverse();

            return result;
        }

        private void DFS(Dictionary<string, List<string>> adj, string airport, List<string> result)
        {
            if (adj.ContainsKey(airport) && adj[airport].Count > 0)
            {
                List<string> destinations = adj[airport];
                while (destinations.Count > 0)
                {
                    string nextDestination = destinations[0];
                    destinations.RemoveAt(0);
                    DFS(adj, nextDestination, result);
                }
            }
            result.Add(airport);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            IList<IList<string>> tickets = new List<IList<string>>()
            {
                new List<string>() { "JFK", "SFO" },
                new List<string>(){ "JFK", "ATL" },
                new List<string>(){ "JFK", "ATL" },
                new List<string>(){ "ATL", "JFK" },
                new List<string>(){ "ATL", "SFO" }
            };
            var res = solution.FindItinerary(tickets);

            foreach (var item in res)
            {
                Console.Write(item + " ");
            }
            Console.ReadLine();
        }
    }
}
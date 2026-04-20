namespace CurrencyConverterGraphDFS
{
    /*
     Build Graph: O(E)
DFS per query: O(V + E)
Space: O(V + E)

    
Ratios.csv contains |N| ratios in the form of two labels and a ratio:

USD, GBP, 0.69 
USD, INR, 0.69 
YEN, EUR, 0.0077
GBP, YEN, 167.75

Each line A, B, C means that C is a conversion factor from A to B. In other words, multiply by C to go from A to B, and 1 A is worth C B’s.

Example: USD, GBP, 0.69 means that 1 USD = 0.69 * GBP, so multiplying by 0.69 converts an amount from USD to GBP.

Queries.csv contains |M| queries in the form of two labels

USD, EUR

The expected output file (output.csv) contains the query with the ratio value filled in.

USD, EUR, 0.89 
Yard, Meter, 0.91
EUR, USD, 1.12

     */

    public class CurrencyGraph
    {
        private Dictionary<string, List<(string, decimal)>> adj;

        public CurrencyGraph()
        {
            adj = new Dictionary<string, List<(string, decimal)>>();
        }

        public void BuildGraph((string from, string to, decimal rate)[] ratios)
        {
            foreach(var (from, to, rate) in ratios)
            {
                string src = from.ToUpper();
                string dest = to.ToUpper();
                // Add forward edge
                AddEdge(src, dest, rate);
                // Add reverse edge
                AddEdge(dest,src, 1/rate);//Why 1 / rate?  example USD → GBP = 0.69, than say 10 USD → GBP = 10 * 0.69 = 6.9 GBP, now if revers than
                                          //6.9 GBP → USD = 6.9 * (1 / 0.69) = 10 USD ✅
            }
        }
        private void AddEdge(string from, string to, decimal rate)
        {
            if (!adj.ContainsKey(from))
            {
                adj[from] = new List<(string, decimal)>();
            }

            adj[from].Add((to, rate));
        }

        public decimal Convert(string source, string target, decimal amount)
        {
            string src = source.ToUpper();
            string dest = target.ToUpper();

            var visited = new HashSet<string>();

            decimal rate = DFS(src, dest, visited);

            return rate * amount;
        }

        private decimal DFS(string current, string target, HashSet<string> visited)
        {
            // Base case: reached target
            if (current == target)
            {
                return 1;
            }

            visited.Add(current);

            foreach(var(neighbor, rate) in adj[current])
            {
                if (visited.Contains(neighbor))
                {
                    continue;
                }
                // Recursive DFS
                decimal currRate = DFS(neighbor, target, visited);
                
                // If valid path found
                if (currRate != -1)
                {
                    return rate * currRate;
                }
            }

            visited.Remove(current);//backtracking
            return -1;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var ratios = new (string from, string to, decimal rate)[]
            {
                ("USD","GBP",0.69m),
                ("USD", "INR", 83m),
                ("YEN", "EUR", 0.0077m),
                ("GBP", "YEN", 167.75m)
            };

            var graph = new CurrencyGraph();
            graph.BuildGraph(ratios);

            //query

            string source = "USD";
            string target = "EUR";
            decimal amount = 1;

            decimal result = graph.Convert(source, target, amount);
            Console.WriteLine($"{amount} {source} = {result} {target}");
        }
    }
}
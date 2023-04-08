namespace CloneGraph
{
    public class Node
    {
        public int val;
        public IList<Node> neighbors;

        public Node()
        {
            val = 0;
            neighbors = new List<Node>();
        }

        public Node(int _val)
        {
            val = _val;
            neighbors = new List<Node>();
        }

        public Node(int _val, List<Node> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
    }
    public class Solution
    {
        public Node CloneGraph(Node node)
        {
            if (node == null)
            {
                return node;
            }

            #region BFS start

            //Dictionary<Node, Node> map = new Dictionary<Node, Node>();

            //Queue<Node> queue = new Queue<Node>();

            //queue.Enqueue(node);
            //map.Add(node, new Node(node.val));

            //while (queue.Count > 0)
            //{
            //    Node curr = queue.Dequeue();

            //    foreach (var neighbore in curr.neighbors)
            //    {
            //        if (!map.ContainsKey(neighbore))
            //        {
            //            //deep clone
            //            map.Add(neighbore, new Node(neighbore.val));
            //            queue.Enqueue(neighbore);
            //        }
            //        //add neighbor's copy to curr's copy
            //        map[curr].neighbors.Add(map[neighbore]);
            //    }

            //}
            //return map[node];

            #endregion BFS End

            #region DFS start

            Dictionary<Node,Node> map = new Dictionary<Node,Node>();

            map.Add(node, new Node(node.val));

            DFS(node, map);

            return map[node];
            #endregion DFS end
        }

        private void DFS(Node node, Dictionary<Node, Node> map)
        {
            if(node == null) { return; }

            foreach (var neighbor in node.neighbors)
            {
                if (!map.ContainsKey(neighbor))
                {
                    //deep copy
                    map.Add(neighbor, new Node(neighbor.val));
                    DFS(neighbor, map);
                }
                //add neighbor's copy to node's copy
                map[node].neighbors.Add(map[neighbor]);
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution sol = new Solution();
            //int[][] adjList = {
            //    new int[] {2, 4 },
            //    new int[] {1, 3 },
            //    new int[] {2, 4 },
            //    new int[] {1, 3 }
            //};
            Node node1 = new Node(1);
            Node node2 = new Node(2);
            Node node3 = new Node(3);
            Node node4 = new Node(4);
            node1.neighbors = new List<Node>() { node1, node2 };
            node2.neighbors = new List<Node>() { node1, node3 };
            node3.neighbors = new List<Node>() { node2, node4 };
            node4.neighbors = new List<Node>() { node3, node1 };
            
            var cloneNode = sol.CloneGraph(node1);

            foreach (var neighbor in cloneNode.neighbors)
            {
                Console.WriteLine(neighbor.val);
            }
            Console.ReadLine();
        }
    }
}
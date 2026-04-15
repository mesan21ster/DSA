namespace DesignSecureLRUinMemoryCache
{
    public class SecureTokenCache
    {
        private class Node
        {
            public string Key;
            public string Value;
            public Node Prev;
            public Node Next;
            public DateTime expiryDate;
        }
        private readonly Dictionary<string, Node> _map;
        private Node _head;
        private Node _tail;
        private readonly int _capacity;
        public SecureTokenCache(int capacity)
        {
            _capacity = capacity;
            _map = new Dictionary<string, Node>();
            _head = new Node();
            _tail = new Node();
            _head.Next = _tail;
            _tail.Prev = _head;
        }

        private bool isExpired(Node node)
        {
            return DateTime.UtcNow > node.expiryDate;
        }
        public string GetToken(string key)
        {
            if(!_map.TryGetValue(key,out Node node))
            {
                return null;
            }
            if (isExpired(node))
            {
                RemoveNode(node);
                MoveToHead(node);
                return null;
            }
            MoveToHead(node);
            return node.Value;
        }
        private void RemoveNode(Node node)
        {
            node.Prev.Next = node.Next;
            node.Next.Prev = node.Prev;
        }
        private void MoveToHead(Node node)
        {
            node.Next = _head.Next;
            node.Prev = _head;
            _head.Next.Prev = node;
            _head.Next = node;
        }

        public void PutToken(string key, string token, int expireTime)
        {
            if(_map.TryGetValue(key,out Node existingNode))
            {
                existingNode.Value = token;
                existingNode.expiryDate = DateTime.UtcNow.Add(TimeSpan.FromSeconds(expireTime));
                MoveToHead(existingNode);
            }
            else
            {
                Node newNode = new Node
                {
                    Key = key,
                    Value = token,
                    expiryDate = DateTime.UtcNow.Add(TimeSpan.FromSeconds(expireTime))
                };
                _map[key] = newNode;
                MoveToHead(newNode);
                if(_map.Count > _capacity)
                {
                    Node lruNode = _tail.Prev;
                    _map.Remove(lruNode.Key);
                    RemoveNode(lruNode);

                    //_map.Remove(_tail.Key);
                    //RemoveNode(_tail);
                }
            }
        }
        public void RevokeToken(string key)
        {
            if(!_map.TryGetValue(key,out Node node))
            {
                return;
            }
            RemoveNode(node);
            _map.Remove(key);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var cache = new SecureTokenCache(2);
            cache.PutToken("u1:read", "A", 10);
            cache.PutToken("u2:write", "B", 10);
            Console.WriteLine(cache.GetToken("u1:read") == "A");

            cache.PutToken("u3:read", "C", 10);
            Console.WriteLine(cache.GetToken("u2:write") == null);

            cache.RevokeToken("u1:read");
            Console.WriteLine(cache.GetToken("u1:read") == null);
            cache.PutToken("x", "D", 1);
            System.Threading.Thread.Sleep(1100);
            Console.WriteLine(cache.GetToken("x") == null);
            Console.WriteLine("All assertion passed.");
        }
    }
}
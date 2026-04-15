namespace LRUCache
{
    using System;
    using System.Collections.Generic;

    public class ConcurrentLRUCache<TKey, TValue>
    {
        private class Node
        {
            public TKey Key;
            public TValue Value;
            public Node Prev;
            public Node Next;

            public Node(TKey key, TValue value)
            {
                Key = key;
                Value = value;
            }
        }

        private readonly int _capacity;
        private readonly Dictionary<TKey, Node> _map;
        private readonly Node _head;
        private readonly Node _tail;

        private readonly object _lock = new object(); // 🔒 Global lock

        public int Count
        {
            get
            {
                lock (_lock)
                {
                    return _map.Count;
                }
            }
        }

        public ConcurrentLRUCache(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentException("Capacity must be > 0");

            _capacity = capacity;
            _map = new Dictionary<TKey, Node>();

            _head = new Node(default!, default!);
            _tail = new Node(default!, default!);

            _head.Next = _tail;
            _tail.Prev = _head;
        }

        // ======================
        // PUT (Insert or Update)
        // ======================
        public void Put(TKey key, TValue value)
        {
            lock (_lock)
            {
                if (_map.TryGetValue(key, out Node node))
                {
                    node.Value = value;

                    Remove(node);
                    InsertAtFront(node);
                }
                else
                {
                    if (_map.Count == _capacity)
                    {
                        Node lru = _tail.Prev;

                        Remove(lru);
                        _map.Remove(lru.Key);
                    }

                    Node newNode = new Node(key, value);
                    _map[key] = newNode;

                    InsertAtFront(newNode);
                }
            }
        }

        // ======================
        // ADD (Fail if exists)
        // ======================
        public void Add(TKey key, TValue value)
        {
            lock (_lock)
            {
                if (_map.ContainsKey(key))
                    throw new ArgumentException("Key already exists");

                Put(key, value); // reuse
            }
        }

        // ======================
        // GET (Throws if missing)
        // ======================
        public TValue Get(TKey key)
        {
            lock (_lock)
            {
                if (!_map.TryGetValue(key, out Node node))
                    throw new KeyNotFoundException();

                Remove(node);
                InsertAtFront(node);

                return node.Value;
            }
        }

        // ======================
        // TRYGET (Safe)
        // ======================
        public bool TryGet(TKey key, out TValue value)
        {
            lock (_lock)
            {
                if (_map.TryGetValue(key, out Node node))
                {
                    Remove(node);
                    InsertAtFront(node);

                    value = node.Value;
                    return true;
                }

                value = default!;
                return false;
            }
        }

        // ======================
        // REMOVE (Bonus)
        // ======================
        public bool RemoveKey(TKey key)
        {
            lock (_lock)
            {
                if (!_map.TryGetValue(key, out Node node))
                    return false;

                Remove(node);
                _map.Remove(key);
                return true;
            }
        }

        // ======================
        // INTERNAL HELPERS
        // ======================
        private void Remove(Node node)
        {
            node.Prev.Next = node.Next;
            node.Next.Prev = node.Prev;
        }

        private void InsertAtFront(Node node)
        {
            node.Next = _head.Next;
            node.Prev = _head;

            _head.Next.Prev = node;
            _head.Next = node;
        }
    }
    class Program
    {
        static void Main()
        {
            var cache = new ConcurrentLRUCache<int, int>(3);

            Parallel.For(0, 10, i =>
            {
                cache.Put(i, i * 10);
                cache.TryGet(i, out _);
            });

            Console.WriteLine("Completed without crash");
        }
    }
}
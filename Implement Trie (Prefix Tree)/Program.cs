namespace ImplementTrie_PrefixTree
{
    public class TrieNode
    {
        public bool isEnd = false;
        public TrieNode[] children = new TrieNode[26];
        public TrieNode() { }
    }
    public class Trie
    {
        private TrieNode root;
        public Trie()
        {
            root = new TrieNode();
        }

        public void Insert(string word)
        {
            TrieNode cur = root;

            foreach (var ch in word.ToLower().ToCharArray())
            {
                int id = ch - 'a';
                if (cur.children[id] == null)
                {
                    cur.children[id] = new TrieNode();
                }
                cur = cur.children[id];
            }
            cur.isEnd = true;
        }

        public bool Search(string word)
        {
            TrieNode cur = root;
            foreach (var ch in word.ToLower().ToCharArray())
            {
                int index = ch - 'a';
                if (cur.children[index] == null)
                {
                    return false;
                }
                cur = cur.children[index];
            }
            return cur.isEnd;
        }

        public bool StartsWith(string prefix)
        {
            TrieNode cur = root;
            foreach (var ch in prefix.ToLower().ToCharArray())
            {
                int index = ch - 'a';
                if (cur.children[index] == null)
                {
                    return false;
                }
                cur = cur.children[index];
            }
            return true;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Trie obj = new Trie();
            obj.Insert("Trie");
            bool param_2 = obj.Search("Trie");
            bool param_3 = obj.StartsWith("T");
            Console.WriteLine(param_2); 
            Console.WriteLine(param_3);
            Console.ReadLine();
        }
    }
}
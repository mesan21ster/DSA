namespace ImplementTrie_PrefixTree
{
    //TC: O(m) for insert, search, and startsWith operations, where m is the length of the input word or prefix. In the worst case, when all characters in the word or prefix are distinct, we need to traverse m nodes in the trie.
    //SC: O(m) for insert, search, and startsWith operations, where m is the length of the input word or prefix. In the worst case, when all characters in the word or prefix are distinct, we need to store m nodes in the trie.
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
        public bool Remove(string word)
        {
            return Remove(root, word.ToLower(), 0);
        }

        private bool Remove(TrieNode cur, string word, int depth)
        {
            if (cur == null)
                return false;

            if (depth == word.Length)
            {
                if (!cur.isEnd)
                    return false;

                cur.isEnd = false;

                // Return true if this node has no children (safe to delete)
                return !HasChildren(cur);
            }

            int index = word[depth] - 'a';// Calculate index for the current character
            bool shouldDeleteChild = Remove(cur.children[index], word, depth + 1);// Recur for the next character

            if (shouldDeleteChild)
            {
                cur.children[index] = null;

                // Propagate: delete this node too if it's not an end and has no children
                return !cur.isEnd && !HasChildren(cur);
            }

            return false;
        }

        private bool HasChildren(TrieNode node)
        {
            foreach (var child in node.children)
            {
                if (child != null)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Determines whether the trie contains any word that starts with the specified prefix.
        /// </summary>
        /// <remarks>The search is case-insensitive and ignores any characters in the prefix that are not
        /// lowercase English letters ('a'-'z').</remarks>
        /// <param name="prefix">The prefix to search for. The comparison is case-insensitive and only considers lowercase English letters
        /// ('a'-'z').</param>
        /// <returns>true if there is at least one word in the trie that begins with the specified prefix; otherwise, false.</returns>
        public bool StartsWith(string prefix)
        {
            TrieNode cur = root;
            foreach (var ch in prefix.ToLower().ToCharArray())
            {
                int index = ch - 'a';// Calculate index for the current character
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
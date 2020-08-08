namespace ALGON.LeetCodeProblems.Design
{
    /*Implement a trie with insert, search, and startsWith methods.

    Example:

    Trie trie = new Trie();

        trie.insert("apple");
    trie.search("apple");   // returns true
    trie.search("app");     // returns false
    trie.startsWith("app"); // returns true
    trie.insert("app");   
    trie.search("app");     // returns true
    Note:

    You may assume that all inputs are consist of lowercase letters a-z.
    All inputs are guaranteed to be non-empty strings.*/
    public class Trie
    {
        public class TrieNode
        {
            TrieNode[] _Links;
            int R = 26;

            public TrieNode()
            {
                _Links = new TrieNode[R];
            }

            public bool IsEnd { get; private set; }

            public bool Contains(char c)
            {
                return _Links[c - 'a'] != null;
            }

            public void Insert(char c, TrieNode node)
            {
                _Links[c - 'a'] = node;
            }

            public TrieNode Get(char c)
            {
                return _Links[c - 'a'];
            }

            public void SetEnd()
            {
                IsEnd = true;
            }
        }

        TrieNode root;

        /** Initialize your data structure here. */
        public Trie()
        {
            root = new TrieNode();
        }

        /** Inserts a word into the trie. */
        public void Insert(string word)
        {
            var node = root;
            for (int i = 0; i < word.Length; i++)
            {
                if (!node.Contains(word[i]))
                {
                    node.Insert(word[i], new TrieNode());
                }

                node = node.Get(word[i]);
            }

            node.SetEnd();
        }

        /** Returns if the word is in the trie. */
        public bool Search(string word)
        {
            var node = SearchPrefix(word);
            return node != null && node.IsEnd;
        }

        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(string prefix)
        {
            var node = SearchPrefix(prefix);
            return node != null;
        }

        TrieNode SearchPrefix(string word)
        {
            var node = root;
            for (int i = 0; i < word.Length; i++)
            {
                if (!node.Contains(word[i]))
                    return null;
                else
                    node = node.Get(word[i]);
            }

            return node;
        }
    }

    /**
     * Your Trie object will be instantiated and called as such:
     * Trie obj = new Trie();
     * obj.Insert(word);
     * bool param_2 = obj.Search(word);
     * bool param_3 = obj.StartsWith(prefix);
     */
}

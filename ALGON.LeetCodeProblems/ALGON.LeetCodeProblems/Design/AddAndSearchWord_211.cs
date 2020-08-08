namespace ALGON.LeetCodeProblems.Design
{
    /*Design a data structure that supports the following two operations:

    void addWord(word)
    bool search(word)
    search(word) can search a literal word or a regular expression string containing only letters a-z or .. A.means it can represent any one letter.

    Example:

    addWord("bad")
    addWord("dad")
    addWord("mad")
    search("pad") -> false
    search("bad") -> true
    search(".ad") -> true
    search("b..") -> true
    Note:
    You may assume that all words are consist of lowercase letters a-z.*/
    public class WordDictionary
    {
        public class TrieNode
        {
            TrieNode[] links;

            public TrieNode()
            {
                links = new TrieNode[26];
            }

            public bool IsEnd { get; private set; }

            public bool Contains(char c)
            {
                return links[c - 'a'] != null;
            }

            public void Insert(char c, TrieNode node)
            {
                links[c - 'a'] = node;
            }

            public TrieNode Get(char c)
            {
                return links[c - 'a'];
            }

            public TrieNode Get(int index)
            {
                return links[index];
            }

            public void SetEnd()
            {
                IsEnd = true;
            }
        }

        TrieNode root;

        /** Initialize your data structure here. */
        public WordDictionary()
        {
            root = new TrieNode();
        }

        /** Adds a word into the data structure. */
        public void AddWord(string word)
        {
            var node = root;
            for (int i = 0; i < word.Length; i++)
            {
                var c = word[i];
                if (!node.Contains(c))
                    node.Insert(c, new TrieNode());
                node = node.Get(c);
            }

            node.SetEnd();
        }

        /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
        public bool Search(string word)
        {
            return Search(word, 0, root);
        }

        bool Search(string word, int i, TrieNode node)
        {
            if (node == null) return false;
            else if (word.Length == i) return node.IsEnd;

            var c = word[i];

            if (c == '.')
            {
                for (int k = 0; k < 26; k++)
                {
                    if (Search(word, i + 1, node.Get(k)))
                        return true;
                }

                return false;
            }
            else
            {
                return Search(word, i + 1, node.Get(c - 'a'));
            }
        }
    }

    /**
     * Your WordDictionary object will be instantiated and called as such:
     * WordDictionary obj = new WordDictionary();
     * obj.AddWord(word);
     * bool param_2 = obj.Search(word);
     */
}

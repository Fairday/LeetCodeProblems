using System.Text;

namespace ALGON.LeetCodeProblems.Trie
{
    //Implement the StreamChecker class as follows:

    //StreamChecker(words) : Constructor, init the data structure with the given words.
    // query(letter): returns true if and only if for some k >= 1, the last k characters queried(in order from oldest to newest, including this letter just queried) spell one of the words in the given list.


    //Example:

    //StreamChecker streamChecker = new StreamChecker(["cd", "f", "kl"]); // init the dictionary.
    //streamChecker.query('a');          // return false
    //streamChecker.query('b');          // return false
    //streamChecker.query('c');          // return false
    //streamChecker.query('d');          // return true, because 'cd' is in the wordlist
    //streamChecker.query('e');          // return false
    //streamChecker.query('f');          // return true, because 'f' is in the wordlist
    //streamChecker.query('g');          // return false
    //streamChecker.query('h');          // return false
    //streamChecker.query('i');          // return false
    //streamChecker.query('j');          // return false
    //streamChecker.query('k');          // return false
    //streamChecker.query('l');          // return true, because 'kl' is in the wordlist
 

    //Note:

    //1 <= words.length <= 2000
    //1 <= words[i].length <= 2000
    //Words will only consist of lowercase English letters.
    //Queries will only consist of lowercase English letters.
    //The number of queries is at most 40000.
    public class TrieNode
    {
        public TrieNode[] nodes;

        public TrieNode()
        {
            nodes = new TrieNode[26];
        }

        public bool Contains(char c)
        {
            return nodes[c - 'a'] != null;
        }

        public void Insert(char c, TrieNode node)
        {
            nodes[c - 'a'] = node;
        }

        public TrieNode Get(char c)
        {
            return nodes[c - 'a'];
        }

        public bool IsEnd { get; private set; }

        public void SetEnd()
        {
            IsEnd = true;
        }
    }

    // Create trie in reverse order, maintain prefix of incoming letters
    // Search in trie by prefix in reverse order
    public class StreamChecker
    {
        TrieNode Root;
        StringBuilder query;

        /*Complexity: Let m be the longest length of word and n be number of words. Also let w be number of query(letter). Then space complexity is O(mn + w) to keep our tree. In fact we can cut our deque if it has length more than m, because we never reach nodes which are far in our deque. Time complexity is O(wm), because for each of w queries we need to traverse at most m letters in our trie.

    Note that other method complexity I mentioned in the beginning in theory is also O(wm), but in practise it works like 10 times slower. The problem is with tests like aaaaaa...aaab.*/
        public StreamChecker(string[] words)
        {
            Root = new TrieNode();

            foreach (var word in words)
                InsertWord(word);

            query = new StringBuilder();
        }

        public bool Query(char letter)
        {
            query.Append(letter);
            var node = Root;
            for (int i = query.Length - 1; i >= 0; i--)
            {
                var l = query[i];
                if (node.Contains(l))
                {
                    node = node.Get(l);
                    if (node.IsEnd)
                        return true;
                }
                else
                    break;
            }

            return false;
        }

        void InsertWord(string word)
        {
            var node = Root;
            for (int i = word.Length - 1; i >= 0; i--)
            {
                var letter = word[i];

                if (!node.Contains(letter))
                {
                    node.Insert(letter, new TrieNode());
                }

                node = node.Get(letter);
            }

            node.SetEnd();
        }
    }

    /**
     * Your StreamChecker object will be instantiated and called as such:
     * StreamChecker obj = new StreamChecker(words);
     * bool param_1 = obj.Query(letter);
     */
}

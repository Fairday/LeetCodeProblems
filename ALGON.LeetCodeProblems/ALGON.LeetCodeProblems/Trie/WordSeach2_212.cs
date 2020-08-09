using System;
using System.Collections.Generic;
using System.Linq;

namespace ALGON.LeetCodeProblems.Trie
{
    //Given a 2D board and a list of words from the dictionary, find all words in the board.

    //Each word must be constructed from letters of sequentially adjacent cell, where "adjacent" cells are those horizontally or vertically neighboring.The same letter cell may not be used more than once in a word.

    //Example:

    //Input: 
    //board = [
    //  ['o', 'a', 'a', 'n'],
    //  ['e','t','a','e'],
    //  ['i','h','k','r'],
    //  ['i','f','l','v']
    //]
    //words = ["oath","pea","eat","rain"]

    //    Output: ["eat","oath"]
    //    Note:

    //All inputs are consist of lowercase letters a-z.
    //The values of words are distinct.
    public class Solution_212
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

            public TrieNode Get(char c)
            {
                return links[c - 'a'];
            }

            public void Put(char c, TrieNode node)
            {
                links[c - 'a'] = node;
            }

            public void SetEnd()
            {
                IsEnd = true;
            }
        }

        public class Trie
        {
            public TrieNode Root { get; }

            public Trie()
            {
                Root = new TrieNode();
            }

            public void Add(string word)
            {
                var node = Root;
                for (int i = 0; i < word.Length; i++)
                {
                    var ch = word[i];
                    if (!node.Contains(ch))
                        node.Put(ch, new TrieNode());
                    node = node.Get(ch);
                }
                node.SetEnd();
            }

            public bool Search(string word)
            {
                var node = Root;
                for (int i = 0; i < word.Length; i++)
                {
                    var ch = word[i];
                    if (!node.Contains(ch))
                        return false;
                    node = node.Get(ch);
                }
                return node.IsEnd;
            }
        }

        public IList<string> FindWords(char[][] board, string[] words)
        {
            if (board == null || board.Length == 0 || words == null || words.Length == 0)
                return new List<string>();

            var foundedWords = new HashSet<string>();

            var trie = new Trie();
            foreach (var word in words)
                trie.Add(word);

            Console.WriteLine(trie.Search("aaab"));

            var rows = board.Length;
            var cols = board[0].Length;

            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                    Helper(r, c, board, trie.Root, foundedWords, "", new bool[rows, cols]);

            return foundedWords.ToList();
        }

        void Helper(int row, int col, char[][] board, TrieNode root, HashSet<string> foundedWords, string word, bool[,] visited)
        {
            var rows = board.Length;
            var cols = board[0].Length;

            if (row < 0 || col < 0 || row >= rows || col >= cols)
                return;

            if (visited[row, col])
                return;

            visited[row, col] = true;

            var letter = board[row][col];

            if (root.Contains(letter))
            {
                var node = root.Get(letter);

                if (node.IsEnd)
                {
                    foundedWords.Add(word + letter);
                }

                Helper(row - 1, col, board, node, foundedWords, word + letter, visited);
                Helper(row + 1, col, board, node, foundedWords, word + letter, visited);
                Helper(row, col - 1, board, node, foundedWords, word + letter, visited);
                Helper(row, col + 1, board, node, foundedWords, word + letter, visited);
            }

            visited[row, col] = false;
        }
    }
}

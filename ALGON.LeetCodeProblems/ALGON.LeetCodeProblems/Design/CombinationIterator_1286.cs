using System.Collections.Generic;
using System.Text;

namespace ALGON.LeetCodeProblems.Design
{
    //Design an Iterator class, which has:

    //A constructor that takes a string characters of sorted distinct lowercase English letters and a number combinationLength as arguments.
    //A function next() that returns the next combination of length combinationLength in lexicographical order.
    //A function hasNext() that returns True if and only if there exists a next combination.


    //Example:

    //CombinationIterator iterator = new CombinationIterator("abc", 2); // creates the iterator.

    //    iterator.next(); // returns "ab"
    //iterator.hasNext(); // returns true
    //iterator.next(); // returns "ac"
    //iterator.hasNext(); // returns true
    //iterator.next(); // returns "bc"
    //iterator.hasNext(); // returns false


    //Constraints:

    //1 <= combinationLength <= characters.length <= 15
    //There will be at most 10^4 function calls per test.
    //It's guaranteed that all calls of the function next are valid.
    public class CombinationIterator
    {
        Queue<string> Combinations;

        public CombinationIterator(string characters, int combinationLength)
        {
            Combinations = new Queue<string>();
            dfs(new StringBuilder(), 0, characters, combinationLength);
        }

        void dfs(StringBuilder current, int start, string characters, int length)
        {
            if (current.Length == length)
            {
                Combinations.Enqueue(current.ToString());
                return;
            }

            for (int i = start; i < characters.Length; i++)
            {
                var ch = characters[i];
                dfs(new StringBuilder(current.ToString() + ch.ToString()), i + 1, characters, length);
            }
        }

        public string Next()
        {
            return Combinations.Dequeue();
        }

        public bool HasNext()
        {
            return Combinations.Count > 0;
        }
    }

    /**
     * Your CombinationIterator object will be instantiated and called as such:
     * CombinationIterator obj = new CombinationIterator(characters, combinationLength);
     * string param_1 = obj.Next();
     * bool param_2 = obj.HasNext();
     */
}

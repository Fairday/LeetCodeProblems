using System;
using System.Collections.Generic;
using System.Text;

namespace ALGON.LeetCodeProblems.Hashtable
{
    /*Given a string, sort it in decreasing order based on the frequency of characters.

    Example 1:

    Input:
    "tree"

    Output:
    "eert"

    Explanation:
    'e' appears twice while 'r' and 't' both appear once.
    So 'e' must appear before both 'r' and 't'. Therefore "eetr" is also a valid answer.
    Example 2:

    Input:
    "cccaaa"

    Output:
    "cccaaa"

    Explanation:
    Both 'c' and 'a' appear three times, so "aaaccc" is also a valid answer.
    Note that "cacaca" is incorrect, as the same characters must be together.
    Example 3:

    Input:
    "Aabb"

    Output:
    "bbAa"

    Explanation:
    "bbaA" is also a valid answer, but "Aabb" is incorrect.
    Note that 'A' and 'a' are treated as two different characters.*/
    public class Solution_451
    {
        public string FrequencySort(string s)
        {
            var map = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (map.ContainsKey(s[i]))
                    map[s[i]]++;
                else
                    map[s[i]] = 1;
            }

            var maxHeap = new MaxHeap(map.Count, (a, b) => map[a] - map[b]);

            foreach (var kvp in map)
                maxHeap.Push(kvp.Key);

            var sb = new StringBuilder();

            while (maxHeap.Count > 0)
            {
                var top = maxHeap.Pop();

                for (int i = 0; i < map[top]; i++)
                {
                    sb.Append(top);
                }
            }

            return sb.ToString();
        }
    }

    public class MaxHeap
    {
        char[] heap;
        Func<char, char, int> comparer;
        int count = 0;

        public MaxHeap(int capacity, Func<char, char, int> comparer)
        {
            heap = new char[capacity];
            this.comparer = comparer;
        }

        public int Count => count;

        public void Push(char c)
        {
            heap[count] = c;
            count++;
            var i = count - 1;
            var parent = Parent(i);
            while (i >= 0 && comparer(heap[i], heap[parent]) > 0)
            {
                exch(parent, i);
                i = parent;
                parent = Parent(i);
            }
        }

        void Heapify(int i)
        {
            var left = Left(i);
            var right = Right(i);
            var largest = i;

            if (left < Count && comparer(heap[left], heap[largest]) > 0)
            {
                largest = left;
            }

            if (right < Count && comparer(heap[right], heap[largest]) > 0)
            {
                largest = right;
            }

            if (largest != i)
            {
                exch(largest, i);
                Heapify(largest);
            }
        }

        public char Pop()
        {
            var top = heap[0];
            heap[0] = heap[count - 1];
            count--;
            Heapify(0);
            return top;
        }

        void exch(int i, int j)
        {
            var temp = heap[j];
            heap[j] = heap[i];
            heap[i] = temp;
        }

        int Parent(int i) => (i - 1) / 2;
        int Left(int i) => 2 * i + 1;
        int Right(int i) => 2 * i + 2;
    }
}

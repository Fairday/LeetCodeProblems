using System;
using System.Collections;
using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.Design
{
    public enum SortDirection
    {
        Ascending, Descending
    }

    public class Heap<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        List<T> _Inner;

        public Heap(SortDirection direction, int capacity = 0)
        {
            _Inner = new List<T>(capacity);
            SortDirection = direction;
        }

        public SortDirection SortDirection { get; }
        public int Count { get; private set; }
        public bool IsEmpty => Count == 0;
        public bool IsAscending => SortDirection == SortDirection.Ascending;
        public bool IsDescending => SortDirection == SortDirection.Descending;

        public void Push(T node)
        {
            _Inner.Add(node);
            Count++;
            var i = Count - 1;
            var parent = Parent(i);
            while (i >= 0 && Compare(_Inner[parent], _Inner[i]))
            {
                Swap(parent, i);
                i = parent;
                parent = Parent(i);
            }
        }

        bool Compare(T parent, T child)
        {
            var pos = parent.CompareTo(child);
            if (pos == 0)
                return false;
            else
                return pos > 0 ? (IsAscending ? true : false) : (IsDescending ? false : true);
        }

        public T Peek() 
        {
            if (Count == 0)
                throw new IndexOutOfRangeException("Heap is empty");
            return _Inner[0];
        }

        public T Pop()
        {
            if (Count == 0)
                throw new IndexOutOfRangeException("Heap is empty");
            var top = _Inner[0];
            _Inner[0] = _Inner[Count - 1];
            _Inner.RemoveAt(Count - 1);
            Count--;
            Heapify(0);
            return top;
        }

        void Heapify(int i)
        {
            var left = Left(i);
            var right = Right(i);
            var smallestrOrLargest = i;

            if (left < Count && Compare(_Inner[left], _Inner[smallestrOrLargest]))
            {
                smallestrOrLargest = left;
            }
            else if (right < Count && Compare(_Inner[right], _Inner[smallestrOrLargest]))
            {
                smallestrOrLargest = right;
            }

            if (smallestrOrLargest != i)
            {
                Swap(smallestrOrLargest, i);
                Heapify(smallestrOrLargest);
            }
        }

        void Swap(int i, int j)
        {
            var temp = _Inner[i];
            _Inner[i] = _Inner[j];
            _Inner[j] = temp;
        }

        public IEnumerator<T> GetEnumerator()
        {
            while (Count > 0)
                yield return Pop();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        int Left(int i) => 2 * i + 1;
        int Right(int i) => 2 * i + 2;
        int Parent(int i) => (i - 1) / 2;
    }
}

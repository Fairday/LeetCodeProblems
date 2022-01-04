using System;
using System.Collections;
using System.Collections.Generic;

namespace Multithreading.Problems.ProducerConsumer.Solutions.Containers
{
    public sealed class UnboundedFifo<T> : IItemsContainer<T>
        where T : IComparable<T>, IComparable
    {
        private readonly LinkedList<T> _linkedList;
        private LinkedListNode<T> _current;

        public int Count => throw new NotImplementedException();

        public UnboundedFifo()
        {
            _linkedList = new LinkedList<T>();
            _current = null;
        }

        public void Put(T item)
        {
            _linkedList.AddLast(item);
        }

        public T TakeOut()
        {
            if (_linkedList.First == null)
                throw new InvalidOperationException("No items is exist in collection");

            if (_current == null)
                _current = _linkedList.First;

            var valueToOut = _current.Value;
            var itemToDelete = _current;
            _current = _current.Next;
            _linkedList.Remove(itemToDelete);
            return valueToOut;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _linkedList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
    }
}
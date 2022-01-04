using System;
using System.Collections;
using System.Collections.Generic;

namespace Multithreading.Problems.ProducerConsumer.Solutions.Containers
{
    public sealed class BoundedFifo<T> : IItemsContainer<T>
        where T : IComparable<T>, IComparable
    {
        private readonly Queue<T> _queue;

        public int Count => _queue.Count;

        public BoundedFifo(int? capacity = null)
        {
            if (capacity == null)
                _queue = new Queue<T>();
            else
                _queue = new Queue<T>(capacity.Value);
        }

        public void Put(T item)
        {
            _queue.Enqueue(item);
        }

        public T TakeOut()
        {
            return _queue.Dequeue();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _queue.GetEnumerator();
        }
    }
}
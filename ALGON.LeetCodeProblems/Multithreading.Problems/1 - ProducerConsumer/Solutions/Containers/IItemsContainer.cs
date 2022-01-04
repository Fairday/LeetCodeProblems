using System;
using System.Collections;
using System.Collections.Generic;

namespace Multithreading.Problems.ProducerConsumer.Solutions.Containers
{
    public interface IItemsContainer<T> : IEnumerable<T>, IEnumerable
        where T : IComparable<T>, IComparable
    {
        void Put(T item);
        T TakeOut();
        int Count { get; }
    }
}
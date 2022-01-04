using System;
using System.Collections;
using System.Collections.Generic;

namespace Multithreading.Problems.ProducerConsumer.Problem
{
    public interface IProducerConsumerQueue<T> : IEnumerable<T>, IEnumerable
        where T : IComparable<T>, IComparable
    {
        int Count { get; }
        bool TryProduce(T data);
        bool TryConsume(out T data);
    }
}
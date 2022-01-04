using Multithreading.Problems.ProducerConsumer.Problem;
using Multithreading.Problems.ProducerConsumer.Solutions.Containers;
using Multithreading.Problems.ProducerConsumer.Solutions.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Multithreading.Problems.ProducerConsumer.Solutions
{
    public sealed class BlockingProducerConsumerQueue<T> : IProducerConsumerQueue<T>
        where T : IComparable<T>, IComparable
    {
        private readonly IItemsContainer<T> _itemsContainer;
        private readonly BlockingImplementationType _blockingImplementationType;
        private readonly BufferType _bufferType;
        private readonly OverflowBehavior _overflowBehavior;
        private readonly int? _maxSize;
        private readonly ISafeWaitAndAcquireHandle _safeWaitAndAcquireHandle;

        public int Count => _itemsContainer.Count;

        public BlockingProducerConsumerQueue(
            int? maxSize = null, 
            BlockingImplementationType blockingImplementationType = BlockingImplementationType.Mutex)
            //By default, if maxSize > 0 then OverflowBehavior.Blocking behavior is providing, however, in case of bounded queue OverflowBehavior.NonBlocking behavior can exist
            : this(maxSize, blockingImplementationType, maxSize > 0 ? BufferType.Bounded : BufferType.Unbounded, maxSize > 0 ? OverflowBehavior.Blocking : OverflowBehavior.NonBlocking)
        {
            if (maxSize == 0)
                throw new ArgumentOutOfRangeException("BlockingProducerConsumerQueue cannot have empty size");

            _maxSize = maxSize;
        }

        private BlockingProducerConsumerQueue(
            int? maxSize, 
            BlockingImplementationType blockingImplementationType, 
            BufferType bufferType, 
            OverflowBehavior overflowBehavior)
        {
            _blockingImplementationType = blockingImplementationType;
            _bufferType = bufferType;

            switch (_blockingImplementationType) 
            {
                case BlockingImplementationType.Mutex:
                {
                        _safeWaitAndAcquireHandle = new MutexWaitAndAcquireHandle();
                        break;
                }
                case BlockingImplementationType.Monitor:
                    {
                        _safeWaitAndAcquireHandle = new MonitorWaitAndAcquireHandle();
                        break;
                    }
                default: throw new NotSupportedException($"{blockingImplementationType} is not supported");
            }

            _overflowBehavior = overflowBehavior;
            if (bufferType == BufferType.Bounded)
                _itemsContainer = new BoundedFifo<T>(maxSize.Value);
            else
                _itemsContainer = new UnboundedFifo<T>();
        }

        public bool TryProduce(T data)
        {
            try
            {
                if (!_safeWaitAndAcquireHandle.TryAcquire(
                    IsBounded() ? () => _itemsContainer.Count == _maxSize : null,
                    _overflowBehavior == OverflowBehavior.Blocking ? null : TimeSpan.FromMilliseconds(0)))
                {
                    return false;
                }

                _itemsContainer.Put(data); //work in critical section
                Console.WriteLine($"Produced: {data}, By CurrentThreadId: {Thread.CurrentThread.ManagedThreadId}");
                return true;
            }
            finally
            {
                _safeWaitAndAcquireHandle.Release(); //get out from critical section
            }
        }

        public bool TryConsume(out T data)
        {
            try
            {
                if (!_safeWaitAndAcquireHandle.TryAcquire(
                IsBounded() ? () => _itemsContainer.Count == 0 : null,
                _overflowBehavior == OverflowBehavior.Blocking ? null : TimeSpan.FromMilliseconds(0)))
                {
                    data = default(T);
                    return false;
                }

                var item = _itemsContainer.TakeOut(); //work in critical section
                Console.WriteLine($"Consumed: {item}, By CurrentThreadId: {Thread.CurrentThread.ManagedThreadId}");
                data = item;
                return true;
            }
            finally
            {
                _safeWaitAndAcquireHandle.Release(); //get out from critical section
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            try
            {
                _safeWaitAndAcquireHandle.TryAcquire();
                while (Count > 0)
                {
                    TryConsume(out T data);
                    yield return data;
                }
            }
            finally
            {
                _safeWaitAndAcquireHandle.Release();
            }
        }

        private bool IsBounded() => _bufferType == BufferType.Bounded;
    }
}
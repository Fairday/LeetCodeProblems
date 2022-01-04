using ProducerConsumer.Problem;
using ProducerConsumer.Solutions.Containers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace ProducerConsumer.Solutions
{
    public sealed class BlockingProducerConsumerQueueViaSemaphore<T> : IProducerConsumerQueue<T>
        where T : IComparable<T>, IComparable
    {
        private readonly Semaphore _padLock;
        private readonly Semaphore _availableSpaceToProduce;
        private readonly Semaphore _availableItemsToConsume;
        private readonly IItemsContainer<T> _itemsContainer;

        public int Count => _itemsContainer.Count;

        public BlockingProducerConsumerQueueViaSemaphore(int maxSize)
        {
            if (maxSize == 0)
                throw new ArgumentOutOfRangeException("BlockingProducerConsumerQueue cannot have empty size");

            _padLock = new Semaphore(1, 1);
            _availableSpaceToProduce = new Semaphore(maxSize, maxSize);
            _availableItemsToConsume = new Semaphore(0, maxSize);
            _itemsContainer = new BoundedFifo<T>(maxSize);
        }

        public bool TryProduce(T data)
        {
            //Try to produce new item
            _availableSpaceToProduce.WaitOne();
            try
            {
                //Try to enter in critical section
                _padLock.WaitOne();
                //Work in critical section
                _itemsContainer.Put(data);
            }
            finally
            {
                //Get out from critical section
                _padLock.Release();
            }
            //Notify consumers about new item
            _availableItemsToConsume.WaitOne();
            return true;
        }

        public bool TryConsume(out T data)
        {
            return TryConsumeCore(out data, true);
        }

        private bool TryConsumeCore(out T data, bool blockIfNothingToConsume)
        {
            //Try to consume new item
            if (blockIfNothingToConsume)
                _availableItemsToConsume.WaitOne();
            else
            {
                if (!_availableItemsToConsume.WaitOne(TimeSpan.FromMilliseconds(0)))
                {
                    data = default;
                    return false;
                }
            }
            try
            {
                //Try to enter in critical section
                _padLock.WaitOne();
                //Work in critical section
                var item = _itemsContainer.TakeOut();
                data = item;
            }
            finally
            {
                //Get out from critical section
                _padLock.Release();
            }
            //Notify producers about new space
            _availableSpaceToProduce.WaitOne();
            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            while (TryConsumeCore(out T data, false))
            {
                yield return data;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
    }
}
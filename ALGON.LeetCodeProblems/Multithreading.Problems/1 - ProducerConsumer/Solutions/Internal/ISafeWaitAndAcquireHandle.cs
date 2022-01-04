using System;

namespace Multithreading.Problems.ProducerConsumer.Solutions.Internal
{
    internal interface ISafeWaitAndAcquireHandle 
    {
        bool TryAcquire(Func<bool> waitCondition = null, TimeSpan? timeout = null);
        void Release();
    }
}
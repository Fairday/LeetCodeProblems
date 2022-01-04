using System;
using System.Threading;

namespace ProducerConsumer.Solutions.Internal
{
    internal sealed class MutexWaitAndAcquireHandle : BaseSafeWaitAndAcquireHandle
    {
        private Mutex _mutex;

        public MutexWaitAndAcquireHandle()
        {
            _mutex = new Mutex();
        }

        public override bool TryAcquire(Func<bool> waitCondition = null, TimeSpan? timeout = null)
        {
            ThrowIfDisposed();

            if (timeout != null)
            {
                if (!_mutex.WaitOne(timeout.Value))
                    return false;
            }
            else 
            {
                _mutex.WaitOne();
            }

            if (waitCondition != null)
            {
                // Implementation of spin wait technique for waiting of condition
                while (waitCondition())
                {
                    // Release the mutex to give other threads (another producer or consumer threads)
                    // a chance to acquire it
                    _mutex.ReleaseMutex();
                    // Reacquire the mutex before checking the
                    // condition due possibility of race condition
                    _mutex.WaitOne();
                }
            }

            return true;
        }

        public override void Release()
        {
            ThrowIfDisposed();
            _mutex.ReleaseMutex();
        }

        protected override void OnDisposingManagedResources()
        {
            _mutex.Dispose();
            _mutex = null;
        }

        ~MutexWaitAndAcquireHandle()
        {
            //Dispose only unmanaged resources
            Dispose(false);
        }
    }
}
using System;
using System.Threading;

namespace Multithreading.Problems.ProducerConsumer.Solutions.Internal
{
    internal sealed class MonitorWaitAndAcquireHandle : BaseSafeWaitAndAcquireHandle
    {
        private object _padLock;

        public MonitorWaitAndAcquireHandle()
        {
            _padLock = new object();
        }

        public override bool TryAcquire(Func<bool> waitCondition = null, TimeSpan? timeout = null)
        {
            ThrowIfDisposed();

            //Thread enters entry set and goes through if monitor execution section is free
            if (timeout != null)
            {
                if (!Monitor.TryEnter(_padLock, timeout.Value))
                    return false;
            }
            else
            {
                Monitor.Enter(_padLock);
            }

            if (waitCondition != null) 
            {
                //Mesa Monitors semantics, we need to wait in loop due spurious or fake wakeups
                while (waitCondition()) 
                {
                    //Thread enters wait set and automatically releases _padLock, hence another thread can enter the monitor
                    Monitor.Wait(_padLock);
                }
            }

            return true;
        }

        public override void Release()
        {
            ThrowIfDisposed();
            Monitor.Exit(_padLock);
        }

        protected override void OnDisposingManagedResources()
        {
            Monitor.Exit(_padLock);
            _padLock = null;
        }

        ~MonitorWaitAndAcquireHandle()
        {
            //Dispose only unmanaged resources
            Dispose(false);
        }
    }
}

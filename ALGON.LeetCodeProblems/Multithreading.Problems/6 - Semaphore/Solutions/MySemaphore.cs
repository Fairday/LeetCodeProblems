using Multithreading.Problems._6___Semaphore.Problem;
using System.Threading;

namespace Multithreading.Problems._6___Semaphore.Solutions
{
    public sealed class MySemaphore : SemaphoreBase
    {
        private readonly object _padLock;

        public MySemaphore(int availablePermits, int maxPermits) : base(availablePermits, maxPermits)
        {
            _padLock = new object();
        }

        public override void Acquire()
        {
            //try to enter in critical section
            Monitor.Enter(_padLock);

            //no available permits
            while (_availablePermits == 0)
                //wait for permit
                Monitor.Wait(_padLock);

            //gain a permit
            _availablePermits--;

            //notify all threads in wait set
            Monitor.PulseAll(_padLock);
            //exit from critical section
            Monitor.Exit(_padLock);
        }

        public override void Release()
        {
            //try to enter in critical section
            Monitor.Enter(_padLock);

            //all permits available
            while (_availablePermits == _maxPermits)
                //wait for possibility to return permit
                Monitor.Wait(_padLock);

            //return a permit
            _availablePermits++;

            //notify all threads in wait set
            Monitor.PulseAll(_padLock);
            //exit from critical section
            Monitor.Exit(_padLock);
        }
    }
}
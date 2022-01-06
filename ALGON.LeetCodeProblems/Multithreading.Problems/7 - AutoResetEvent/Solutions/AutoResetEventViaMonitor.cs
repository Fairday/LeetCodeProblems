using Multithreading.Problems._7___AutoResetEvent.Problem;
using System.Threading;

namespace Multithreading.Problems._7___AutoResetEvent.Solutions
{
    public sealed class AutoResetEventViaMonitor : AutoResetEventBase
    {
        private readonly object _padLock;

        public AutoResetEventViaMonitor(bool initialSignaledState) : base(initialSignaledState)
        {
            _padLock = new object();
        }

        public override void Wait()
        {
            try
            {
                //try to enter in critical section
                Monitor.Enter(_padLock);

                //if unsignaled state then wait
                while (!_signaled)
                    Monitor.Wait(_padLock);

                //only one thread can move forward, hence we need to off signal state
                _signaled = false;
            }
            finally
            {
                //exit from critical section
                Monitor.Exit(_padLock);
            }
        }

        public override void Signal()
        {
            try
            {
                //try to enter in critical section
                Monitor.Enter(_padLock);

            //idemptotently enable signal state
            _signaled = true;

            //notify threads in wait set about possibility to move forward
            Monitor.Pulse(_padLock);
            }
            finally
            {
                //exit from critical section
                Monitor.Exit(_padLock);
            }
        }
    }
}
using Multithreading.Problems._7___AutoResetEvent.Problem;
using System.Threading;

namespace Multithreading.Problems._7___AutoResetEvent.Solutions
{
    public sealed class AutoResetEventViaSemaphore : AutoResetEventBase
    {
        private readonly Semaphore _moveForward;
        private readonly Semaphore _padLock;

        public AutoResetEventViaSemaphore(bool initialSignaledState) : base(initialSignaledState)
        {
            _moveForward = new Semaphore(initialSignaledState ? 1 : 0, 1);
            _padLock = new Semaphore(1, 1);
        }

        public override void Wait()
        {
            //try to enter in critical section
            _padLock.WaitOne();

            while (!_signaled)
            {
                //release global lock (_padLock)
                _padLock.Release();
                //try to move forward 
                _moveForward.WaitOne();
                //if allowed to move forward then try to acquire global lock
                //we need it because another thread can be already moving forward
                _padLock.WaitOne();
            }

            _signaled = false;
            //exit from critical section
            _padLock.Release();
        }

        public override void Signal()
        {
            try
            {
                //try to enter in critical section
                _padLock.WaitOne();

                if (!_signaled)
                {
                    //let one waiting or new thread to move forward
                    _signaled = true;
                    _moveForward.Release();
                }
            }
            finally
            {
                //exit from critical section
                _padLock.Release();
            }
        }
    }
}
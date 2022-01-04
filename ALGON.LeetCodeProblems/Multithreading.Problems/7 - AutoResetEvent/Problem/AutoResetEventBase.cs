namespace Multithreading.Problems._7___AutoResetEvent.Problem
{
    public abstract class AutoResetEventBase
    {
        protected bool _signaled;

        public AutoResetEventBase(bool initialSignaledState)
        {
            _signaled = initialSignaledState;
        }

        public abstract void Wait();
        public abstract void Signal();
    }
}
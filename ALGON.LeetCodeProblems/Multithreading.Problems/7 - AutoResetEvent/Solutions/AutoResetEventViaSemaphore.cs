using Multithreading.Problems._7___AutoResetEvent.Problem;

namespace Multithreading.Problems._7___AutoResetEvent.Solutions
{
    public sealed class AutoResetEventViaSemaphore : AutoResetEventBase
    {
        public AutoResetEventViaSemaphore(bool initialSignaledState) : base(initialSignaledState)
        {
        }

        public override void Wait()
        {
            throw new System.NotImplementedException();
        }

        public override void Signal()
        {
            throw new System.NotImplementedException();
        }
    }
}
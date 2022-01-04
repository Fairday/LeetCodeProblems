using System;

namespace Multithreading.Problems.ProducerConsumer.Solutions.Internal
{
    internal abstract class BaseSafeWaitAndAcquireHandle : ISafeWaitAndAcquireHandle, IDisposable
    {
        private bool _disposed;
        protected string Name { get; }
        public abstract bool TryAcquire(Func<bool> waitCondition = null, TimeSpan? timeout = null);
        public abstract void Release();

        public void Dispose()
        {
            //Dispose of unmanaged/managed resources
            Dispose(true);
            //Suppress finalization MutexWaitConditionHandle object on garbage collecting
            GC.SuppressFinalize(this);
        }

        protected virtual void OnDisposingManagedResources() { }
        protected virtual void OnDisposingUnmanagedResources() { }

        protected void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                //disposing of managed resources
                OnDisposingManagedResources();
            }

            //disposing of unmanaged resources
            OnDisposingUnmanagedResources();
            _disposed = true;
        }

        protected void ThrowIfDisposed()
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(Name));
        }
    }
}
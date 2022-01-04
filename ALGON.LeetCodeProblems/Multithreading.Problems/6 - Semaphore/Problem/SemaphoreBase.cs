using System;

namespace Multithreading.Problems._6___Semaphore.Problem
{
    public abstract class SemaphoreBase
    {
        protected int _availablePermits;
        protected int _maxPermits;

        protected SemaphoreBase(int availablePermits, int maxPermits)
        {
            if (availablePermits < 0)
                throw new ArgumentOutOfRangeException("availablePermits should be more or equal than zero");

            if (maxPermits <= 0)
                throw new ArgumentOutOfRangeException("maxPermits should be more than zero");

            if (availablePermits > maxPermits)
                throw new ArgumentOutOfRangeException("availablePermits should be less or equal than maxPermits");

            _availablePermits = availablePermits;
            _maxPermits = maxPermits;
        }

        public abstract void Acquire();
        public abstract void Release();
    }
}
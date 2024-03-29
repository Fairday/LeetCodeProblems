﻿namespace Multithreading.Problems.ProducerConsumer.Solutions.Internal
{
    /// <summary>
    /// What will happen if queue is empty of full?
    /// </summary>
    internal enum OverflowBehavior
    {
        /// <summary>
        /// Queue doesn't block threads if it's empty or full
        /// </summary>
        NonBlocking,
        /// <summary>
        /// Queue blocks threads if it's empty or full
        /// </summary>
        Blocking
    }
}
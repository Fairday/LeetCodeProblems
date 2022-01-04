namespace ProducerConsumer.Solutions
{
    /// <summary>
    /// Internal implementation of blocking collection
    /// </summary>
    public enum BlockingImplementationType
    {
        /// <summary>
        /// Implementation is supposing to wait for condition with spin-wait (anti-pattern) technique
        /// </summary>
        Mutex = 0,
        /// <summary>
        /// Implementation is supposing to wait for condition in wait set and to use signals for notifing waiters be ready (entry set) to attempt ownership of monitor
        /// </summary>
        Monitor = 1
    }
}
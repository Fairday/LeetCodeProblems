namespace ProducerConsumer.Solutions.Internal
{
    /// <summary>
    /// What will happen if queue is empty of full?
    /// </summary>
    public enum OverflowBehavior
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
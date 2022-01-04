using ProducerConsumer.Solutions;
using System;
using System.Threading;

namespace ProducerConsumer.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new BlockingProducerConsumerQueue<int>(5);

            var producerA = new Thread(() => 
            {
                var item = 0;
                while (true)
                {
                    Thread.Sleep(500);
                    item += 1;
                    queue.TryProduce(item);
                }
            });

            var producerB = new Thread(() =>
            {
                var item = 150;
                while (true)
                {
                    Thread.Sleep(500);
                    item += 1;
                    queue.TryProduce(item);
                }
            });

            var consumerA = new Thread(() =>
            {
                while (true)
                {
                    Thread.Sleep(3000);
                    queue.TryConsume(out int item);
                }
            });

            var consumerB = new Thread(() =>
            {
                while (true)
                {
                    Thread.Sleep(3000);
                    queue.TryConsume(out int item);
                }
            });

            producerA.IsBackground = true;
            producerB.IsBackground = true;
            consumerA.IsBackground = true;
            consumerB.IsBackground = true;

            producerA.Start();
            producerB.Start();
            consumerA.Start();
            consumerB.Start();

            Thread.Sleep(30000);

            foreach (var item in queue)
            {
                Console.WriteLine($"Consumed in suspend: {item}, CurrentThreadId: {Thread.CurrentThread.ManagedThreadId}");
            }
        }
    }
}
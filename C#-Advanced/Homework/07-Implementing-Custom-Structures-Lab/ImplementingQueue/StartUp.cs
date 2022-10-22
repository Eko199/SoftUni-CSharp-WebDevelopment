using System;

namespace ImplementingQueue
{
    internal class StartUp
    {
        public static void Main(string[] args)
        {
            CustomQueue queue = new CustomQueue();

            for (int i = 0; i < 100; i++)
            {
                queue.Enqueue(i);
            }

            Console.WriteLine("Dequeued: " + queue.Dequeue());
            Console.WriteLine("Peeked: " + queue.Peek());
            queue.ForEach(Console.WriteLine);

            queue.Clear();
            queue.Enqueue(1);
            queue.ForEach(Console.WriteLine);
        }
    }
}

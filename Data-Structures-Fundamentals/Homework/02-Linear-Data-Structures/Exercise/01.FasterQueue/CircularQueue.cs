namespace Problem01.CircularQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CircularQueue<T> : IAbstractQueue<T>
    {
        private const int DEFAULT_CAPACITY = 4;

        private T[] items;
        private int startIndex, endIndex;

        public CircularQueue(int capacity = DEFAULT_CAPACITY)
        {
            items = new T[capacity];
            startIndex = endIndex = 0;
        }

        public int Count { get; private set; }

        public T Dequeue()
        {
            ValidateNotEmpty();

            T dequeued = items[startIndex];
            startIndex = (startIndex + 1) % items.Length;
            Count--;

            return dequeued;
        }

        public void Enqueue(T item)
        {
            GrowIfNeeded();

            items[endIndex] = item;
            endIndex = (endIndex + 1) % items.Length;
            Count++;
        }

        public T Peek()
        {
            ValidateNotEmpty();
            return items[startIndex];
        }

        public T[] ToArray() => GrowWithCapacity(Count);

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return items[(startIndex + i) % items.Length];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void ValidateNotEmpty()
        {
            if (Count == 0)
                throw new InvalidOperationException("Queue is empty!");
        }

        private void GrowIfNeeded()
        {
            if (Count < items.Length)
                return;

            items = GrowWithCapacity(items.Length * 2);
            startIndex = 0;
            endIndex = Count;
        }

        private T[] GrowWithCapacity(int newCapacity)
        {
            var newItems = new T[newCapacity];

            for (int i = 0; i < Math.Min(Count, newCapacity); i++)
            {
                newItems[i] = items[(startIndex + i) % items.Length];
            }

            return newItems;
        }
    }

}

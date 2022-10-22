using System;

namespace ImplementingQueue
{
    public class CustomQueue
    {
        private const int InitialCapacity = 4;
        private int[] items;

        public CustomQueue()
        {
            Count = 0;
            items = new int[InitialCapacity];
        }

        public int Count { get; private set; }

        private void IncreaseSize()
        {
            int[] copy = new int[items.Length * 2];
            items.CopyTo(copy, 0);
            items = copy;
        }
        private void SwitchElements()
        {
            for (int i = 0; i < Count - 1; i++)
            {
                items[i] = items[i + 1];
            }

            items[Count - 1] = default;
        }

        private void IsEmpty()
        {
            if (Count == 0)
                throw new InvalidOperationException("The queue is empty");
        }

        public void Enqueue(int item)
        {
            if (Count == items.Length)
                IncreaseSize();

            items[Count++] = item;
        }

        public int Dequeue()
        {
            IsEmpty();

            int result = items[0];
            SwitchElements();
            Count--;

            return result;
        }

        public int Peek()
        {
            IsEmpty();
            return items[0];
        }

        public void Clear()
        {
            IsEmpty();
            items = new int[InitialCapacity];
            Count = 0;
        }

        public void ForEach(Action<int> action)
        {
            foreach (int item in items[..Count])
            {
                action(item);
            }
        }
    }
}

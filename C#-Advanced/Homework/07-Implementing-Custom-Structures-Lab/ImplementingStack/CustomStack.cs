using System;

namespace ImplementingStack
{
    public class CustomStack
    {
        private const int InitialCapacity = 4;
        private int[] items;

        public CustomStack()
        {
            Count = 0;
            items = new int[InitialCapacity];
        }

        public int Count { get; private set; }

        private void Resize()
        {
            int[] copy = new int[items.Length * 2];

            for (int i = 0; i < Count; i++)
            {
                copy[i] = items[i];
            }

            items = copy;
        }

        public void Push(int item)
        {
            if (Count == items.Length)
                Resize();

            items[Count++] = item;
        }

        public int Pop()
        {
            if (Count == 0)
                throw new InvalidOperationException("Stack is empty!");

            return items[--Count];
        }

        public int Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException("Stack is empty!");

            return items[Count - 1];
        }

        public void ForEach(Action<int> action)
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                action(items[i]);
            }
        }
    }
}

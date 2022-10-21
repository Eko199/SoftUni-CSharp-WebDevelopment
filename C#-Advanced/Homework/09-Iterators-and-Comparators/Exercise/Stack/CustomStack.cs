using System;
using System.Collections;
using System.Collections.Generic;

namespace Stack
{
    internal class Stack<T> : IEnumerable<T>
    {
        private const int InitialCapacity = 4;
        private T[] items;

        public Stack()
        {
            items = new T[InitialCapacity];
        }

        public int Count { get; private set; }

        public void Push(T item)
        {
            if (Count == items.Length)
                Resize();

            items[Count++] = item;
        }

        private void Resize()
        {
            T[] copy = new T[items.Length * 2];

            for (int i = 0; i < Count; i++)
            {
                copy[i] = items[i];
            }

            items = copy;
        }

        public T Pop()
        {
            if (Count == 0)
                throw new InvalidOperationException("No elements");
            
            return items[--Count];
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
                yield return items[i];
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

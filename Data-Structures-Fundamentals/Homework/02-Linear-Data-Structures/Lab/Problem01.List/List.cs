namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] items;

        public List()
            : this(DEFAULT_CAPACITY) { }

        public List(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                ValidateIndex(index);
                return items[index];
            }
            set
            {
                ValidateIndex(index);
                items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            GrowIfNeeded();
            items[Count++] = item;
        }

        public bool Contains(T item) => IndexOf(item) != -1;

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[i].Equals(item))
                    return i;
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            GrowIfNeeded();
            ValidateIndex(index);

            for (int i = Count; i > index; i--)
            {
                items[i] = items[i - 1];
            }

            items[index] = item;
            Count++;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);

            if (index == -1) 
                return false;

            RemoveAt(index);
            return true;
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index);
            Count--;

            for (int i = index; i < Count; i++)
            {
                items[i] = items[i + 1];
            }

            items[Count] = default;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void GrowIfNeeded()
        {
            if (Count < items.Length) 
                return;

            var newItems = new T[items.Length * 2];
            Array.Copy(items, newItems, items.Length);
            items = newItems;
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= Count) 
                throw new IndexOutOfRangeException();
        }
    }
}
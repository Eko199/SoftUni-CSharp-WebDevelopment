using System;

namespace ImplementingList
{
    public class CustomList
    {
        private const int InitialCapacity = 2;
        private int[] items;

        public CustomList()
        {
            items = new int[InitialCapacity];
        }

        public int Count { get; private set; }

        public int this[int index]
        {
            get
            {
                if (index >= Count)
                    throw new IndexOutOfRangeException("Index out of bounds!");

                return items[index];
            }
            set
            {
                if (index >= Count)
                    throw new IndexOutOfRangeException("Index out of bounds!");

                items[index] = value;
            }
        }

        private void Resize()
        {
            int[] copy = new int[items.Length * 2];

            for (int i = 0; i < Count; i++)
            {
                copy[i] = items[i];
            }

            items = copy;
        }

        private void Shrink()
        {
            int[] copy = new int[items.Length / 2];

            for (int i = 0; i < Count; i++)
            {
                copy[i] = items[i];
            }

            items = copy;
        }

        private void Shift(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                items[i] = items[i + 1];
            }
        }

        private void ShiftToRight(int index)
        {
            for (int i = Count; i > index; i--)
            {
                items[i] = items[i - 1];
            }
        }

        public void Add(int item)
        {
            if (Count == items.Length)
                Resize();

            items[Count++] = item;
        }

        public int RemoveAt(int index)
        {
            if (index >= Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            int removed = items[index];
            items[index] = default;
            Shift(index);
            
            if (--Count <= items.Length / 4)
                Shrink();

            return removed;
        }

        public void Insert(int index, int item)
        {
            if (index > Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            if (Count == items.Length)
                Resize();

            ShiftToRight(index);
            items[index] = item;
            Count++;
        }

        public bool Contains(int item)
        {
            bool found = false;

            for (int i = 0; i < Count && !found; i++)
            {
                if (items[i] == item)
                    found = true;
            }

            return found;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            if (firstIndex >= Count || secondIndex >= Count)
                throw new ArgumentOutOfRangeException();

            (items[firstIndex], items[secondIndex]) = (items[secondIndex], items[firstIndex]);
        }
        public int Find(Predicate<int> predicate)
        {
            for (int i = 0; i < Count; i++)
            {
                if (predicate(items[i]))
                    return items[i];
            }

            return default;
        }

        public void Reverse()
        {
            int[] copy = new int[items.Length];

            for (int i = Count - 1; i >= 0; i--)
                copy[Count - 1 - i] = items[i];

            items = copy;
        }

        public override string ToString()
            => $"[{string.Join(", ", items[..Count])}]";
    }
}

namespace HashTable
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    public class HashTable<TKey, TValue> : IEnumerable<KeyValue<TKey, TValue>>
    {
        public const int InitialCapacity = 16;
        private const float LoadFactor = 0.75f;

        private LinkedList<KeyValue<TKey, TValue>>[] slots;

        public HashTable() : this(InitialCapacity) { }

        public HashTable(int capacity)
        {
            slots = new LinkedList<KeyValue<TKey, TValue>>[capacity];
        }

        public int Count { get; private set; }

        public int Capacity => slots.Length;

        public void Add(TKey key, TValue value)
        {
            GrowIfNeeded();
            int index = FindSlotNumber(key);

            if (slots[index] is null)
            {
                slots[index] = new LinkedList<KeyValue<TKey, TValue>>();
            } 
            else if (slots[index].SingleOrDefault(kvp => kvp.Key.Equals(key)) != null)
            {
                throw new ArgumentException("Duplicate keys!", key.ToString());
            }

            slots[index].AddLast(new KeyValue<TKey, TValue>(key, value));
            Count++;
        }

        public bool AddOrReplace(TKey key, TValue value)
        {
            try
            {
                Add(key, value);
            }
            catch (ArgumentException ae)
            {
                if (!ae.Message.Contains("Duplicate keys!") || ae.ParamName != key.ToString())
                {
                    throw;
                }

                Find(key).Value = value;
                return true;
            }

            return false;
        }

        public TValue Get(TKey key)
        {
            KeyValue<TKey, TValue> element = Find(key);
            return element is null ? throw new KeyNotFoundException() : element.Value;
        }

        public TValue this[TKey key]
        {
            get => Get(key);
            set => AddOrReplace(key, value);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            KeyValue<TKey, TValue> element = Find(key);
            value = element is null ? default : element.Value;
            return element != null;
        }

        public KeyValue<TKey, TValue> Find(TKey key) 
            => slots[FindSlotNumber(key)]?
                .SingleOrDefault(kvp => kvp.Key.Equals(key));

        public bool ContainsKey(TKey key) => Find(key) != null;

        public bool Remove(TKey key)
        {
            KeyValue<TKey, TValue> element = Find(key);

            if (element is null)
            {
                return false;
            }

            slots[FindSlotNumber(key)].Remove(element);
            Count--;
            return true;
        }

        public void Clear()
        {
            slots = new LinkedList<KeyValue<TKey, TValue>>[InitialCapacity];
            Count = 0;
        }

        public IEnumerable<TKey> Keys => this.Select(kvp => kvp.Key);

        public IEnumerable<TValue> Values => this.Select(kvp => kvp.Value);

        public IEnumerator<KeyValue<TKey, TValue>> GetEnumerator() 
            => slots
                .Where(slot => slot != null)
                .SelectMany(slot => slot)
                .GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void GrowIfNeeded()
        {
            if ((Count + 1f) / Capacity <= LoadFactor)
            {
                return;
            }

            var newTable = new HashTable<TKey, TValue>(Capacity * 2);
            foreach (KeyValue<TKey, TValue> element in this)
            {
                newTable.Add(element.Key, element.Value);
            }

            slots = newTable.slots;
        }

        private int FindSlotNumber(TKey key) => Math.Abs(key.GetHashCode()) % Capacity;
    }
}
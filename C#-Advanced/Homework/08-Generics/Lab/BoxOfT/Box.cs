using System;
using System.Collections.Generic;

namespace BoxOfT
{
    internal class Box<T>
    {
        private List<T> list;

        public Box()
        {
            list = new List<T>();
        }

        public int Count => list.Count;

        public void Add(T item)
            => list.Add(item);

        public T Remove()
        {
            T item = list[^1];
            list.RemoveAt(Count - 1);
            return item;
        }
    }
}

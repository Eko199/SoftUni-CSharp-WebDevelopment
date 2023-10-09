using System;
using System.Collections.Generic;

namespace _03.MinHeap
{
    public class PriorityQueue<T> : MinHeap<T> where T : IComparable<T>
    {
        public PriorityQueue()
        {
            this.elements = new List<T>();
        }

        public void Enqueue(T element) => Add(element);

        public T Dequeue() => ExtractMin();

        public void DecreaseKey(T key) => HeapifyUp(elements.IndexOf(key));
    }
}

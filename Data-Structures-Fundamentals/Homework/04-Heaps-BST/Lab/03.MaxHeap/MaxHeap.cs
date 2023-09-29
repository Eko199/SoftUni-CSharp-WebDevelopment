namespace _03.MaxHeap
{
    using System;
    using System.Collections.Generic;

    public class MaxHeap<T> : IAbstractHeap<T> where T : IComparable<T>
    {
        private IList<T> elements;

        public MaxHeap()
        {
            elements = new List<T>();
        }

        public int Size => elements.Count;

        public void Add(T element)
        {
            elements.Add(element);
            HeapifyUp(elements.Count - 1);
        }

        public T ExtractMax()
        {
            if (elements.Count == 0)
                throw new InvalidOperationException("Heap is empty!");

            T element = elements[0];

            (elements[0], elements[elements.Count - 1]) = (elements[elements.Count - 1], elements[0]);
            elements.RemoveAt(elements.Count - 1);
            HeapifyDown(0);

            return element;
        }

        public T Peek()
        {
            if (elements.Count == 0)
                throw new InvalidOperationException("Heap is empty!");

            return elements[0];
        }

        private void HeapifyUp(int index)
        {
            int parentIndex = (index - 1) / 2;

            while (IsIndexValid(index) && IsIndexValid(parentIndex) && elements[parentIndex].CompareTo(elements[index]) < 0)
            {
                (elements[index], elements[parentIndex]) = (elements[parentIndex], elements[index]);
                index = parentIndex;
                parentIndex = (index - 1) / 2;
            }
        }

        private void HeapifyDown(int index)
        {
            int leftChildIndex = index * 2 + 1;
            int rightChildIndex = leftChildIndex + 1;
            int biggerChildIndex;

            if (!IsIndexValid(leftChildIndex))
                return;

            if (!IsIndexValid(rightChildIndex))
                biggerChildIndex = leftChildIndex;
            else
                biggerChildIndex = elements[leftChildIndex].CompareTo(elements[rightChildIndex]) > 0 ? leftChildIndex : rightChildIndex;

            while (IsIndexValid(index) && IsIndexValid(biggerChildIndex) && elements[biggerChildIndex].CompareTo(elements[index]) > 0)
            {
                (elements[index], elements[biggerChildIndex]) = (elements[biggerChildIndex], elements[index]);
                index = biggerChildIndex;

                leftChildIndex = index * 2 + 1;
                rightChildIndex = leftChildIndex + 1;

                if (!IsIndexValid(leftChildIndex))
                    return;

                if (!IsIndexValid(rightChildIndex))
                    biggerChildIndex = leftChildIndex;
                else
                    biggerChildIndex = elements[leftChildIndex].CompareTo(elements[rightChildIndex]) > 0 ? leftChildIndex : rightChildIndex;
            }
        }

        private bool IsIndexValid(int index) => index >= 0 && index < elements.Count;
    }
}

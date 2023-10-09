using System;
using System.Collections.Generic;
using System.Text;

namespace _03.MinHeap
{
    public class MinHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        protected List<T> elements;

        public MinHeap()
        {
            this.elements = new List<T>();
        }

        public int Size => elements.Count;

        public void Add(T element)
        {
            elements.Add(element);
            HeapifyUp(elements.Count - 1);
        }

        public T ExtractMin()
        {
            if (elements.Count == 0)
                throw new InvalidOperationException("Min Heap is empty!");

            T extracted = elements[0];

            (elements[0], elements[Size - 1]) = (elements[Size - 1], elements[0]);
            elements.RemoveAt(elements.Count - 1);
            HeapifyDown(0);

            return extracted;
        }

        public T Peek()
        {
            if (elements.Count == 0)
                throw new InvalidOperationException("Min Heap is empty!");

            return elements[0];
        }

        protected void HeapifyUp(int index)
        {
            int parentIndex = (index - 1) / 2;

            while (IsIndexValid(index) && IsIndexValid(parentIndex) && elements[parentIndex].CompareTo(elements[index]) > 0)
            {
                (elements[index], elements[parentIndex]) = (elements[parentIndex], elements[index]);

                index = parentIndex;
                parentIndex = (index - 1) / 2;
            }
        }

        protected void HeapifyDown(int index)
        {
            int firstChildIndex = index * 2 + 1;
            int secondChildIndex = firstChildIndex + 1;

            int smallerChildIndex;

            if (!IsIndexValid(firstChildIndex))
                smallerChildIndex = -1;
            else if (!IsIndexValid(secondChildIndex))
                smallerChildIndex = firstChildIndex ;
            else
                smallerChildIndex = elements[firstChildIndex].CompareTo(elements[secondChildIndex]) < 0
                    ? firstChildIndex : secondChildIndex;

            while (IsIndexValid(index) && IsIndexValid(smallerChildIndex) && elements[smallerChildIndex].CompareTo(elements[index]) < 0)
            {
                (elements[index], elements[smallerChildIndex]) = (elements[smallerChildIndex], elements[index]);

                index = smallerChildIndex;
                firstChildIndex = index * 2 + 1;
                secondChildIndex = firstChildIndex + 1;

                if (!IsIndexValid(firstChildIndex))
                    smallerChildIndex = -1;
                else if (!IsIndexValid(secondChildIndex))
                    smallerChildIndex = firstChildIndex;
                else
                    smallerChildIndex = elements[firstChildIndex].CompareTo(elements[secondChildIndex]) < 0
                        ? firstChildIndex : secondChildIndex;
            }
        }

        private bool IsIndexValid(int index) => index >= 0 && index < elements.Count;
    }
}

namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private class Node
        {
            public Node(T element, Node next)
            {
                Element = element;
                Next = next;
            }

            public T Element { get; set; }

            public Node Next { get; set; }
        }

        private Node head;

        public int Count { get; private set; }

        public void Enqueue(T item)
        {
            Count++;

            if (head == null)
            {
                head = new Node(item, null);
                return;
            }

            Node node = head;

            while (node.Next != null)
            {
                node = node.Next;
            }

            node.Next = new Node(item, null);
        }

        public T Dequeue()
        {
            ValidateNotEmpty();

            T dequeued = head.Element;
            head = head.Next;
            Count--;

            return dequeued;
        }

        public T Peek()
        {
            ValidateNotEmpty();
            return head.Element;
        }

        public bool Contains(T item)
        {
            Node node = head;

            while (node != null)
            {
                if (node.Element.Equals(item))
                    return true;

                node = node.Next;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node node = head;

            while (node != null)
            {
                yield return node.Element;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void ValidateNotEmpty()
        {
            if (head == null)
                throw new InvalidOperationException("Queue is empty!");
        }
    }
}
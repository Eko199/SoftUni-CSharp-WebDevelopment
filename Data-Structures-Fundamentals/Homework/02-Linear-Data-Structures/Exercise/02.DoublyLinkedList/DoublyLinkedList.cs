namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private class Node
        {
            public Node(T value)
            {
                Value = value;
            }

            public T Value { get; set; }
            public Node Next { get; set; }
            public Node Previous { get; set; }
        }

        private Node head, tail;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var node = new Node(item);

            if (Count++ == 0)
            {
                head = tail = node;
                return;
            }

            node.Next = head;
            head.Previous = node;
            head = node;
        }

        public void AddLast(T item)
        {
            var node = new Node(item);

            if (Count++ == 0)
            {
                head = tail = node;
                return;
            }

            node.Previous = tail;
            tail.Next = node;
            tail = node;
        }

        public T GetFirst()
        {
            ValidateNotEmpty();
            return head.Value;
        }

        public T GetLast()
        {
            ValidateNotEmpty();
            return tail.Value;
        }

        public T RemoveFirst()
        {
            ValidateNotEmpty();

            T first = head.Value;
            Count--;

            if (Count == 0)
            {
                head = tail = null;
                return first;
            }

            head = head.Next;
            head.Previous = null;

            return first;
        }

        public T RemoveLast()
        {
            ValidateNotEmpty();

            T last = tail.Value;
            Count--;

            if (Count == 0)
            {
                head = tail = null;
                return last;
            }

            tail = tail.Previous;
            tail.Next = null;

            return last;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node node = head;

            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void ValidateNotEmpty()
        {
            if (Count == 0)
                throw new InvalidOperationException("Doubly Linked List is empty!");
        }
    }
}
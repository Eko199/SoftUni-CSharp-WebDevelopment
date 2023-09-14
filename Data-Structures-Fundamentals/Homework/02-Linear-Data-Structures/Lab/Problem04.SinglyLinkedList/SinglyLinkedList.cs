namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
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

        public int Count { get; set; }

        public void AddFirst(T item)
        {
            var newHead = new Node(item, head);
            head = newHead;
            Count++;
        }

        public void AddLast(T item)
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

        public T GetFirst()
        {
            ValidateNotEmpty();
            return head.Element;
        }

        public T GetLast()
        {
            ValidateNotEmpty();

            Node node = head;

            while (node.Next != null)
            {
                node = node.Next;
            }

            return node.Element;
        }

        public T RemoveFirst()
        {
            ValidateNotEmpty();

            T removed = head.Element;
            head = head.Next;
            Count--;

            return removed;
        }

        public T RemoveLast()
        {
            ValidateNotEmpty();

            T last;

            if (Count-- == 1)
            {
                last = head.Element;
                head = null;
                return last;
            }

            Node node = head;

            while (node.Next.Next != null)
            {
                node = node.Next;
            }

            last = node.Next.Element;
            node.Next = null;

            return last;
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
                throw new InvalidOperationException("Singly Linked List is empty!");
        }
    }
}
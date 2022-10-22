using System;

namespace CustomDoublyLinkedList
{
    internal class DoublyLinkedList<T>
    {
        private class ListNode
        {
            public ListNode(T value)
            {
                Value = value;
            }

            public T Value { get; set; }
            public ListNode NextNode { get; set; }
            public ListNode PreviousNode { get; set; }
        }

        private ListNode head;
        private ListNode tail;

        public int Count { get; private set; }

        public void AddFirst(T element)
        {
            if (Count == 0)
                head = tail = new ListNode(element);
            else
            {
                var newHead = new ListNode(element);
                head.PreviousNode = newHead;
                newHead.NextNode = head;
                head = newHead;
            }

            Count++;
        }

        public void AddLast(T element)
        {
            if (Count == 0)
                head = tail = new ListNode(element);
            else
            {
                var newTail = new ListNode(element);
                tail.NextNode = newTail;
                newTail.PreviousNode = tail;
                tail = newTail;
            }

            Count++;
        }

        public T RemoveFirst()
        {
            if (Count == 0)
                throw new InvalidOperationException("The list is empty");

            T result = head.Value;
            head = head.NextNode;

            if (head == null)
                tail = null;
            else
                head.PreviousNode = null;

            Count--;
            return result;
        }

        public T RemoveLast()
        {
            if (Count == 0)
                throw new InvalidOperationException("The list is empty");

            T result = tail.Value;
            tail = tail.PreviousNode;

            if (tail == null)
                head = null;
            else
                tail.NextNode = null;

            Count--;
            return result;
        }

        public void ForEach(Action<T> action)
        {
            ListNode currentNode = head;
            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }

        public T[] ToArray()
        {
            T[] arr = new T[Count];

            int i = 0;
            ForEach(node => arr[i++] = node);

            return arr;
        }
    }
}

using System;

namespace CustomDoublyLinkedList
{
    internal class DoublyLinkedList
    {
        private class ListNode
        {
            public ListNode(int value)
            {
                Value = value;
            }

            public int Value { get; set; }
            public ListNode NextNode { get; set; }
            public ListNode PreviousNode { get; set; }
        }

        private ListNode head;
        private ListNode tail;

        public int Count { get; private set; }

        public void AddFirst(int element)
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

        public void AddLast(int element)
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

        public int RemoveFirst()
        {
            if (Count == 0)
                throw new InvalidOperationException("The list is empty");

            int result = head.Value;
            head = head.NextNode;

            if (head == null)
                tail = null;
            else
                head.PreviousNode = null;

            Count--;
            return result;
        }

        public int RemoveLast()
        {
            if (Count == 0)
                throw new InvalidOperationException("The list is empty");

            int result = tail.Value;
            tail = tail.PreviousNode;

            if (tail == null)
                head = null;
            else
                tail.NextNode = null;

            Count--;
            return result;
        }

        public void ForEach(Action<int> action)
        {
            ListNode currentNode = head;
            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }

        public int[] ToArray()
        {
            int[] arr = new int[Count];

            int i = 0;
            ForEach(node => arr[i++] = node);

            return arr;
        }
    }
}

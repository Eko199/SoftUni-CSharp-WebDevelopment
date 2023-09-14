namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
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

        private Node top;

        public int Count { get; private set; }

        public void Push(T item)
        {
            Node oldTop = top;
            top = new Node(item, oldTop);
            Count++;
        }

        public T Pop()
        {
            if (top == null)
                throw new InvalidOperationException("Stack is empty!");

            T popped = top.Element;
            top = top.Next;
            Count--;

            return popped;
        }

        public T Peek()
        {
            if (top == null)
                throw new InvalidOperationException("Stack is empty!");

            return top.Element;
        }

        public bool Contains(T item)
        {
            Node node = top;

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
            Node node = top;

            while (node != null)
            {
                yield return node.Element;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
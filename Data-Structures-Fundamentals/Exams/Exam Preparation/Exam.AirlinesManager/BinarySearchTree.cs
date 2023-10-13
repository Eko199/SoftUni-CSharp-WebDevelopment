namespace _02.BinarySearchTree
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class BinarySearchTree<T>
    {
        private class Node
        {
            public Node(T value)
            {
                this.Value = value;
            }

            public T Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public int Count { get; set; }
        }

        private Node root;
        private readonly IComparer<T> comparer;

        private BinarySearchTree(Node node, IComparer<T> comparer)
        {
            this.PreOrderCopy(node);
            this.comparer = comparer;
        }

        public BinarySearchTree(IComparer<T> comparer)
        {
            this.comparer = comparer;
        }

        public void Insert(T element)
        {
            this.root = this.Insert(element, this.root);
        }

        public bool Contains(T element)
        {
            Node current = this.FindElement(element);

            return current != null;
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(this.root, action);
        }

        public BinarySearchTree<T> Search(T element)
        {
            Node current = this.FindElement(element);

            return new BinarySearchTree<T>(current, this.comparer);
        }

        public void Delete(T element)
        {
            if (this.root is null)
                throw new InvalidOperationException("BST is empty!");

            this.root = Delete(element, this.root);
        }

        public void DeleteMax()
        {
            if (this.root is null)
                throw new InvalidOperationException("BST is empty!");

            this.root = DeleteMax(this.root);
        }

        public void DeleteMin()
        {
            if (this.root is null)
                throw new InvalidOperationException("BST is empty!");

            this.root = DeleteMin(this.root);
        }

        public int Count()
        {
            if (this.root is null)
                return 0;

            return 1 + this.root.Count;
        }

        public int Rank(T element) => Rank(element, this.root);

        public T Select(int rank)
        {
            if (this.root is null)
                throw new InvalidOperationException("BST is empty!");

            int count = 0;
            Node result = Select(rank, this.root, ref count) 
                          ?? throw new InvalidOperationException("Not such element.");

            return result.Value;
        }

        public T Ceiling(T element) => Select(Rank(element) + 1);

        public T Floor(T element) => Select(Rank(element) - 1);

        public IEnumerable<T> Range(T startRange, T endRange)
        {
            var result = new List<T>();

            EachInOrder(n =>
            {
                if (this.comparer.Compare(n, startRange) >= 0 && this.comparer.Compare(n, endRange) <= 0)
                {
                    result.Add(n);
                }
            });

            return result;
        }

        private static Node DeleteMax(Node node)
        {
            node.Count--;
            if (node.Right is null)
                return node.Left;

            node.Right = DeleteMax(node.Right);
            return node;
        }

        private static Node DeleteMin(Node node)
        {
            node.Count--;
            if (node.Left is null)
                return node.Right;

            node.Left = DeleteMin(node.Left);
            return node;
        }

        private static Node Select(int rank, Node node, ref int count)
        {
            if (node is null)
                return null;

            Node current = Select(rank, node.Left, ref count);

            if (current != null)
                return current;

            if (count++ == rank)
                return node;

            current = Select(rank, node.Right, ref count);

            return current;
        }

        private Node Delete(T element, Node node)
        {
            int comparison = this.comparer.Compare(node.Value, element);

            if (comparison == 0)
            {
                if (node.Left is null && node.Right is null)
                    return null;

                if (node.Left != null && node.Right is null)
                    return node.Left;

                if (node.Left is null)
                    return node.Right;

                Node nextNode = node.Right;
                T nextInOrderValue;

                if (nextNode.Left is null)
                {
                    nextInOrderValue = nextNode.Value;
                    node.Right = nextNode.Right;
                }
                else
                {
                    while (nextNode.Left.Left != null)
                    {
                        nextNode.Count--;
                        nextNode = nextNode.Left;
                    }

                    nextNode.Count--;
                    nextInOrderValue = nextNode.Left.Value;
                    nextNode.Left = null;
                }

                node.Value = nextInOrderValue;
            }
            else if (comparison > 0)
            {
                node.Left = Delete(element, node.Left);
            }
            else
            {
                node.Right = Delete(element, node.Right);
            }

            node.Count--;
            return node;
        }

        private int Rank(T element, Node node)
        {
            if (node is null)
                return 0;

            int comparison = this.comparer.Compare(node.Value, element);
            int leftCount = node.Left is null ? 0 : node.Left.Count + 1;

            if (comparison == 0)
                return leftCount;

            if (comparison < 0)
                return 1 + leftCount + Rank(element, node.Right);

            return Rank(element, node.Left);
        }

        private Node FindElement(T element)
        {
            Node current = this.root;

            while (current != null)
            {
                int comparison = this.comparer.Compare(current.Value, element);

                if (comparison > 0)
                {
                    current = current.Left;
                }
                else if (comparison < 0)
                {
                    current = current.Right;
                }
                else
                {
                    break;
                }
            }

            return current;
        }

        private void PreOrderCopy(Node node)
        {
            if (node == null)
                return;

            this.Insert(node.Value);
            this.PreOrderCopy(node.Left);
            this.PreOrderCopy(node.Right);
        }

        private Node Insert(T element, Node node)
        {
            if (node == null)
            {
                node = new Node(element);
            }
            else if (this.comparer.Compare(element, node.Value) < 0)
            {
                node.Left = this.Insert(element, node.Left);
                node.Count++;
            }
            else if (this.comparer.Compare(element, node.Value) >= 0)
            {
                node.Right = this.Insert(element, node.Right);
                node.Count++;
            }

            return node;
        }

        private void EachInOrder(Node node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            this.EachInOrder(node.Left, action);
            action(node.Value);
            this.EachInOrder(node.Right, action);
        }
    }
}

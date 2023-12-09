namespace AA_Tree
{
    using System;

    public class AATree<T> : IBinarySearchTree<T>
        where T : IComparable<T>
    {
        private class Node
        {
            public Node(T element)
            {
                this.Value = element;
                this.Level = 0;
            }

            public T Value { get; set; }
            public Node Right { get; set; }
            public Node Left { get; set; }
            public int Level { get; set; }
        }

        private Node root;

        public int Count() => Count(root);

        public void Insert(T element) => root = Insert(root, element);

        private static Node Insert(Node node, T value)
        {
            if (node is null)
            {
                return new Node(value);
            }

            if (value.CompareTo(node.Value) < 0)
            {
                node.Left = Insert(node.Left, value);
            }
            else
            {
                node.Right = Insert(node.Right, value);
            }

            node = Skew(node);
            node = Split(node);
            return node;
        }

        private static Node Skew(Node node)
        {
            if (node.Left == null || node.Left.Level != node.Level)
            {
                return node;
            }

            Node temp = node.Left;
            node.Left = temp.Right;
            temp.Right = node;

            return temp;
        }

        private static Node Split(Node node)
        {
            if (node.Right?.Right is null || node.Right.Right.Level != node.Level)
            {
                return node;
            }

            Node temp = node.Right;
            node.Right = temp.Left;
            temp.Left = node;
            temp.Level++;

            return temp;
        }

        public bool Contains(T element) => FindNode(element) != null;

        public void InOrder(Action<T> action) => InOrder(root, action);

        public void PreOrder(Action<T> action) => PreOrder(root, action);

        public void PostOrder(Action<T> action) => PostOrder(root, action);

        private static int Count(Node node)
        {
            if (node is null)
            {
                return 0;
            }

            return 1 + Count(node.Left) + Count(node.Right);
        }

        private static void InOrder(Node node, Action<T> action)
        {
            if (node is null)
            {
                return;
            }

            InOrder(node.Left, action);
            action(node.Value);
            InOrder(node.Right, action);
        }

        private static void PreOrder(Node node, Action<T> action)
        {
            if (node is null)
            {
                return;
            }

            action(node.Value);
            PreOrder(node.Left, action);
            PreOrder(node.Right, action);
        }

        private static void PostOrder(Node node, Action<T> action)
        {
            if (node is null)
            {
                return;
            }

            PostOrder(node.Left, action);
            PostOrder(node.Right, action);
            action(node.Value);
        }

        private Node FindNode(T element)
        {
            Node node = root;

            while (node != null)
            {
                int comparison = element.CompareTo(node.Value);

                if (comparison < 0)
                {
                    node = node.Left;
                }
                else if (comparison > 0)
                {
                    node = node.Right;
                }
                else
                {
                    return node;
                }
            }

            return null;
        }
    }
}
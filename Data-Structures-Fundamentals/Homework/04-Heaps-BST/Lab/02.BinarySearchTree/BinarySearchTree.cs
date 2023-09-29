namespace _02.BinarySearchTree
{
    using System;

    public class BinarySearchTree<T> : IBinarySearchTree<T>
        where T : IComparable<T>
    {
        private class Node
        {
            public Node(T value)
            {
                Value = value;
            }

            public T Value { get; }
            public Node Left { get; set; }
            public Node Right { get; set; }
        }

        private Node root;

        public BinarySearchTree() { }

        private BinarySearchTree(Node root)
        {
            PreOrderCopy(root);
        }

        public bool Contains(T element) => Search(element) != null;

        public void EachInOrder(Action<T> action) => EachInOrder(root, action);

        public void Insert(T element) => root = Insert(root, element);

        public IBinarySearchTree<T> Search(T element)
        {
            Node node = root;

            while (node != null)
            {
                int comparison = node.Value.CompareTo(element);

                if (comparison == 0)
                    return new BinarySearchTree<T>(node);

                node = comparison > 0 ? node.Left : node.Right;
            }

            return null;
        }

        private static Node Insert(Node node, T element)
        {
            if (node is null)
                return new Node(element);

            int comparison = node.Value.CompareTo(element);

            if (comparison > 0)
                node.Left = Insert(node.Left, element);
            else
                node.Right = Insert(node.Right, element);

            return node;
        }

        private static void EachInOrder(Node node, Action<T> action)
        {
            if (node.Left != null)
                EachInOrder(node.Left, action);

            action(node.Value);

            if (node.Right != null)
                EachInOrder(node.Right, action);
        }

        private void PreOrderCopy(Node node)
        {
            Insert(node.Value);

            if (node.Left != null)
                PreOrderCopy(node.Left);

            if (node.Right != null)
                PreOrderCopy(node.Right);
        }
    }
}

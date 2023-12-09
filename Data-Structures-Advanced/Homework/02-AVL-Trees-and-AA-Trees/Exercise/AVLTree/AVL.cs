namespace AVLTree
{
    using System;

    public class AVL<T> where T : IComparable<T>
    {
        public class Node
        {
            public Node(T value)
            {
                this.Value = value;
                this.Height = 1;
            }

            public T Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public int Height { get; set; }
        }

        public Node Root { get; private set; }

        public bool Contains(T element) => FindNode(element) != null;

        public void Delete(T element) => Root = Delete(Root, element);

        public void DeleteMin()
        {
            if (Root != null)
            {
                Delete(FindMin(Root).Value);
            }
        }

        public void Insert(T element) => Root = Insert(Root, element);

        public void EachInOrder(Action<T> action) => EachInOrder(Root, action);

        private Node FindNode(T element)
        {
            Node node = Root;

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
                    break;
                }
            }

            return node;
        }

        private static int Height(Node node) => node?.Height ?? 0;

        private static void UpdateHeight(Node node) 
            => node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;

        private static Node RotateLeft(Node node)
        {
            Node temp = node.Right;
            node.Right = temp.Left;
            temp.Left = node;

            UpdateHeight(node);
            return temp;
        }

        private static Node RotateRight(Node node)
        {
            Node temp = node.Left;
            node.Left = temp.Right;
            temp.Right = node;

            UpdateHeight(node);
            return temp;
        }

        private static Node Balance(Node node)
        {
            int balanceFactor = Height(node.Left) - Height(node.Right);

            if (balanceFactor > 1)
            {
                if (Height(node.Left.Left) - Height(node.Left.Right) < 0)
                {
                    node.Left = RotateLeft(node.Left);
                }

                node = RotateRight(node);
            }
            else if (balanceFactor < -1)
            {
                if (Height(node.Right.Left) - Height(node.Right.Right) > 0)
                {
                    node.Right = RotateRight(node.Right);
                }

                node = RotateLeft(node);
            }

            return node;
        }

        private static Node Insert(Node node, T element)
        {
            if (node is null)
            {
                return new Node(element);
            }

            if (element.CompareTo(node.Value) < 0)
            {
                node.Left = Insert(node.Left, element);
            }
            else
            {
                node.Right = Insert(node.Right, element);
            }

            node = Balance(node);
            UpdateHeight(node);
            return node;
        }

        private static Node FindMin(Node node) => !(node.Left is null) ? FindMin(node.Left) : node;

        private static Node Delete(Node node, T element)
        {
            if (node is null)
            {
                return null;
            }

            int comparison = element.CompareTo(node.Value);

            if (comparison < 0)
            {
                node.Left = Delete(node.Left, element);
            }
            else if (comparison > 0)
            {
                node.Right = Delete(node.Right, element);
            }
            else if (node.Left is null)
            {
                return node.Right;
            }
            else if (node.Right is null)
            {
                return node.Left;
            }
            else
            {
                Node smallestNode = FindMin(node.Right);
                node.Value = smallestNode.Value;
                node.Right = Delete(node.Right, smallestNode.Value);
            }

            node = Balance(node);
            UpdateHeight(node);
            return node;
        }

        private static void EachInOrder(Node node, Action<T> action)
        {
            if (node is null)
            {
                return;
            }

            EachInOrder(node.Left, action);
            action(node.Value);
            EachInOrder(node.Right, action);
        }
    }
}

namespace _01.RedBlackTree
{
    using System;

    public class RedBlackTree<T> where T : IComparable
    {
        public const bool Red = true;
        public const bool Black = false;

        public class Node
        {
            public Node(T value)
            {
                this.Value = value;
                this.Color = Red;
            }

            public T Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public bool Color { get; set; }
        }

        public Node root;

        public RedBlackTree() { }

        private RedBlackTree(Node node)
        {
            PreOrderCopy(node);
        }

        public void EachInOrder(Action<T> action) => EachInOrder(root, action);

        public RedBlackTree<T> Search(T element) => new RedBlackTree<T>(FindNode(element));

        public void Insert(T value)
        {
            root = Insert(root, value);
            root.Color = Black;
        }

        public bool Contains(T element) => FindNode(element) != null;

        public void Delete(T key)
        {
            if (root is null)
                throw new InvalidOperationException("Red-Black Tree is empty!");

            root = Delete(root, key);

            if (IsRed(root))
                root.Color = Black;
        }

        public void DeleteMin()
        {
            if (root is null)
                throw new InvalidOperationException("Red-Black Tree is empty!");

            root = DeleteMin(root);

            if (IsRed(root))
                root.Color = Black;
        }

        public void DeleteMax()
        {
            if (root is null)
                throw new InvalidOperationException("Red-Black Tree is empty!");

            root = DeleteMax(root);

            if (IsRed(root))
                root.Color = Black;
        }

        public int Count() => Count(root);

        private static bool IsRed(Node node) => node != null && node.Color == Red;

        //Rotations
        private static Node RotateLeft(Node node)
        {
            Node temp = node.Right;
            node.Right = temp.Left;
            temp.Left = node;
            (node.Color, temp.Color) = (temp.Color, node.Color);

            return temp;
        }

        private static Node RotateRight(Node node)
        {
            Node temp = node.Left;
            node.Left = temp.Right;
            temp.Right = node;
            (node.Color, temp.Color) = (temp.Color, node.Color);

            return temp;
        }

        private static void ColorFlip(Node node)
        {
            node.Color = !node.Color;

            if (node.Left != null)
                node.Left.Color = !node.Left.Color;

            if (node.Right != null)
                node.Right.Color = !node.Right.Color;
        }

        private static Node MoveRedLeft(Node node)
        {
            ColorFlip(node);

            if (IsRed(node.Right.Left))
            {
                node.Right = RotateRight(node.Right);
                node = RotateLeft(node);
                ColorFlip(node);
            }

            return node;
        }

        private static Node MoveRedRight(Node node)
        {
            ColorFlip(node);

            if (IsRed(node.Left.Left))
            {
                node = RotateRight(node);
                ColorFlip(node);
            }

            return node;
        }

        private static Node FixUp(Node node)
        {
            if (IsRed(node.Right))
            {
                node = RotateLeft(node);
            }

            if (IsRed(node.Left) && IsRed(node.Left.Left))
            {
                node = RotateRight(node);
            }

            if (IsRed(node.Left) && IsRed(node.Right))
            {
                ColorFlip(node);
            }

            return node;
        }

        private static void EachInOrder(Node node, Action<T> action)
        {
            if (node == null) return;

            EachInOrder(node.Left, action);
            action(node.Value);
            EachInOrder(node.Right, action);
        }

        private static Node Delete(Node node, T key)
        {
            if (node is null)
                return null;

            if (key.CompareTo(node.Value) < 0)
            {
                if (!IsRed(node.Left) && !IsRed(node.Left.Left))
                    node = MoveRedLeft(node);

                node.Left = Delete(node.Left, key);
            }
            else
            {
                if (IsRed(node.Left))
                    node = RotateRight(node);

                if (key.CompareTo(node.Value) == 0 && node.Right is null)
                    return null;

                if (!IsRed(node.Right) && !IsRed(node.Right.Left))
                    node = MoveRedRight(node);

                if (key.CompareTo(node.Value) == 0)
                {
                    node.Value = FindMin(node.Right);
                    node.Right = DeleteMin(node.Right);
                }
                else
                {
                    node.Right = Delete(node.Right, key);
                }
            }

            return FixUp(node);
        }

        private static Node DeleteMin(Node node)
        {
            if (node.Left is null)
                return null;

            if (!IsRed(node.Left) && !IsRed(node.Left.Left))
                node = MoveRedLeft(node);

            node.Left = DeleteMin(node.Left);

            return FixUp(node);
        }

        private static Node DeleteMax(Node node)
        {
            if (IsRed(node.Left))
                node = RotateRight(node);

            if (node.Right is null)
                return null;

            if (!IsRed(node.Right) && !IsRed(node.Right.Left))
                node = MoveRedRight(node);

            node.Right = DeleteMax(node.Right);
            return FixUp(node);
        }

        private static int Count(Node node)
        {
            if (node == null)
                return 0;

            return 1 + Count(node.Left) + Count(node.Right);
        }

        private static Node Insert(Node node, T value)
        {
            if (node == null)
                return new Node(value);

            if (value.CompareTo(node.Value) < 0)
            {
                node.Left = Insert(node.Left, value);
            }
            else
            {
                node.Right = Insert(node.Right, value);
            }

            return FixUp(node);
        }

        private Node FindNode(T value)
        {
            Node current = root;

            while (current != null)
            {
                int comparison = value.CompareTo(current.Value);

                if (comparison > 0)
                {
                    current = current.Right;
                    continue;
                }

                if (comparison < 0)
                {
                    current = current.Left;
                    continue;
                }

                break;
            }

            return current;
        }

        private static T FindMin(Node node) => node.Left is null ? node.Value : FindMin(node.Left);

        private void PreOrderCopy(Node node)
        {
            if (node == null)
                return;

            Insert(node.Value);
            PreOrderCopy(node.Left);
            PreOrderCopy(node.Right);
        }
    }
}
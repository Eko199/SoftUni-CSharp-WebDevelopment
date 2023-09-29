namespace _01.BinaryTree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
    {
        public BinaryTree(T element, IAbstractBinaryTree<T> left, IAbstractBinaryTree<T> right)
        {
            Value = element;
            LeftChild = left;
            RightChild = right;
        }

        public T Value { get; }

        public IAbstractBinaryTree<T> LeftChild { get; }

        public IAbstractBinaryTree<T> RightChild { get; }

        public string AsIndentedPreOrder(int indent)
        {
            var sb = new StringBuilder();

            AsIndentedPreOrder(sb, this, indent);

            return sb.ToString().Trim();
        }

        public void ForEachInOrder(Action<T> action)
        {
            LeftChild?.ForEachInOrder(action);
            action(Value);
            RightChild?.ForEachInOrder(action);
        }

        public IEnumerable<IAbstractBinaryTree<T>> InOrder()
        {
            var result = new List<IAbstractBinaryTree<T>>();

            if (LeftChild != null)
                result.AddRange(LeftChild.InOrder());

            result.Add(this);

            if (RightChild != null)
                result.AddRange(RightChild.InOrder());

            return result;
        }

        public IEnumerable<IAbstractBinaryTree<T>> PostOrder()
        {
            var result = new List<IAbstractBinaryTree<T>>();

            if (LeftChild != null)
                result.AddRange(LeftChild.PostOrder());

            if (RightChild != null)
                result.AddRange(RightChild.PostOrder());

            result.Add(this);

            return result;
        }

        public IEnumerable<IAbstractBinaryTree<T>> PreOrder()
        {
            var result = new List<IAbstractBinaryTree<T>> { this };

            if (LeftChild != null)
                result.AddRange(LeftChild.PreOrder());

            if (RightChild != null)
                result.AddRange(RightChild.PreOrder());

            return result;
        }

        private static void AsIndentedPreOrder(StringBuilder sb, IAbstractBinaryTree<T> subtree, int indent)
        {
            sb.Append(' ', indent++ * 2)
                .AppendLine(subtree.Value.ToString());

            if (subtree.LeftChild != null)
                AsIndentedPreOrder(sb, subtree.LeftChild, indent);

            if (subtree.RightChild != null)
                AsIndentedPreOrder(sb, subtree.RightChild, indent);
        }
    }
}

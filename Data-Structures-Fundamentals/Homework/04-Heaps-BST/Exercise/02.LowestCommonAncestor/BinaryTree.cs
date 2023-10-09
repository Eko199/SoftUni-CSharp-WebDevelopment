namespace _02.LowestCommonAncestor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(
            T value,
            BinaryTree<T> leftChild,
            BinaryTree<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
            if (leftChild != null)
            {
                this.LeftChild.Parent = this;
            }

            if (rightChild != null)
            {
                this.RightChild.Parent = this;
            }
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public BinaryTree<T> Parent { get; set; }

        public T FindLowestCommonAncestor(T first, T second)
        {
            BinaryTree<T> firstNode = FindNode(first);
            BinaryTree<T> secondNode = FindNode(second);

            if (firstNode is null || secondNode is null)
                throw new InvalidOperationException("Nodes are not present in the binary tree!");

            return firstNode.GetAncestors().Intersect(secondNode.GetAncestors()).First();
        }

        public BinaryTree<T> FindNode(T value)
        {
            var queue = new Queue<BinaryTree<T>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                BinaryTree<T> current = queue.Dequeue();

                if (current.Value.Equals(value))
                    return current;

                if (current.LeftChild != null)
                    queue.Enqueue(current.LeftChild);
                if (current.RightChild != null)
                    queue.Enqueue(current.RightChild);
            }

            return null;
        }

        private IEnumerable<T> GetAncestors()
        {
            var ancestorQueue = new Queue<T>();
            var tree = this;

            while (tree != null)
            {
                ancestorQueue.Enqueue(tree.Value);
                tree = tree.Parent;
            }

            return ancestorQueue;
        }
    }
}

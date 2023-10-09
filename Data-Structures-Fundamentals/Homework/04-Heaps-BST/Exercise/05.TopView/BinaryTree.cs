namespace _05.TopView
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(T value, BinaryTree<T> left, BinaryTree<T> right)
        {
            this.Value = value;
            this.LeftChild = left;
            this.RightChild = right;
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public List<T> TopView()
        {
            int maxLeft = 1, maxRight = 0;
            var result = new List<T>();
            var queue = new Queue<(BinaryTree<T> node, int dir)>();
            queue.Enqueue((this, 0));

            while (queue.Count > 0)
            {
                var (node, dir) = queue.Dequeue();

                if (dir < maxLeft)
                {
                    maxLeft = dir;
                    result.Add(node.Value);
                }
                else if (dir > maxRight)
                {
                    maxRight = dir;
                    result.Add(node.Value);
                }

                if (node.LeftChild != null)
                    queue.Enqueue((node.LeftChild, dir - 1));

                if (node.RightChild != null)
                    queue.Enqueue((node.RightChild, dir + 1));
            }

            return result;
        }
    }
}

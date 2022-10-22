using System;

namespace GenericScale
{
    internal class EqualityScale<T>
    {
        private T left;
        private T right;

        public EqualityScale(T left, T right)
        {
            this.left = left;
            this.right = right;
        }

        public bool AreEqual() => left.Equals(right);
    }
}

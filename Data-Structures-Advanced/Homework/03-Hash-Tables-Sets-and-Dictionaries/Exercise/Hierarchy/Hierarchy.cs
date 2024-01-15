namespace Hierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;

    public class Hierarchy<T> : IHierarchy<T>
    {
        private readonly ISet<T> elements = new HashSet<T>();
        private readonly IDictionary<T, T> elementParents = new Dictionary<T, T>();
        private readonly IDictionary<T, ISet<T>> elementChildren = new Dictionary<T, ISet<T>>();

        private readonly T Root;

        public Hierarchy(T value)
        {
            Root = value;
            elements.Add(value);
            elementChildren.Add(value, new HashSet<T>());
        }

        public int Count => elements.Count;

        public void Add(T element, T child)
        {
            if (!Contains(element) || Contains(child))
            {
                throw new ArgumentException();
            }

            elements.Add(child);
            elementParents.Add(child, element);
            elementChildren[element].Add(child);
            elementChildren.Add(child, new HashSet<T>());
        }

        public bool Contains(T element) => elements.Contains(element);

        public IEnumerable<T> GetChildren(T element)
        {
            if (!Contains(element))
            {
                throw new ArgumentException();
            }

            return elementChildren[element];
        }

        public IEnumerable<T> GetCommonElements(Hierarchy<T> other) => elements.Intersect(other.elements);

        public IEnumerator<T> GetEnumerator()
        {
            var queue = new Queue<T>();
            queue.Enqueue(Root);

            while (queue.Any())
            {
                T current = queue.Dequeue();
                yield return current;

                foreach (T child in elementChildren[current])
                {
                    queue.Enqueue(child);
                }
            }
        }

        public T GetParent(T element)
        {
            if (!Contains(element))
            {
                throw new ArgumentException();
            }

            return element.Equals(Root) ? default : elementParents[element];
        }

        public void Remove(T element)
        {
            if (element.Equals(Root))
            {
                throw new InvalidOperationException();
            }

            if (!Contains(element))
            {
                throw new ArgumentException();
            }

            elements.Remove(element);
            elementChildren[elementParents[element]].Remove(element);

            foreach (T child in elementChildren[element])
            {
                elementChildren[elementParents[element]].Add(child);
                elementParents[child] = elementParents[element];
            }

            elementParents.Remove(element);
            elementChildren.Remove(element);
        }

        public void ForEach(Action<T> action)
        {
            foreach (T element in this)
            {
                action(element);
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
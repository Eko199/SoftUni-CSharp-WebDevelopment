using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ListyIterator
{
    internal class ListyIterator<T> : IEnumerable<T>
    {
        private int currentIndex;
        private readonly List<T> elements;

        public ListyIterator(IEnumerable<T> collection)
        {
            elements = collection.ToList();
            currentIndex = 0;
        }

        public bool Move() {
            if (currentIndex + 1 >= elements.Count) 
                return false;

            currentIndex++;
            return true;
        }

        public bool HasNext() => currentIndex + 1 < elements.Count;
        
        public void Print()
        {
            if (elements.Count == 0)
                throw new InvalidOperationException("Invalid Operation!");

            Console.WriteLine(elements[currentIndex]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < elements.Count; i++)
                yield return elements[i];
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

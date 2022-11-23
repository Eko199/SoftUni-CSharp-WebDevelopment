namespace CollectionHierarchy.Models
{
    using System.Collections.Generic;

    using Interfaces;

    public class AddCollection : IAddCollection
    {
        private readonly Stack<string> elements;

        public AddCollection()
        {
            elements = new Stack<string>(100);
        }

        public int Add(string str)
        {
            elements.Push(str);
            return elements.Count - 1;
        }
    }
}

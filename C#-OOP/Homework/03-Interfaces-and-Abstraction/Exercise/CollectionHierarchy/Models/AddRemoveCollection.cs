namespace CollectionHierarchy.Models
{
    using System.Collections.Generic;

    using Interfaces;

    public class AddRemoveCollection : IAddRemoveCollection
    {
        private readonly LinkedList<string> elements;

        public AddRemoveCollection()
        {
            elements = new LinkedList<string>();
        }

        public int Add(string str)
        {
            elements.AddFirst(str);
            return 0;
        }

        public string Remove()
        {
            string removed = elements.Last.Value;
            elements.RemoveLast();
            return removed;
        }
    }
}

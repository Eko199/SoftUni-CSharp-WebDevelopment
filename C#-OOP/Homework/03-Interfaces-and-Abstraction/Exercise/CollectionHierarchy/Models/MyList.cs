namespace CollectionHierarchy.Models
{
    using System.Collections.Generic;

    using Interfaces;

    public class MyList : IAddRemoveCollection
    {
        private readonly Stack<string> elements;

        public MyList()
        {
            elements = new Stack<string>(100);
        }

        public int Used => elements.Count;

        public int Add(string str)
        {
            elements.Push(str);
            return 0;
        }

        public string Remove()
        {
            return elements.Pop();
        }
    }
}

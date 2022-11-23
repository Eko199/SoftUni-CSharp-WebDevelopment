namespace CollectionHierarchy
{
    using System;
    
    using Models;
    using Models.Interfaces;

    public class Program
    {
        static void Main(string[] args)
        {
            IAddCollection addCollection = new AddCollection();
            IAddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            IAddRemoveCollection myList = new MyList();

            string[] strings = Console.ReadLine().Split();
            int removeOperations = int.Parse(Console.ReadLine());

            int[] addResult = new int[strings.Length];
            foreach (IAddCollection iAddCollection in new[] { addCollection, addRemoveCollection, myList })
            {
                for (int i = 0; i < strings.Length; i++)
                {
                    addResult[i] = iAddCollection.Add(strings[i]);
                }

                Console.WriteLine(string.Join(' ', addResult));
            }

            string[] removeResult = new string[removeOperations];
            foreach (IAddRemoveCollection iAddRemoveCollection in new[] { addRemoveCollection, myList })
            {
                for (int i = 0; i < removeOperations; i++)
                {
                    removeResult[i] = iAddRemoveCollection.Remove();
                }

                Console.WriteLine(string.Join(' ', removeResult));
            }
        }
    }
}

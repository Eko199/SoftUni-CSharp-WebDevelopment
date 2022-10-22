using System;

namespace ImplementingList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomList list = new CustomList();

            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }

            list.RemoveAt(4);

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }

            for (int i = 0; i < 100; i++)
            {
                list.Add(i);
            }

            list.Swap(0, 1);
            list.Insert(10, 69);
            Console.WriteLine(list.Contains(69));
            Console.WriteLine(list.Find(x => x % 13 == 7 && x != 0));

            Console.WriteLine(list);
            list.Reverse();
            Console.WriteLine(list);
        }
    }
}

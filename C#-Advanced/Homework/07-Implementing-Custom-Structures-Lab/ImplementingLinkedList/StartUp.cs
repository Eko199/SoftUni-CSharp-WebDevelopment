using System;

namespace CustomDoublyLinkedList
{
    internal class StartUp
    {
        public static void Main(string[] args)
        {
            DoublyLinkedList linkedList = new DoublyLinkedList();

            for (int i = 0; i < 10; i++)
            {
                linkedList.AddFirst(i);
            }
            for (int i = 10; i < 20; i++)
            {
                linkedList.AddLast(i);
            }

            Console.WriteLine($"Fist removed: {linkedList.RemoveFirst()}");
            Console.WriteLine($"Last removed: {linkedList.RemoveLast()}");

            linkedList.ForEach(Console.WriteLine);
            Console.WriteLine(string.Join(", ", linkedList.ToArray()));
        }
    }
}

using System;

namespace CustomDoublyLinkedList
{
    internal class StartUp
    {
        public static void Main(string[] args)
        {
            DoublyLinkedList<double> linkedList = new DoublyLinkedList<double>();

            for (int i = 0; i < 10; i++)
            {
                linkedList.AddFirst(i);
            }
            for (int i = 10; i < 20; i++)
            {
                linkedList.AddLast(i);
            }

            Console.WriteLine($"Fist removed: {linkedList.RemoveFirst():F2}");
            Console.WriteLine($"Last removed: {linkedList.RemoveLast():F2}");

            linkedList.ForEach(Console.WriteLine);
            Console.WriteLine(string.Join(", ", linkedList.ToArray()));
        }
    }
}

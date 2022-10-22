using System;

namespace ImplementingStack
{
    internal class StartUp
    {
        public static void Main(string[] args)
        {
            CustomStack stack = new CustomStack();

            for (int i = 0; i < 100; i++)
            {
                stack.Push(i);
            }

            Console.WriteLine("Popped: " + stack.Pop());
            Console.WriteLine("Peeked: " + stack.Peek());
            stack.ForEach(Console.WriteLine);
        }
    }
}

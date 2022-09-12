using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int rackCapacity = int.Parse(Console.ReadLine()), currentSum = 0, racks = 1;

            while (stack.Count > 0)
            {
                if (currentSum + stack.Peek() <= rackCapacity)
                    currentSum += stack.Pop();
                else
                {
                    currentSum = stack.Pop();
                    racks++;
                }
            }

            Console.WriteLine(racks);
        }
    }
}

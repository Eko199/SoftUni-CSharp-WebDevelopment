using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SimpleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<string>(Console.ReadLine().Split().Reverse());
            int result = int.Parse(stack.Pop());

            while (stack.Count > 0)
            {
                string operation = stack.Pop();
                int number = int.Parse(stack.Pop());

                switch (operation)
                {
                    case "+":
                        result += number;
                        break;
                    case "-":
                        result -= number;
                        break;
                }
            }

            Console.WriteLine(result);
        }
    }
}

using System;
using System.Linq;

namespace Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] tokens = command.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                switch (tokens[0])
                {
                    case "Push":
                        tokens.Skip(1).Select(int.Parse).ToList().ForEach(x => stack.Push(x));
                        break;
                    case "Pop":
                        try
                        {
                            stack.Pop();
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;
                }
            }

            foreach (int item in stack)
                Console.WriteLine(item);
            foreach (int item in stack)
                Console.WriteLine(item);
        }
    }
}

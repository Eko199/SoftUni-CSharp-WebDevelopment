using System;
using System.Collections.Generic;

namespace _06.SongsQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue<string>(Console.ReadLine().Split(", "));

            while (queue.Count > 0)
            {
                string[] commands = Console.ReadLine().Split();
                if (commands.Length > 2)
                    commands[1] = string.Join(" ", commands[1..]);

                switch (commands[0])
                {
                    case "Play":
                        queue.Dequeue();
                        break;
                    case "Add":
                        if (!queue.Contains(commands[1]))
                            queue.Enqueue(commands[1]);
                        else
                            Console.WriteLine(commands[1] + " is already contained!");
                        break;
                    case "Show":
                        Console.WriteLine(string.Join(", ", queue));
                        break;
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}

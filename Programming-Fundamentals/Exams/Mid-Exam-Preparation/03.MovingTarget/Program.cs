using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MovingTarget
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command = Console.ReadLine();

            while (!command.Equals("End"))
            {
                string[] tokens = command.Split();
                int index = int.Parse(tokens[1]);
                int parameter = int.Parse(tokens[2]);

                switch (tokens[0])
                {
                    case "Shoot":
                        if (ValidIndex(index, targets))
                        {
                            targets[index] -= parameter;
                            if (targets[index] <= 0)
                                targets.RemoveAt(index);
                        }

                        break;

                    case "Add":
                        if (!ValidIndex(index, targets))
                            Console.WriteLine("Invalid placement!");
                        else
                            targets.Insert(index, parameter);
                        break;

                    case "Strike":
                        if (!ValidIndex(index - parameter, targets) || !ValidIndex(index + parameter, targets))
                            Console.WriteLine("Strike missed!");
                        else
                        {
                            int targetsToRemove = parameter * 2 + 1;
                            for (int i = 0; i < targetsToRemove; i++)
                                targets.RemoveAt(index - parameter);
                        }
                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join('|', targets));
        }

        private static bool ValidIndex(int index, ICollection<int> collection) => index >= 0 && index < collection.Count;
    }
}

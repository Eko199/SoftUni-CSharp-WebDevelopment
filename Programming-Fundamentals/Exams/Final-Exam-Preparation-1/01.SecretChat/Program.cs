using System;
using System.Text;

namespace _01.SecretChat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var stops = new StringBuilder(Console.ReadLine());

            string input = Console.ReadLine();
            while (input != "Travel")
            {
                string[] tokens = input.Split(':');

                switch (tokens[0])
                {
                    case "Add Stop":
                        stops.Insert(int.Parse(tokens[1]), tokens[2]);
                        break;
                    case "Remove Stop":
                        int index1 = int.Parse(tokens[1]), index2 = int.Parse(tokens[2]);

                        if (index1 >= 0 && index1 < stops.Length && index2 >= 0 && index2 < stops.Length)
                            stops.Remove(index1, index2 - index1 + 1);

                        break;
                    case "Switch":
                        stops.Replace(tokens[1], tokens[2]);
                        break;
                }

                Console.WriteLine(stops);
                input = Console.ReadLine();
            }

            Console.WriteLine("Ready for world tour! Planned stops: " + stops);
        }
    }
}

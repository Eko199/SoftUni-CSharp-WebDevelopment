using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.SoftUniParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var reservationsSet = new HashSet<string>();
            bool reserving = true;

            string input = Console.ReadLine();
            while (input != "END")
            {
                if (input == "PARTY")
                    reserving = false;
                else if (reserving)
                    reservationsSet.Add(input);
                else
                    reservationsSet.Remove(input);

                input = Console.ReadLine();
            }

            Console.WriteLine(reservationsSet.Count);
            if (reservationsSet.Any(id => char.IsDigit(id[0])))
                Console.WriteLine(string.Join(Environment.NewLine, reservationsSet.Where(id => char.IsDigit(id[0]))));
            if (reservationsSet.Any(id => !char.IsDigit(id[0])))
                Console.WriteLine(string.Join(Environment.NewLine, reservationsSet.Where(id => !char.IsDigit(id[0]))));
        }
    }
}

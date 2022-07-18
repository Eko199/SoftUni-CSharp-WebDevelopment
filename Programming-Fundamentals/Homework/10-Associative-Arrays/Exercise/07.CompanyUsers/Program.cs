using System;
using System.Collections.Generic;

namespace _07.CompanyUsers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var companies = new Dictionary<string, List<string>>();

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] nameAndId = command.Split(" -> ");
                
                if (!companies.ContainsKey(nameAndId[0]))
                    companies[nameAndId[0]] = new List<string> { nameAndId[1] };
                else if (!companies[nameAndId[0]].Contains(nameAndId[1]))
                    companies[nameAndId[0]].Add(nameAndId[1]);

                command = Console.ReadLine();
            }

            foreach (var (name, employees) in companies)
            {
                Console.WriteLine(name);
                employees.ForEach(employeeID => Console.WriteLine("-- " + employeeID));
            }
        }
    }
}

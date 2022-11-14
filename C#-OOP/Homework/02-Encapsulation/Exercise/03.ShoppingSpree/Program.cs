using System;
using System.Linq;

namespace _03.ShoppingSpree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Person[] people = Console.ReadLine()
                    .Split(';', StringSplitOptions.RemoveEmptyEntries)
                    .Select(p => p.Split('='))
                    .Select(p => new Person(p[0], decimal.Parse(p[1])))
                    .ToArray();

                Product[] products = Console.ReadLine()
                    .Split(';', StringSplitOptions.RemoveEmptyEntries)
                    .Select(p => p.Split('='))
                    .Select(p => new Product(p[0], decimal.Parse(p[1])))
                    .ToArray();

                string command;
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] cmdArgs = command.Split();

                    Console.WriteLine(people
                        .Single(p => p.Name == cmdArgs[0])
                        .BuyProduct(products.Single(p => p.Name == cmdArgs[1])));
                }

                foreach (Person person in people)
                {
                    Console.WriteLine(person);
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}

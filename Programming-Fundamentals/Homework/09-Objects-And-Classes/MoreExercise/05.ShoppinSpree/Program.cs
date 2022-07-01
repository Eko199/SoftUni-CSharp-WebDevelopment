using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.ShoppinSpree
{
    class Product
    {
        public string Name { get; set; }
        public int Cost { get; set; }

        public Product(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Money { get; set; }
        public List<Product> Bag { get; set; }

        public Person(string name, int money)
        {
            Name = name;
            Money = money;
            Bag = new List<Product>();
        }

        public void Buy(Product product)
        {
            if (Money >= product.Cost)
            {
                Money -= product.Cost;
                Bag.Add(product);
                Console.WriteLine($"{Name} bought {product.Name}");
            }
            else
                Console.WriteLine($"{Name} can't afford {product.Name}");
        }

        public override string ToString() =>
            $"{Name} - {(Bag.Any() ? string.Join(", ", Bag.Select(product => product.Name)) : "Nothing bought")}";
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries)
                .Select(personInfo => personInfo.Split('='))
                .Select(personProperties => new Person(personProperties[0], int.Parse(personProperties[1])))
                .ToList();
            List<Product> products = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries)
                .Select(productInfo => productInfo.Split('='))
                .Select(productProperties => new Product(productProperties[0], int.Parse(productProperties[1])))
                .ToList();

            string[] tokens = Console.ReadLine().Split();
            while (tokens[0] != "END")
            {
                people.Find(person => person.Name == tokens[0]).Buy(products.Find(product => product.Name == tokens[1]));

                tokens = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(Environment.NewLine, people));
        }
    }
}

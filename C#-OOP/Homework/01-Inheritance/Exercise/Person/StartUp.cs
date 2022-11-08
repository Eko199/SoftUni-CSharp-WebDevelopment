using System;

namespace Person
{
    public class StartUp
    {
        static void Main()

        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Person person = age > 15 ? new Person(name, age) : new Child(name, age);
            Console.WriteLine(person);
        }
    }
}
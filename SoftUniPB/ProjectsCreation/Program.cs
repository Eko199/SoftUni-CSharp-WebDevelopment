using System;

namespace ProjectsCreation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int numberProjects = int.Parse(Console.ReadLine());

            Console.WriteLine($"The architect {name} will need {numberProjects * 3} hours to complete {numberProjects} project/s.");
        }
    }
}

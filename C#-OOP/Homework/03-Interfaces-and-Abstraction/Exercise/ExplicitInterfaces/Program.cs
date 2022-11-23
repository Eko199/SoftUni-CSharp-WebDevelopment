namespace ExplicitInterfaces
{
    using System;
    
    using Models;
    using Models.Interfaces;

    public class Program
    {
        static void Main(string[] args)
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] citizenInfo = command.Split();
                var citizen = new Citizen(citizenInfo[0], int.Parse(citizenInfo[2]), citizenInfo[1]);

                Console.WriteLine(((IPerson)citizen).GetName());
                Console.WriteLine(((IResident) citizen).GetName());
            }
        }
    }
}

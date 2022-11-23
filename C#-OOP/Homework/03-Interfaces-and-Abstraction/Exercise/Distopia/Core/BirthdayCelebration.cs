namespace Distopia.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Interfaces;
    using Models;
    using Models.Interfaces;

    public class BirthdayCelebration : IEngine
    {
        public void Run()
        {
            var births = new List<IBirthable>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split();

                switch (cmdArgs[0])
                {
                    case "Citizen":
                        births.Add(new Citizen(cmdArgs[1], int.Parse(cmdArgs[2]), cmdArgs[3], cmdArgs[4]));
                        break;
                    case "Pet": 
                        births.Add(new Pet(cmdArgs[1], cmdArgs[2]));
                        break;
                }
            }

            string year = Console.ReadLine();
            births
                .Select(p => p.Birthdate)
                .Where(b => b.EndsWith(year))
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}

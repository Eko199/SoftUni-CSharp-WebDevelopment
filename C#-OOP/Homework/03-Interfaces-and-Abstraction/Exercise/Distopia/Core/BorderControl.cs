namespace Distopia.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Interfaces;
    using Models;
    using Models.Interfaces;

    public class BorderControl : IEngine
    {
        public void Run()
        {
            var population = new List<IIdentifiable>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split();

                population.Add(cmdArgs.Length switch
                {
                    3 => new Citizen(cmdArgs[0], int.Parse(cmdArgs[1]), cmdArgs[2]),
                    2 => new Robot(cmdArgs[0], cmdArgs[1])
                });
            }

            string fakeIdsEnd = Console.ReadLine();
            population
                .Select(p => p.Id)
                .Where(id => id.EndsWith(fakeIdsEnd))
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}

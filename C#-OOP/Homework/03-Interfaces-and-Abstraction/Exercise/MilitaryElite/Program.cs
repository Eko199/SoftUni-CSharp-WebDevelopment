namespace MilitaryElite
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Models;
    using Models.Enums;
    using Models.Interfaces;

    public class Program
    {
        static void Main(string[] args)
        {
            var soldiers = new List<ISoldier>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split();

                string soldierType = cmdArgs[0];
                int soldierId = int.Parse(cmdArgs[1]);
                string soldierFirstName = cmdArgs[2];
                string soldierLastName = cmdArgs[3];

                switch (soldierType)
                {
                    case "Private":
                        soldiers.Add(new Private(soldierId, soldierFirstName, soldierLastName, decimal.Parse(cmdArgs[4])));
                        break;

                    case "LieutenantGeneral":
                        var lieutenatGeneral = new LieutenantGeneral(soldierId, soldierFirstName, soldierLastName,
                            decimal.Parse(cmdArgs[4]));

                        foreach (int id in cmdArgs.Skip(5).Select(int.Parse))
                        {
                            lieutenatGeneral.AddPrivate((IPrivate) soldiers.Single(s => s.GetType() != typeof(ISpy) && s.Id == id));
                        }

                        soldiers.Add(lieutenatGeneral);
                        break;

                    case "Engineer":
                        try
                        {
                            var engineer = new Engineer(soldierId, soldierFirstName, soldierLastName,
                                decimal.Parse(cmdArgs[4]), GetEnumFromSting<Corps>(cmdArgs[5]));

                            for (int i = 6; i < cmdArgs.Length; i += 2)
                            {
                                engineer.AddRepair(new Repair(cmdArgs[i], int.Parse(cmdArgs[i + 1])));
                            }

                            soldiers.Add(engineer);
                        }
                        catch (ArgumentException) { }

                        break;

                    case "Commando":
                        try
                        {
                            var commando = new Commando(soldierId, soldierFirstName, soldierLastName,
                                decimal.Parse(cmdArgs[4]), GetEnumFromSting<Corps>(cmdArgs[5]));

                            for (int i = 6; i < cmdArgs.Length; i += 2)
                            {
                                try
                                {
                                    commando.AddMission(new Mission(cmdArgs[i], GetEnumFromSting<State>(cmdArgs[i + 1])));
                                }
                                catch (ArgumentException) { }
                            }

                            soldiers.Add(commando);
                        }
                        catch (ArgumentException) { }

                        break;

                    case "Spy":
                        soldiers.Add(new Spy(soldierId, soldierFirstName, soldierLastName, int.Parse(cmdArgs[4])));
                        break;
                }
            }

            foreach (ISoldier soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }

        private static T GetEnumFromSting<T>(string enumStr) where T : struct, IConvertible
        {
            if (!Enum.TryParse(enumStr, out T enumeration))
                throw new ArgumentException($"Invalid {typeof(T)}!");

            return enumeration;
        }
    }
}

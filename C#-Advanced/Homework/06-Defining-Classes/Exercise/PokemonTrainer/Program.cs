using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            string input = Console.ReadLine();
            while (input != "Tournament")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (trainers.All(trainer => trainer.Name != tokens[0]))
                    trainers.Add(new Trainer(tokens[0]));
                trainers.Single(trainer => trainer.Name == tokens[0])
                    .Pokemons
                    .Add(new Pokemon(tokens[1], tokens[2], int.Parse(tokens[3])));

                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (input != "End")
            {
                trainers.ForEach(trainer => trainer.EnterTournament(input));
                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(Environment.NewLine, trainers.OrderByDescending(trainer => trainer.NumberOfBadges)));
        }
    }
}

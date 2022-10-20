using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string name)
        {
            Name = name;
            NumberOfBadges = 0;
            Pokemons = new List<Pokemon>();
        }

        public string Name { get; set; }
        public int NumberOfBadges { get; set; }
        public List<Pokemon> Pokemons { get; set; }

        public void EnterTournament(string element)
        {
            if (Pokemons.Any(pokemon => pokemon.Element == element))
                NumberOfBadges++;
            else
            {
                Pokemons.ForEach(pokemon => pokemon.Health -= 10);
                Pokemons.RemoveAll(pokemon => pokemon.Health <= 0);
            }
        }

        public override string ToString()
            => $"{Name} {NumberOfBadges} {Pokemons.Count}";
    }
}

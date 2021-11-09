using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();

            string command = Console.ReadLine();

            while (command != "Tournament")
            {
                string[] input = command
                    .Split()
                    .ToArray();

                string trainerName = input[0];
                string pokemonName = input[1];
                string pokemonElement = input[2];
                int pokemonHealth = int.Parse(input[3]);

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers.Add(trainerName, new Trainer(trainerName));
                }

                Trainer currentTrainer = trainers[trainerName]; //важно за добавянето към речника, ако не го направим така не може да добавим покемон в речника 
                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                currentTrainer.Pokemons.Add(pokemon);

                command = Console.ReadLine();
            }

            command = Console.ReadLine();
            while (command != "End")
            {
                string element = command;

                foreach (var trainer in trainers)
                {
                    if (trainer.Value.Pokemons.Any(x => x.Element == element))
                    {
                        trainer.Value.Badges++;
                    }
                    else
                    {
                        // trainer.Value.Pokemons.Select(p => p.Health -= 10).ToList();
                        foreach (var pokemon in trainer.Value.Pokemons)
                        {
                            pokemon.Health -= 10;
                        }

                        trainer.Value.Pokemons.RemoveAll(x => x.Health <= 0);
                    }
                }
                command = Console.ReadLine();
            }

            //Проверка с принтиране на колекцията
            // foreach (var trainer in trainers)
            // {
            //     string name = trainer.Key;
            //     int badge = trainer.Value.Badges;
            //     Console.WriteLine($"{name} - {badge}");
            // 
            //     List<Pokemon> pokemons = trainer.Value.Pokemons;
            //     foreach (var pokemon in pokemons)
            //     {
            //         string pokemonName = pokemon.Name;
            //         string pokemonElement = pokemon.Element;
            //         int pokemontHealt = pokemon.Health;
            //         Console.WriteLine($"  {pokemonName} - {pokemonElement} - {pokemontHealt}");
            //     }
            // }
            var result = trainers
                .OrderByDescending(x => x.Value.Badges)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var traner in result)
            {

                Console.WriteLine($"{traner.Key} {traner.Value.Badges} {traner.Value.Pokemons.Count}");
            }
        }
    }
}

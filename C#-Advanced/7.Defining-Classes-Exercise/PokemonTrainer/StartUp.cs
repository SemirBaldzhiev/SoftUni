using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();


            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Tournament")
                {
                    break;
                }

                string[] inputData = line.Split().ToArray();

                Pokemon pokemon = new Pokemon(inputData[1], inputData[2], int.Parse(inputData[3]));
               
                if (!trainers.Any(t => t.Name == inputData[0]))
                {
                    Trainer trainer = new Trainer(inputData[0]);
                    trainers.Add(trainer);
                    trainer.Pokemons.Add(pokemon);
                }
                else
                {
                    var addedTrainer = trainers.Find(t => t.Name == inputData[0]);
                    addedTrainer.Pokemons.Add(pokemon);
                }
                
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }
                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemons.Any(p => p.Element == command))
                    {
                        trainer.NumberOfBadges++;
                    }
                    else
                    {
                        for (int i = 0; i < trainer.Pokemons.Count; i++)
                        {
                            trainer.Pokemons[i].Health -= 10;
                            if (trainer.Pokemons[i].Health <= 0)
                            {
                                trainer.Pokemons.Remove(trainer.Pokemons[i]);
                                i--;
                            }

                        }

                    }
                }
            }

            foreach (var trainer in trainers.OrderByDescending(t => t.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
            }
        }
    }
}

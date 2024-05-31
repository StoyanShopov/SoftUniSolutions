namespace _09.PokemonTrainer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Dictionary<string, Trainer> trainers 
            //    = new Dictionary<string, Trainer>();

            List<Trainer> trainers = new List<Trainer>();

            string command = Console.ReadLine();

            while (command != "Tournament")
            {
                string[] commandInfo = command.Split();

                string trainerName = commandInfo[0];
                string pokemonName = commandInfo[1];
                string pokemonElement = commandInfo[2];
                int pokemonHealth = int.Parse(commandInfo[3]);

                //trainers.TryAdd(trainerName, new Trainer(trainerName));
                Trainer trainer = trainers.FirstOrDefault(x => x.Name == trainerName);

                if (trainer == null)
                {
                    trainer = new Trainer(trainerName);
                    trainers.Add(trainer);
                }

                Pokemon pokemon = new Pokemon(
                    pokemonName, pokemonElement, pokemonHealth);

                trainer.Pokemons.Add(pokemon);

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                foreach (var trainer in trainers)
                {
                    bool doesTrainerHavePokemonElement
                        = trainer.Pokemons.Any(x => x.Element == command);

                    if (doesTrainerHavePokemonElement)
                    {
                        trainer.Badges += 1;
                    }
                    else
                    {
                        foreach (var pokemon in trainer.Pokemons)
                        {
                            pokemon.Health -= 10;
                        }

                        trainer.Pokemons.RemoveAll(x => x.Health <= 0);
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var trainer in trainers
                .OrderByDescending(x => x.Badges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
            }
        }
    }
}

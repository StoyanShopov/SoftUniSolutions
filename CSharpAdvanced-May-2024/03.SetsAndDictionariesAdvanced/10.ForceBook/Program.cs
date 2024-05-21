namespace _10.ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Darker | DCay           forceSide | forceUser
            //John Johnys -> Lighter  forceUser -> forceSide
            Dictionary<string, HashSet<string>> forces
                = new Dictionary<string, HashSet<string>>();

            string input = Console.ReadLine();

            while (input != "Lumpawaroo")
            {
                string[] inputInfo = input.Split(
                    new string[] { " | ", " -> ", },
                    StringSplitOptions.RemoveEmptyEntries);

                string forceUser = input.Contains("|") ? inputInfo[1] : inputInfo[0];
                string forceSide = input.Contains("->") ? inputInfo[1] : inputInfo[0];

                if (!forces.ContainsKey(forceSide))
                {
                    forces.Add(forceSide, new HashSet<string>());
                }

                if (input.Contains("|") && !forces.Any(x => x.Value.Contains(forceUser)))
                {
                    forces[forceSide].Add(forceUser);
                }
                else if (input.Contains("->"))
                {
                    foreach (var force in forces)
                    {
                        if (force.Value.Contains(forceUser) && force.Key != forceSide)
                        {
                            force.Value.Remove(forceUser);
                            break;
                        }
                    }

                    forces[forceSide].Add(forceUser);

                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }

                input = Console.ReadLine();
            }

            foreach (var item in forces
                .Where(x => x.Value.Count > 0)
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"Side: {item.Key}, Members: {item.Value.Count}");

                foreach (var user in item.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }
    }
}

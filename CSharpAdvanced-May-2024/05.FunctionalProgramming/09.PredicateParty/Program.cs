namespace _09.PredicateParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine()
                .Split()
                .ToList();

            string command = Console.ReadLine();

            Func<List<string>, string, string, List<string>> filter
                = (listOfNames, operation, value) =>
                {
                    return operation == "StartsWith"
                         ? listOfNames.Where(x => x.StartsWith(value)).ToList()
                             : operation == "EndsWith"
                                 ? listOfNames.Where(x => x.EndsWith(value)).ToList()
                                 : listOfNames.Where(x => x.Length == int.Parse(value)).ToList();
                };

            while (command != "Party!")
            {
                //Remove StartsWith P
                //Double Length 5
                string[] commandInfo = command.Split();
                string commandName = commandInfo[0];
                string operation = commandInfo[1];
                string value = commandInfo[2];

                List<string> targetNames = filter(names, operation, value);

                if (commandName == "Remove")
                {
                    names = names.Where(x => !targetNames.Contains(x)).ToList();
                }
                else if (commandName == "Double")
                {
                    names.AddRange(targetNames);
                    //foreach (var item in targetNames) //[Misha]
                    //{
                        //int index = names.IndexOf(item); //1
                        //names.Insert(index, item);
                    //}
                }

                command = Console.ReadLine();
            }

            if (names.Count > 0)
            {
                Console.WriteLine(string.Join(", ", names.OrderBy(x => x)) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}

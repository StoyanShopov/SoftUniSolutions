using System.Collections.Generic;

namespace _10.PartyReservationFilterModule
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine()
                .Split()
                .ToList();

            string command = Console.ReadLine();

            List<string> operations = new List<string>();

            while (command != "Print")
            {
                string[] commandInfo = command.Split(';');

                string filterCommand = commandInfo[0];
                string filter = commandInfo[1];
                string value = commandInfo[2];

                if (filterCommand == "Add filter")
                {
                    operations.Add($"{filter};{value}");
                }
                else
                {
                    operations.Remove($"{filter};{value}");
                }

                command = Console.ReadLine();
            }

            Dictionary<string, Func<string, string, bool>> predicates = new()
            {
                { "Starts with", (name, value) => name.StartsWith(value) },
                { "Ends with",(name, value) => name.EndsWith(value) },
                { "Contains", (name, value) => name.Contains(value) },
                { "Length", (name, value) => name.Length == int.Parse(value) },
            };

            foreach (string item in operations)
            {
                string[] operationInfo = item.Split(";");
                string operation = operationInfo[0];
                string value = operationInfo[1];

                names = names.Where(name => !predicates[operation](name, value)).ToList();
            }

            Console.WriteLine(string.Join(" ", names));
        }
    }
}

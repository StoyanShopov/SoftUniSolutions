using System.Threading.Channels;

namespace _05.AppliedArithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1 2 3 4 5
            int[] inputNubmers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string command = Console.ReadLine();

            Func<int[], string, int[]> applyArithmetics
                = (numbers, operation) =>
                {
                    return operation == "add"
                        ? numbers.Select(x => x + 1).ToArray()
                        : operation == "multiply"
                            ? numbers.Select(x => x * 2).ToArray()
                            : numbers.Select(x => x - 1).ToArray();
                };

            Func<int[], int[]> add = numbers
                => numbers.Select(x => x + 1).ToArray();

            Func<int[], int[]> subtract = numbers
                => numbers.Select(x => x - 1).ToArray();

            Func<int[], int[]> multiply = numbers
                => numbers.Select(x => x * 1).ToArray();

            while (command != "end")
            {
                if (command == "print")
                {
                    Console.WriteLine(string.Join(" ", inputNubmers));
                }
                else 
                {
                    inputNubmers = command == "add"
                        ? add(inputNubmers)
                        : command == "multiply"
                            ? multiply(inputNubmers)
                            : subtract(inputNubmers);
                }

                command = Console.ReadLine();
            }
        }
    }
}

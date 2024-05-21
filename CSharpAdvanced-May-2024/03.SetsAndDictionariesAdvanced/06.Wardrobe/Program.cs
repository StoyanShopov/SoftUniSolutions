using System.Diagnostics.Contracts;

namespace _06.Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe =
                new Dictionary<string, Dictionary<string, int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" -> ");

                string color = input[0];
                string[] clothes = input[1].Split(",");

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                foreach (var item in clothes)
                {
                    if (!wardrobe[color].ContainsKey(item))
                    {
                        wardrobe[color].Add(item, 0);
                    }

                    //Dictionary<string, Dictionary<string, int>>

                    //wardrobe = Dictionary<string, Dictionary<string, int>>
                    //wardrobe[color] = Dictionary<string, int>
                    //wardrobe[color][item] = int

                    wardrobe[color][item] += 1;
                }
            }

            //Blue dress
            string[] lookupValues = Console.ReadLine().Split();

            foreach (var (color, clothes) in wardrobe)
            {
                Console.WriteLine($"{color} clothes:");

                foreach (var (item, count) in clothes)
                {
                    string outputValue = $"* {item} - {count}";

                    if (color == lookupValues[0] && item == lookupValues[1])
                    {
                        outputValue += " (found!)";
                    }

                    Console.WriteLine(outputValue);
                }
            }
        }
    }
}

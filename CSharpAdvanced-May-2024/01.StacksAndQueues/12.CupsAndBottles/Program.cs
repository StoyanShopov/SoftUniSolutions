namespace _12.CupsAndBottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputCups = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] inputBottles = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> cups = new Queue<int>(inputCups);
            Stack<int> bottles = new Stack<int>(inputBottles);

            int wastedLiters = 0;

            while (cups.Any() && bottles.Any())
            {
                int bottle = bottles.Pop(); //10
                int cup = cups.Dequeue(); //4

                cup -= bottle;

                while (cup > 0 && bottles.Any())
                {
                    cup -= bottles.Pop();
                }

                if (cup < 0)
                {
                    wastedLiters += cup;
                }
            }

            if (bottles.Count > 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedLiters * -1}");
        }
    }
}

namespace _02.BasicQueueOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] operations = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] inputNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>();

            int elementsToEnqueue = operations[0];
            int elementsToDequeue = operations[1];
            int elementToLookup = operations[2];

            for (int i = 0; i < elementsToEnqueue; i++)
            {
                queue.Enqueue(inputNumbers[i]);
            }

            while (queue.Any() && elementsToDequeue > 0)
            {
                queue.Dequeue();
                elementsToDequeue--;
            }

            if (!queue.Any())
            {
                Console.WriteLine(0);
            }
            else if (queue.Contains(elementToLookup))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}

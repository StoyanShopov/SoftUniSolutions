namespace _01.BasicStackOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] operations = Console.ReadLine() //5 2 13
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] inputElements = Console.ReadLine() //1 13 45 32 4 10 30 40 50
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>();

            int elementsToPush = operations[0];
            int elementsToPop = operations[1];
            int elementToLookup = operations[2];

            for (int i = 0; i < elementsToPush; i++)
            {
                stack.Push(inputElements[i]);
            }

            while (stack.Any() && elementsToPop > 0)
            {
                stack.Pop();
                elementsToPop--;
            }

            if (!stack.Any())
            {
                Console.WriteLine(0);
            }
            else if (stack.Contains(elementToLookup))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }

        }
    }
}

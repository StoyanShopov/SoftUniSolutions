namespace _05.FashionBoutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputValues = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rackCapacity = int.Parse(Console.ReadLine());

            Stack<int> clothes = new Stack<int>(inputValues);

            int currentRackCapacity = 0;
            int box = 1;

            while (clothes.Any())
            {
                int currentClothe = clothes.Pop();

                if (currentClothe + currentRackCapacity <= rackCapacity)
                {
                    currentRackCapacity += currentClothe;
                }
                else
                {
                    currentRackCapacity = currentClothe;
                    box++;
                }
            }

            Console.WriteLine(box);
        }
    }
}

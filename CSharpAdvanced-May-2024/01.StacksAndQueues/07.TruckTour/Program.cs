namespace _07.TruckTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<(int, int)> petrolPumps = new Queue<(int, int)>();

            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int petrol = input[0];
                int km = input[1];

                petrolPumps.Enqueue((petrol, km));
            }

            int startIndex = 0;

            while (true)
            {
                int totalPetrol = 0;

                foreach (var item in petrolPumps)
                {
                    totalPetrol += item.Item1;
                    int km = item.Item2;

                    totalPetrol -= km;

                    if (totalPetrol < 0)
                    {
                        break;
                    }
                }

                if (totalPetrol < 0)
                {
                    startIndex++;
                    petrolPumps.Enqueue(petrolPumps.Dequeue());
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(startIndex);
        }
    }
}

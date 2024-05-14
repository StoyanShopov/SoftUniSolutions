namespace _11.KeyRevolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int priceOfBullet = int.Parse(Console.ReadLine());
            int sizeOfGunBarrel = int.Parse(Console.ReadLine());
            int[] inputBullets = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] inputLocks = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int valueOfIntelligence = int.Parse(Console.ReadLine());

            Queue<int> locks = new Queue<int>(inputLocks);
            Stack<int> bullets = new Stack<int>(inputBullets);

            int shootsCount = 0;
            int totalShoots = 0;

            while (locks.Any() && bullets.Any())
            {
                int bullet = bullets.Pop();
                int currentLock = locks.Peek();
                shootsCount++;
                totalShoots++;

                if (bullet <= currentLock)
                {
                    locks.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (shootsCount == sizeOfGunBarrel && bullets.Any())
                {
                    Console.WriteLine("Reloading!");
                    shootsCount = 0;
                }
            }

            if (locks.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                int moneyEarned = valueOfIntelligence - (priceOfBullet * totalShoots);
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${moneyEarned}");
            }
        }
    }
}

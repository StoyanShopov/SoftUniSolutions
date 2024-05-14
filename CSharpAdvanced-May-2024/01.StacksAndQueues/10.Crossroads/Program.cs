namespace _10.Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            Queue<string> cars = new Queue<string>();

            int passedCars = 0;
            bool isHitted = false;

            while (command != "END")
            {
                if (command != "green")
                {
                    cars.Enqueue(command);
                    command = Console.ReadLine();
                    continue;
                }

                int currentGreenLight = greenLight;

                while (cars.Count > 0 && currentGreenLight > 0)
                {
                    string currentCar = cars.Dequeue();

                    if (currentGreenLight - currentCar.Length >= 0)
                    {
                        currentGreenLight -= currentCar.Length;
                        passedCars++;
                        continue;
                    }

                    if ((currentGreenLight + freeWindow) - currentCar.Length >= 0)
                    {
                        passedCars++;
                        break;
                    }

                    //currentGreenLight = 1
                    //freeWindow = 3
                    //Hummer
                    char hittedChar = currentCar[currentGreenLight + freeWindow];

                    Console.WriteLine("A crash happened!");
                    Console.WriteLine($"{currentCar} was hit at {hittedChar}.");
                    isHitted = true;
                    break;
                }

                if (isHitted)
                {
                    break;
                }

                command = Console.ReadLine();
            }

            if (!isHitted)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{passedCars} total cars passed the crossroads.");
            }
        }
    }
}

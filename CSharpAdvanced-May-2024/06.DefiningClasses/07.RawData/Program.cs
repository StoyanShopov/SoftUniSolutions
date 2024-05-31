namespace _07.RawData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string model = input[0];
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoType, cargoWeight);

                Tire[] tires = new Tire[4];
                int counter = 0;
                for (int t = 5; t <= 12; t += 2)
                {
                    double tirePressure = double.Parse(input[t]);
                    int tireAge = int.Parse(input[t + 1]);
                    tires[counter++] = new Tire(tireAge, tirePressure);
                }

                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            string targetCargoType = Console.ReadLine();

            cars.Where(car => car.Cargo.Type == targetCargoType
                    && (targetCargoType == "fragile"
                        ? car.Tires.Any(x => x.Pressure < 1)
                        : car.Engine.Power > 250))
                .ToList()
                .ForEach(x => Console.WriteLine(x.Model));
        }
    }
}

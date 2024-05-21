namespace _04.EvenTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<int, int> numbers = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int inputNumber = int.Parse(Console.ReadLine());

                if (!numbers.ContainsKey(inputNumber))
                {
                    numbers.Add(inputNumber, 0);
                }

                numbers[inputNumber]++;
            }

            int evenNumber = numbers
                .Where(x => x.Value % 2 == 0)
                .FirstOrDefault()
                .Key;

            //int evenNumber = 0;

            //foreach (var (key, value) in numbers)
            //{
            //    if (value % 2 == 0)
            //    {
            //        evenNumber = key;
            //        break;
            //    }
            //}

            Console.WriteLine(evenNumber);
        }
    }
}

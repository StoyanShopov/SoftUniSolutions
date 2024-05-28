namespace _03.CustomMinFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1 4 3 2 1 7 13
            int[] inputNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Func<int[], int> getMinNumber = numbers
                => numbers.Min();

            Console.WriteLine(getMinNumber(inputNumbers));
        }
    }
}

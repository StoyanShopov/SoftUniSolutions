namespace _06.ReverseAndExclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Reverse()
                .ToArray();

            int n = int.Parse(Console.ReadLine());

            Func<int, int, bool> filter = (number, div)
                   => number % div == 0;

            int[] result = inputNumbers
                .Where(x => !filter(x, n))
                .ToArray();

            Console.WriteLine(string.Join(" ", result));
        }
    }
}

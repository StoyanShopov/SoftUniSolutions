namespace _08.ListOfPredicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); //100
            List<int> numbers = Enumerable.Range(1, n).ToList(); //1...100

            int[] dividers = Console.ReadLine() //2 5 10 20
                .Split()
                .Select(int.Parse)
                .ToArray();

            Func<int, int[], bool> isDivisible = (number, divs) //20, [2, 5, 10, 20]
                => divs.All(x => number % x == 0);

            int[] result = numbers
                .Where(number => isDivisible(number, dividers))
                .ToArray();

            Console.WriteLine(string.Join(" ", result));
        }
    }
}

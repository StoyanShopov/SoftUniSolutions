using System.Runtime.Serialization;

namespace _04.FindEvensOrOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1 10
            //even or odd
            int[] range = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string type = Console.ReadLine();

            int start = range[0];
            int end = range[1];

            List<int> numbers = Enumerable
                .Range(start, end - start + 1)
                .ToList();

            Predicate<int> isEven = x => x % 2 == 0;
            //Predicate<int> isOdd = x => x % 2 != 0;

            //Func<int, bool> isEven2 = x => x % 2 == 0;
            //var filter2 = numbers.Where(isEven2);

            var filter = numbers.FindAll(x => type == "even" 
                ? isEven(x) 
                : !isEven(x));

            var result = string.Join(" ", filter);

            Console.WriteLine(result);
        }
    }
}

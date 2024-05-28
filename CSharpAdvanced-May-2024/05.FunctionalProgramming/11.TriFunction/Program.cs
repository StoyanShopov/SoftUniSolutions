namespace _11.TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int asciiSum = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
                .Split();

            Func<string, int, bool> filter = (name, sum)
                => name.Sum(x => x) >= sum;

            Func<string[], Func<string, int, bool>, string> filterFirstName 
                = (allNames, funcFilter)
                => allNames.FirstOrDefault(x => funcFilter(x, asciiSum));

            Console.WriteLine(filterFirstName(names, filter));
        }
    }
}

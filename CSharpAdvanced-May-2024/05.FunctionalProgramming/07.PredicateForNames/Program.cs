namespace _07.PredicateForNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> func = (name, length)
                => name.Length <= length;

            int n = int.Parse(Console.ReadLine());

            Console.ReadLine()
                .Split()
                .Where(x => func(x, n))
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}

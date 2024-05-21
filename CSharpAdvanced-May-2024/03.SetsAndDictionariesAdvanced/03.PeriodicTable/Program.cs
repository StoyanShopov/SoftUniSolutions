namespace _03.PeriodicTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            SortedSet<string> elements = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                foreach (string el in input)
                {
                    elements.Add(el);
                }
            }

            Console.WriteLine(string.Join(" ", elements));
        }
    }
}

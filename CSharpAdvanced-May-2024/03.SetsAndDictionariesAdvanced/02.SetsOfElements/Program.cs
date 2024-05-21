namespace _02.SetsOfElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] lengthOfSets = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int n = lengthOfSets[0];
            int m = lengthOfSets[1];

            HashSet<int> setA = new HashSet<int>();
            HashSet<int> setB = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                setA.Add(currentNumber);
            }

            for (int i = 0; i < m; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                setB.Add(currentNumber);
            }

            Console.WriteLine(string.Join(" ", setA.Intersect(setB)));
        }
    }
}

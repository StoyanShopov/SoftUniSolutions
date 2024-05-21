namespace _05.CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            SortedDictionary<char, int> charOccurences = new SortedDictionary<char, int>();

            foreach (var currentChar in input)
            {
                if (!charOccurences.ContainsKey(currentChar))
                {
                    charOccurences.Add(currentChar, 0);
                }

                charOccurences[currentChar]++;
            }

            foreach (var (symbol, occurences) in charOccurences)
            {
                Console.WriteLine($"{symbol}: {occurences} time/s");
            }
        }
    }
}

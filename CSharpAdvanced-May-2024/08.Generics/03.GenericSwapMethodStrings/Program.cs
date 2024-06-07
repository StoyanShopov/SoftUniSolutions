namespace _03.GenericSwapMethodStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Box<string> box = new Box<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                box.Items.Add(input);
            }

            int[] values = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int firstIndex = values[0];
            int secondIndex = values[1];    

            box.Swap(firstIndex, secondIndex);

            Console.WriteLine(box);
        }
    }
}

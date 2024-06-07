namespace _05.GenericCountMethodString
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

            string valueToCompare = Console.ReadLine();

            int counter = box.CountOfLargetElements(valueToCompare);

            Console.WriteLine(counter);
        }
    }
}

namespace _06.GenericCountMethodDouble
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            Box<double> box = new Box<double>();

            for (var i = 0; i < n; i++)
            {
                var input = double.Parse(Console.ReadLine());

                box.Items.Add(input);
            }

            var valueToCompare = double.Parse(Console.ReadLine());

            var counter = box.CountOfLargetElements(valueToCompare);

            Console.WriteLine(counter);
        }
    }
}

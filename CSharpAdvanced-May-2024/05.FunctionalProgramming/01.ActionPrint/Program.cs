using System.Threading.Channels;

namespace _01.ActionPrint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();

            Action<string[]> printNames = allNames
                => Console.WriteLine(string.Join(Environment.NewLine, allNames));

            printNames(names);
        }
    }
}

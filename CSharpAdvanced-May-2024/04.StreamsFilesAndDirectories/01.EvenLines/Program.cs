using System.Text;

namespace _01.EvenLines
{
    internal class Program
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            var streamReader = new StreamReader(inputFilePath);
            StringBuilder sb = new StringBuilder();
            int counter = 0;

            while (true)
            {
                var line = streamReader.ReadLine();

                if (line == null)
                {
                    break;
                }

                if (counter++ % 2 != 0)
                {
                    continue;
                }

                sb.AppendLine(string.Join(" ", line.Split().Reverse()));
            }

            char[] replaceSymbol = new char[] { '-', ',', '.', '!', '?' };


            foreach (char c in replaceSymbol)
            {
                sb = sb.Replace(c, '@');
            }

            return sb.ToString();
        }
    }
}

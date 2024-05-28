using System.Text;

namespace _02.LineNumbers
{
    internal class Program
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            var lines = File.ReadAllLines(inputFilePath);
            StringBuilder sb = new StringBuilder();

            int counter = 1;

            foreach (var line in lines)
            {
                int coubt = line.Count(x => x is ',' or '!' or '?' or '-' or '.' or '\'');
                sb.AppendLine($"Line {counter++}: {line} ({line.Count(char.IsLetter)})({coubt})");
            }

            File.WriteAllText(outputFilePath, sb.ToString());
        }
    }
}

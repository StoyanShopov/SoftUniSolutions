using System.Text;

namespace _04.DirectoryTraversal
{
    internal class Program
    {
        static void Main()
        {
            string path = Console.ReadLine();

            string reportFileName = @"\report.txt";
            string reportContent = TraverseDirectory(path);

            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            var files = Directory.GetFiles(inputFolderPath);

            Dictionary<string, Dictionary<string, double>> fileInfo =
                new Dictionary<string, Dictionary<string, double>>();

            foreach (var file in files)
            {
                var fileName = Path.GetFileName(file);
                var extension = Path.GetExtension(file);
                var size = new FileInfo(file).Length / 1024;

                if (!fileInfo.ContainsKey(extension))
                {
                    fileInfo.Add(extension, new Dictionary<string, double>());
                }

                fileInfo[extension].Add(fileName, size);
            }

            StringBuilder result = new StringBuilder();

            foreach (var file in fileInfo.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                result.AppendLine(file.Key);

                foreach (var item in file.Value.OrderBy(x => x.Value))
                {
                    result.AppendLine($"--{item.Key} -{item.Value}kb");
                }
            }

            return result.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;

            File.WriteAllText(filePath, textContent);
        }

    }
}

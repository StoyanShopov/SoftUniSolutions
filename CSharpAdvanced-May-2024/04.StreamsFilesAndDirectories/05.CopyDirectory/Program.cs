namespace _05.CopyDirectory
{
    internal class Program
    {
        static void Main()
        {
            string inputPath = @$"{Console.ReadLine()}";
            string outputPath = @$"{Console.ReadLine()}";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            var allFiles = Directory.GetFiles(inputPath);

            if (Directory.Exists(outputPath))
            {
                Directory.Delete(outputPath);
            }

            Directory.CreateDirectory(outputPath);

            foreach (var file in allFiles)
            {
                var fileName = Path.GetFileName(file);

                File.Copy(file, outputPath + "\\" + fileName);
            }
        }
    }
}

using System.IO.Compression;

namespace _06.ZipAndExtracts
{
    internal class Program
    {
        static void Main()
        {
            string inputFile = @"..\..\..\test";
            string zipArchiveFile = @"..\..\..\archive.zip";
            string extractedFile = @"..\..\..\new";

            ZipFileToArchive(inputFile, zipArchiveFile);

            var fileNameOnly = Path.GetFileName(inputFile);
            ExtractFileFromArchive(zipArchiveFile, fileNameOnly, extractedFile);
        }

        public static void ZipFileToArchive(string inputFilePath, string zipArchiveFilePath)
        {
            ZipFile.CreateFromDirectory(inputFilePath, zipArchiveFilePath);
        }

        public static void ExtractFileFromArchive(string zipArchiveFilePath, string fileName, string outputFilePath)
        {
            ZipFile.ExtractToDirectory(zipArchiveFilePath, outputFilePath);
        }
    }
}

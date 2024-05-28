namespace _03.CopyBinaryFile
{
    internal class Program
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using FileStream reader = new FileStream(inputFilePath, FileMode.Open);
            using FileStream writer = new FileStream(outputFilePath, FileMode.Create);

            byte[] buffer = new byte[1024];
            while (true)
            {
                int size = reader.Read(buffer, 0, buffer.Length);

                if (size == 0)
                {
                    break;
                }

                writer.Write(buffer, 0, size);
            }
        }
    }
}

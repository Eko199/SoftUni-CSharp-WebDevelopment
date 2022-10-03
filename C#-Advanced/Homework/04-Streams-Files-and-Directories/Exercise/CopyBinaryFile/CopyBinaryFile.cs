using System.IO;

namespace CopyBinaryFile
{
    using System;
    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using var input = new FileStream(inputFilePath, FileMode.Open);
            using var output = new FileStream(outputFilePath, FileMode.Create);

            var buffer = new byte[input.Length];
            input.Read(buffer);
            output.Write(buffer);
        }
    }
}

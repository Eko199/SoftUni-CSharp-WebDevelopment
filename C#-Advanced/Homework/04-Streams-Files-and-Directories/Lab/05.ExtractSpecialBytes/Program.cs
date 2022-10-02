using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ExtractBytes
{
    public class ExtractBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            var specialBytes = new HashSet<byte>();

            using (var stream = new FileStream(bytesFilePath, FileMode.Open))
            {
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer);
                specialBytes.UnionWith(buffer);
            }

            using var inputStream = new FileStream(binaryFilePath, FileMode.Open);
            using var outputStream = new FileStream(outputPath, FileMode.Create);

            byte[] inputBuffer = new byte[inputStream.Length];
            inputStream.Read(inputBuffer);
            
            outputStream.Write(inputBuffer.Where(inputByte => specialBytes.Contains(inputByte)).ToArray());
        }
    }
}


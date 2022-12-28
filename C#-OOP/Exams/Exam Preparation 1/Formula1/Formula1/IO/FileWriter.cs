namespace Formula1.IO
{
    using System;
    using System.IO;

    using Contracts;

    public class FileWriter : IWriter
    {
        public void WriteLine(string message) => File.AppendAllText(@"../../../output.txt", message + Environment.NewLine);

        public void Write(string message) => File.AppendAllText(@"../../../output.txt", message);
    }
}
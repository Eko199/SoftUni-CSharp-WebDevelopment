using System;

namespace _03.ExtractFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nameAndExtension = Console.ReadLine().Split('\\')[^1].Split('.');
            Console.WriteLine("File name: " + nameAndExtension[0]);
            Console.WriteLine("File extension: " + nameAndExtension[1]);
        }
    }
}

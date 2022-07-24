using System;
using System.Text;

namespace _01.ActivationKeys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var key = new StringBuilder(Console.ReadLine());

            string input = Console.ReadLine();
            while (input != "Generate")
            {
                string[] tokens = input.Split(">>>");

                switch (tokens[0])
                {
                    case "Contains":
                        Console.WriteLine(key.ToString().Contains(tokens[1]) ? $"{key} contains {tokens[1]}" : "Substring not found!");
                        break;
                    case "Flip":
                        int startIndex = int.Parse(tokens[2]), endIndex = int.Parse(tokens[3]);
                        string substring = key.ToString(startIndex, endIndex - startIndex);

                        key.Remove(startIndex, endIndex - startIndex);
                        key.Insert(startIndex, tokens[1] == "Upper" ? substring.ToUpper() : substring.ToLower());

                        Console.WriteLine(key);
                        break;
                    case "Slice":
                        key.Remove(int.Parse(tokens[1]), int.Parse(tokens[2]) - int.Parse(tokens[1]));
                        Console.WriteLine(key);
                        break;
                }
                
                input = Console.ReadLine();
            }

            Console.WriteLine("Your activation key is: " + key);
        }
    }
}

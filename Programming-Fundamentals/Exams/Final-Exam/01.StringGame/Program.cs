using System;

namespace _01.StringGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();

            string command = Console.ReadLine();
            while (command != "Done")
            {
                string[] tokens = command.Split();
                switch (tokens[0])
                {
                    case "Change":
                        str = str.Replace(char.Parse(tokens[1]), char.Parse(tokens[2]));
                        Console.WriteLine(str);
                        break;
                    case "Includes":
                        Console.WriteLine(str.Contains(tokens[1]));
                        break;
                    case "End":
                        Console.WriteLine(str.EndsWith(tokens[1]));
                        break;
                    case "Uppercase":
                        str = str.ToUpper();
                        Console.WriteLine(str);
                        break;
                    case "FindIndex":
                        Console.WriteLine(str.IndexOf(char.Parse(tokens[1])));
                        break;
                    case "Cut":
                        str = str.Substring(int.Parse(tokens[1]), int.Parse(tokens[2]));
                        Console.WriteLine(str);
                        break;
                }

                command = Console.ReadLine();
            }
        }
    }
}

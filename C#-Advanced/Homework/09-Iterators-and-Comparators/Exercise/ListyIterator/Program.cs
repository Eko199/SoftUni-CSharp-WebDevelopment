using System;
using System.Linq;

namespace ListyIterator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var iterator = new ListyIterator<string>(Console.ReadLine().Split().Skip(1));

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                switch (command)
                {
                    case "Move":
                        Console.WriteLine(iterator.Move());
                        break;
                    case "Print":
                        try
                        {
                            iterator.Print();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;
                    case "PrintAll":
                        foreach (string str in iterator)
                            Console.Write(str + " ");

                        Console.WriteLine();
                        break;
                    case "HasNext":
                        Console.WriteLine(iterator.HasNext());
                        break;
                }
            }
        }
    }
}

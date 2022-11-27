using System;

namespace _05.PlayCatch
{
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int exceptionsCount = 0;
            while (exceptionsCount < 3)
            {
                string[] tokens = Console.ReadLine().Split();

                try
                {
                    switch (tokens[0])
                    {
                        case "Replace":
                            arr[int.Parse(tokens[1])] = int.Parse(tokens[2]);
                            break;
                        case "Print":
                            Console.WriteLine(string.Join(", ", arr[int.Parse(tokens[1])..(int.Parse(tokens[2]) + 1)]));
                            break;
                        case "Show":
                            Console.WriteLine(arr[int.Parse(tokens[1])]);
                            break;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("The index does not exist!");
                    exceptionsCount++;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("The index does not exist!");
                    exceptionsCount++;
                }
                catch (FormatException)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    exceptionsCount++;
                }
            }

            Console.WriteLine(string.Join(", ", arr));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08.AnonymousThreat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine().Split().ToList();
            string[] commands = Console.ReadLine().Split().ToArray();

            while (!commands[0].Equals("3:1"))
            {
                int command1 = int.Parse(commands[1]);
                int command2 = int.Parse(commands[2]);

                switch (commands[0])
                {
                    case "merge":
                        MergeList(list, ValidIndex(command1, list), ValidIndex(command2, list));
                        break;
                    case "divide":
                        DivideList(list, ValidIndex(command1, list), command2);
                        break;
                }

                commands = Console.ReadLine().Split().ToArray();
            }

            Console.WriteLine(string.Join(" ", list));
        }

        private static int ValidIndex(int index, ICollection<string> list) => Math.Max(0, Math.Min(index, list.Count - 1));

        private static void MergeList(IList<string> list, int startIndex, int endIndex)
        {
            string[] mergedStrings = new string[endIndex - startIndex + 1];

            for (int i = endIndex; i >= startIndex; i--)
            {
                mergedStrings[^(endIndex - i + 1)] = list[i];
                list.RemoveAt(i);
            }
            
            list.Insert(startIndex, string.Join("", mergedStrings));
        }

        private static void DivideList(IList<string> list, int index, int partitions)
        {
            string dividedElement = list[index];
            int partitionLength = dividedElement.Length / partitions;
            list[index] = dividedElement.Substring((partitions - 1) * partitionLength, partitionLength + dividedElement.Length % partitions);

            for (int i = partitions - 2; i >= 0; i--)
            {
                list.Insert(index, dividedElement.Substring(i * partitionLength, partitionLength));
            }
        }
    }
}

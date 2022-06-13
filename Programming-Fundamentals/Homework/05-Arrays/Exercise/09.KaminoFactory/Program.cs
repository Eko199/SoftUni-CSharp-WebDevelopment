using System;
using System.Linq;

namespace _09.KaminoFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            int bestCount = -1, bestStartingIndex = -1, bestIndex = 1, currIndex = 0;
            int[] bestDNA = new int[length];

            while (!input.Equals("Clone them!"))
            {
                int[] currDNA = input.Split('!', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                currIndex++;

                int currCount = 1, currStartingIndex = 0;

                for (int i = 1; i < length; i++)
                {
                    if (currDNA[i] != 1) continue;

                    if (currDNA[i - 1] == 1)
                    {
                        currCount++;
                    }
                    else
                    {
                        currCount = 1;
                        currStartingIndex = i;
                    }

                    if (currCount < bestCount
                        || (currCount == bestCount
                            && (bestStartingIndex < currStartingIndex
                                || (bestStartingIndex == currStartingIndex && bestDNA.Sum() >= currDNA.Sum()))))
                        continue;

                    bestCount = currCount;
                    bestStartingIndex = currStartingIndex;
                    bestIndex = currIndex;
                    bestDNA = currDNA;
                }

                if (!(currCount < bestCount
                    || (currCount == bestCount
                        && (bestStartingIndex < currStartingIndex
                            || (bestStartingIndex == currStartingIndex && bestDNA.Sum() >= currDNA.Sum())))))
                {
                    bestCount = currCount;
                    bestStartingIndex = currStartingIndex;
                    bestIndex = currIndex;
                    bestDNA = currDNA;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {bestIndex} with sum: {bestDNA.Sum()}.");
            Console.WriteLine(string.Join(" ", bestDNA));
        }
    }
}

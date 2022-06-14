using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.LongestIncreasingSubsequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int bestLength = -1, skippedIndex = -1;
            int[] longestSequence = Array.Empty<int>();
            List<int> currSequence = new List<int> { numbers[0] };
            for (int i = 1; i < numbers.Length; i++)
            {
                if (currSequence[^1] < numbers[i])
                {
                    currSequence.Add(numbers[i]);

                    if (currSequence.Count > bestLength)
                    {
                        bestLength = currSequence.Count;
                        longestSequence = currSequence.ToArray();
                    }
                }
                else if (currSequence.Count < 2 || numbers[i] > currSequence[^2])
                {
                    currSequence[^1] = numbers[i];
                }
                else if (skippedIndex == -1)
                {
                    skippedIndex = i;
                }

                if (i != numbers.Length - 1 || skippedIndex == -1) continue;

                i = skippedIndex;
                skippedIndex = -1;
                currSequence = new List<int> { numbers[i] };

                for (int j = i - 1; j >= 0; j--)
                {
                    if (numbers[j] < currSequence[^1])
                    {
                        currSequence.Add(numbers[j]);
                    }
                    else if (currSequence.Count >= 2 && currSequence[^2] > numbers[j])
                    {
                        currSequence[^1] = numbers[j];
                    }
                }

                currSequence.Reverse();
            }

            if (currSequence.Count > bestLength)
            {
                longestSequence = currSequence.ToArray();
            }

            Console.WriteLine(string.Join(" ", longestSequence));
        }
    }
}

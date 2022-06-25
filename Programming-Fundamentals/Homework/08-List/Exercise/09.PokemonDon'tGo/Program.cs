using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonDon_tGo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> distances = Console.ReadLine().Split().Select(int.Parse).ToList();
            int sum = 0;

            while (distances.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());
                int element;

                if (index < 0)
                {
                    element = distances[0];
                    distances[0] = distances[^1];
                }
                else if (index >= distances.Count)
                {
                    element = distances[^1];
                    distances[^1] = distances[0];
                }
                else
                {
                    element = distances[index];
                    distances.RemoveAt(index);
                }

                sum += element;

                for (int i = 0; i < distances.Count; i++)
                    distances[i] += (distances[i] <= element ? 1 : -1) * element;
            }

            Console.WriteLine(sum);
        }
    }
}

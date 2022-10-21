using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericBox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Box<double>> boxes = new List<Box<double>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                boxes.Add(new Box<double>(double.Parse(Console.ReadLine())));
            }

            Console.WriteLine(CountCompared(boxes, double.Parse(Console.ReadLine())));
        }

        public static void Swap<T>(List<T> list, int i, int j)
        {
            T temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }

        public static int CountCompared<T>(List<Box<T>> list, T compared) where T : IComparable<T>
            => list.Count(x => x.Value.CompareTo(compared) > 0);
    }
}

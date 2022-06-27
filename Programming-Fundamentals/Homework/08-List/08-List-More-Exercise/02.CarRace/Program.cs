using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.CarRace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> times = Console.ReadLine().Split().Select(int.Parse).ToList();
            decimal leftTime = 0, rightTime = 0;

            for (int i = 0; i < times.Count / 2; i++)
            {
                if (times[i] == 0)
                    leftTime -= leftTime / 5;
                else
                    leftTime += times[i];

                if (times[^(i + 1)] == 0)
                    rightTime -= rightTime / 5;
                else
                    rightTime += times[^(i + 1)];
            }

            Console.WriteLine("The winner is {0} with total time: {1}", leftTime > rightTime ? "right" : "left", Math.Min(leftTime, rightTime));
        }
    }
}

using System;
using System.Linq;

namespace _02.TheLift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int WagonCapacity = 4;
            int passengers = int.Parse(Console.ReadLine());
            int[] lift = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (var i = 0; i < lift.Length && passengers > 0; i++)
            {
                while (lift[i] < WagonCapacity && passengers > 0)
                {
                    lift[i]++;
                    passengers--;
                }
            }

            if (passengers > 0)
                Console.WriteLine($"There isn't enough space! {passengers} people in a queue!");
            else if (lift.Sum() < WagonCapacity * lift.Length)
                Console.WriteLine("The lift has empty spots!");

            Console.WriteLine(string.Join(' ', lift));
        }
    }
}

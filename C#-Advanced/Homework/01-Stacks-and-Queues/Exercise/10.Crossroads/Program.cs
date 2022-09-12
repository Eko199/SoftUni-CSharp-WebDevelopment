using System;
using System.Collections.Generic;

namespace _10.Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenTime = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            var queue = new Queue<string>();
            bool crash = false;
            string passingCar = string.Empty;
            int greenLeft = greenTime, countPassed = 0;

            string input = Console.ReadLine();
            while (input != "END")
            {
                if (input != "green")
                {
                    queue.Enqueue(input);
                }
                else
                {
                    greenLeft = greenTime;
                    while (greenLeft > 0 && queue.Count > 0)
                    {
                        passingCar = queue.Dequeue();
                        greenLeft -= passingCar.Length;
                        countPassed++;
                    }

                    if (greenLeft < 0 && Math.Abs(greenLeft) > freeWindow)
                    {
                        crash = true;
                        break;
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(crash ? "A crash happened!" : "Everyone is safe.");
            Console.WriteLine(crash ? $"{passingCar} was hit at {passingCar[greenLeft + passingCar.Length + freeWindow]}." 
                : countPassed + " total cars passed the crossroads.");
        }
    }
}

using System;

namespace _01.DayOfWeek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] weekDays =
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };

            int input = int.Parse(Console.ReadLine());
            if (input >= 1 && input <= weekDays.Length)
                Console.WriteLine(weekDays[input - 1]);
            else
                Console.WriteLine("Invalid day!");
        }
    }
}

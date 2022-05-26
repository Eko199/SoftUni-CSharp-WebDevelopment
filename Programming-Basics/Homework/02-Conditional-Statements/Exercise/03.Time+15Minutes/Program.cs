using System;

namespace Time_15Minutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            int timeMins = hours * 60 + minutes + 15;
            hours = (timeMins / 60) % 24;
            minutes = timeMins % 60;

            if (minutes >= 10)
                Console.WriteLine($"{hours}:{minutes}");
            else
                Console.WriteLine($"{hours}:0{minutes}");
        }
    }
}

using System;

namespace LunchBreak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string series = Console.ReadLine();
            int episodeDuration = int.Parse(Console.ReadLine());
            int breakDuration = int.Parse(Console.ReadLine());

            double time = breakDuration * 0.625;
            if (time >= episodeDuration)
                Console.WriteLine($"You have enough time to watch {series} and left with " +
                    $"{Math.Ceiling(time - episodeDuration)} minutes free time.");
            else
                Console.WriteLine($"You don't have enough time to watch {series}, " +
                    $"you need {Math.Ceiling(episodeDuration - time)} more minutes.");
        }
    }
}

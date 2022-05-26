using System;

namespace OnTimeForExam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMinute = int.Parse(Console.ReadLine());
            int arriveHour = int.Parse(Console.ReadLine());
            int arriveMinute = int.Parse(Console.ReadLine());

            int examTime = examHour * 60 + examMinute;
            int arriveTime = arriveHour * 60 + arriveMinute;
            int difference = examTime - arriveTime;

            if (difference < 0)
            {
                Console.WriteLine("Late");
                if (Math.Abs(difference) >= 60)
                {
                    if (Math.Abs(difference) % 60 >= 10)
                    {
                        Console.WriteLine($"{Math.Abs(difference) / 60}:" +
                            $"{Math.Abs(difference) % 60} hours after the start");
                    }
                    else
                    {
                        Console.WriteLine($"{Math.Abs(difference) / 60}:" +
                            $"0{Math.Abs(difference) % 60} hours after the start");
                    }
                }
                else
                {
                    Console.WriteLine($"{Math.Abs(difference)} minutes after the start");
                }
            }
            else if (difference <= 30)
            {
                Console.WriteLine("On time");
                if (difference != 0)
                    Console.WriteLine($"{Math.Abs(difference)} minutes before the start");
            }
            else
            {
                Console.WriteLine("Early");
                if (difference >= 60)
                {
                    if (Math.Abs(difference) % 60 >= 10)
                    {
                        Console.WriteLine($"{Math.Abs(difference) / 60}:" +
                            $"{Math.Abs(difference) % 60} hours before the start");
                    }
                    else
                    {
                        Console.WriteLine($"{Math.Abs(difference) / 60}:" +
                            $"0{Math.Abs(difference) % 60} hours before the start");
                    }
                }
                else
                {
                    Console.WriteLine($"{Math.Abs(difference)} minutes before the start");
                }
            }
        }
    }
}

using System;

namespace TennisRanklist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int tournaments = int.Parse(Console.ReadLine());
            int points = int.Parse(Console.ReadLine());
            int wins = 0, wonPoints = 0;

            for (int i = 0; i < tournaments; i++)
            {
                string finishStage =  Console.ReadLine();
                switch (finishStage)
                {
                    case "W":
                        wonPoints += 2000;
                        wins++;
                        break;
                    case "F":
                        wonPoints += 1200;
                        break;
                    case "SF":
                        wonPoints += 720;
                        break;
                }
            }

            points += wonPoints;
            Console.WriteLine($"Final points: {points}");
            Console.WriteLine($"Average points: {Math.Floor(1.0 * wonPoints / tournaments)}");
            Console.WriteLine($"{wins * 100.0 / tournaments:f2}%");
        }
    }
}

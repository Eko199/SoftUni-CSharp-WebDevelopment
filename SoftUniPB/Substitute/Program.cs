using System;

namespace Substitute
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int k = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            int player = 0, substitute = 0;
            int counter = 0;
            bool done = false;
            for (int i = k; i <= 8; i++)
            {
                if (done)
                    break;
                if (i % 2 == 0)
                {
                    for (int j = 9; j >= l; j--)
                    {
                        if (done)
                            break;
                        if (j % 2 == 1)
                        {
                            player = i * 10 + j; 
                            for (int x = m; x <= 8; x++)
                            {
                                if (done)
                                    break;
                                if (x % 2 == 0)
                                {
                                    for (int y = 9; y >= n; y--)
                                    {
                                        if (done)
                                            break;
                                        if (y % 2 == 1)
                                        {
                                            substitute = x * 10 + y;
                                            if (player == substitute)
                                                Console.WriteLine("Cannot change the same player.");
                                            else
                                            {
                                                Console.WriteLine($"{i}{j} - {x}{y}");
                                                counter++;
                                            }
                                            if (counter >= 6)
                                            {
                                                done = true;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

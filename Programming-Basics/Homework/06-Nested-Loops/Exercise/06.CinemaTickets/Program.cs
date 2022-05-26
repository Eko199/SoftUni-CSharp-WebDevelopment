using System;

namespace CinemaTickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int studentTickets = 0, standartTickets = 0, kidTickets = 0;

            while (name != "Finish")
            {
                int seats = int.Parse(Console.ReadLine());
                int freeSeats = seats;

                while (freeSeats > 0)
                {
                    string ticket = Console.ReadLine();

                    if (ticket == "End")
                        break;
                    else if (ticket == "student")
                        studentTickets++;
                    else if (ticket == "standard")
                        standartTickets++;
                    else if (ticket == "kid")
                        kidTickets++;

                    freeSeats--;
                }

                double percentFull = 100.0 * (seats - freeSeats) / seats;
                Console.WriteLine($"{name} - {percentFull:f2}% full.");
                name = Console.ReadLine();
            }

            int tickets = studentTickets + standartTickets + kidTickets;
            double percentStudent = 100.0 * studentTickets / tickets;
            double percentStandart = 100.0 * standartTickets / tickets;
            double percentKid = 100.0 * kidTickets / tickets;

            Console.WriteLine($"Total tickets: {tickets}");
            Console.WriteLine($"{percentStudent:f2}% student tickets.");
            Console.WriteLine($"{percentStandart:f2}% standard tickets.");
            Console.WriteLine($"{percentKid:f2}% kids tickets.");
        }
    }
}

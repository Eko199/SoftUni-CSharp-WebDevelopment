using System;

namespace Building
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int floors = int.Parse(Console.ReadLine());
            int rooms = int.Parse(Console.ReadLine());

            for (int i = 0; i < floors; i++)
            {
                char room;
                if (i == 0)
                    room = 'L';
                else if ((floors - i) % 2 == 0)
                    room = 'O';
                else
                    room = 'A';

                for (int j = 0; j < rooms; j++)
                {
                    Console.Write($"{room}{floors-i}{j} ");
                }
                Console.WriteLine();
            }
        }
    }
}

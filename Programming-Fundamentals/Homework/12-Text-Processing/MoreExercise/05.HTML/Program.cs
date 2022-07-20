using System;

namespace _05.HTML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("<h1>");
            Console.WriteLine("\t" + Console.ReadLine());
            Console.WriteLine("</h1>");

            Console.WriteLine("<article>");
            Console.WriteLine("\t" + Console.ReadLine());
            Console.WriteLine("</article>");

            string input = Console.ReadLine();
            while (input != "end of comments")
            {
                Console.WriteLine("<div>");
                Console.WriteLine("\t" + input);
                Console.WriteLine("</div>");

                input = Console.ReadLine();
            }
        }
    }
}

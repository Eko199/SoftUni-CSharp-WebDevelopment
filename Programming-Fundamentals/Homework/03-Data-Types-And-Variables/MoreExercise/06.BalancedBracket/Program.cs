using System;

namespace _06.BalancedBracket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            bool isValid = true;
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                if (input.Length == 1)
                {
                    if (input.Equals("(")) 
                    {
                        if (!isValid) break;
                        isValid = false;
                    }
                    else if (input.Equals(")"))
                    {
                        if (isValid) { isValid = false; break; }
                        isValid = true;
                    }
                }
            }

            Console.WriteLine((isValid) ? "BALANCED" : "UNBALANCED");
        }
    }
}

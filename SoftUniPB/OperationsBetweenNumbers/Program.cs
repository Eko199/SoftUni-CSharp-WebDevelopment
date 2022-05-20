using System;

namespace OperationsBetweenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            char operation = char.Parse(Console.ReadLine());

            if ((operation == '/' || operation == '%') && n2 == 0)
            {
                Console.WriteLine($"Cannot divide {n1} by zero");
            }
            else 
            {
                double result = 0;
                switch (operation)
                {
                    case '+':
                        result = n1 + n2;
                        goto case '1';
                    case '-':
                        result = n1 - n2;
                        goto case '1';
                    case '*':
                        result = n1 * n2;
                        goto case '1';
                    case '1':
                        if (result % 2 == 0)
                            Console.WriteLine($"{n1} {operation} {n2} = {result} - even");
                        else
                            Console.WriteLine($"{n1} {operation} {n2} = {result} - odd");
                        break;
                    case '/':
                        Console.WriteLine($"{n1} {operation} {n2} = {(double)n1 / n2:f2}");
                        break;
                    case '%':
                        Console.WriteLine($"{n1} {operation} {n2} = {n1 % n2}");
                        break;
                }
            }
        }
    }
}

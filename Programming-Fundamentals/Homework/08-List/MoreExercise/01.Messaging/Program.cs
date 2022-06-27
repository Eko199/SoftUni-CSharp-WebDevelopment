using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.Messaging
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string message = Console.ReadLine();

            StringBuilder result = new StringBuilder();
            foreach (int number in numbers)
            {
                int current = number, digitSum = 0;
                while (current > 0)
                {
                    digitSum += current % 10;
                    current /= 10;
                }

                digitSum %= message.Length;
                result.Append(message[digitSum]);
                message = message.Remove(digitSum, 1);
            }

            Console.WriteLine(result);
        }
    }
}

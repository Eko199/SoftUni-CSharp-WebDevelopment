using System;

namespace EvenAndOddSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            for (int i = start; i <= end; i++)
            {
                string num = i.ToString();
                int evenSum = 0, oddSum = 0;
                for (int j = 0; j < num.Length; j++)
                {
                    if ((j+1) % 2 == 0)
                    {
                        evenSum += num[j] - '0';
                    }
                    else
                    {
                        oddSum += num[j] - '0';
                    }
                }

                if (evenSum == oddSum)
                {
                    Console.Write(num + " ");
                }
            }
        }
    }
}

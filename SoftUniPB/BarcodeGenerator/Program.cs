using System;

namespace BarcodeGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            for (int i = start / 1000; i <= end / 1000; i++)
            {
                if (i % 2 == 1)
                {
                    for (int j = (start/100)%10; j <= (end/100)%10; j++)
                    {
                        if (j % 2 == 1)
                        {
                            for (int k = (start / 10) % 10; k <= (end / 10) % 10; k++)
                            {
                                if (k % 2 == 1)
                                {
                                    for (int l = start % 10; l <= end % 10; l++)
                                    {
                                        if (l % 2 == 1)
                                        {
                                            int barcode = i * 1000 + j * 100 + k * 10 + l;
                                            Console.Write(barcode + " ");
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

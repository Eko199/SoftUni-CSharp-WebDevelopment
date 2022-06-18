using System;

namespace _04.TribonacciSequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int num1 = 1, num2 = 1, num3 = 2;

            for (int i = 1; i <= num; i++)
            {
                int curr;
                switch (i)
                {
                    case 1:
                        curr = num1;
                        break;
                    case 2:
                        curr = num2;
                        break;
                    case 3:
                        curr = num3;
                        break;
                    default:
                        curr = GetTribonacci(num1, num2, num3);
                        num1 = num2;
                        num2 = num3;
                        num3 = curr;
                        break;
                }

                Console.Write(curr + " ");
            }
        }

        private static int GetTribonacci(int num1, int num2, int num3) => num1 + num2 + num3;
    }
}

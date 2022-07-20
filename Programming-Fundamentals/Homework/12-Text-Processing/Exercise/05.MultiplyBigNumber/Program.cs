using System;
using System.Text;

namespace _05.MultiplyBigNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string bigInt = Console.ReadLine();
            byte digit = byte.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();
            int bonus = 0;

            for (int i = bigInt.Length - 1; i >= 0; i--)
            {
                int product = int.Parse(bigInt[i].ToString()) * digit + bonus;
                sb.Insert(0, product % 10);
                bonus = product / 10;
            }

            if (bonus != 0) sb.Insert(0, bonus);

            while (sb.Length > 1 && sb[0] == '0')
                sb.Remove(0, 1);

            Console.WriteLine(sb);
        }
    }
}

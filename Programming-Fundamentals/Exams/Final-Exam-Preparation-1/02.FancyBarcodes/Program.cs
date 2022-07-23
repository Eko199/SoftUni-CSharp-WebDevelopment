using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.FancyBarcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var regex = new Regex(@"^@#+[A-Z][A-Za-z\d]{4,}[A-Z]@#+$");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                if (!regex.IsMatch(input))
                {
                    Console.WriteLine("Invalid barcode");
                    continue;
                }

                string productGroup = input.Any(char.IsDigit) ? new string(input.Where(char.IsDigit).ToArray()) : "00";
                Console.WriteLine("Product group: " + productGroup);
            }
        }
    }
}

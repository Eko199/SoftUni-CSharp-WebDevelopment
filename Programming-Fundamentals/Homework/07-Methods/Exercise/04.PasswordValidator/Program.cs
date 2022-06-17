using System;
using System.Linq;

namespace _04.PasswordValidator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            bool isValid = true;

            if (!CheckPassLength(password))
            {
                isValid = false;
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            if (!CheckPassContent(password))
            {
                isValid = false;
                Console.WriteLine("Password must consist only of letters and digits");
            }

            if (!CheckMinimumDigits(password))
            {
                isValid = false;
                Console.WriteLine("Password must have at least 2 digits");
            }

            if (isValid) Console.WriteLine("Password is valid");

        }

        private static bool CheckPassLength(string password)
        {
            return password.Length >= 6 && password.Length <= 10;
        }

        private static bool CheckPassContent(string password)
        {
            return password.All(char.IsLetterOrDigit);
        }

        private static bool CheckMinimumDigits(string password)
        {
            return password.Count(char.IsDigit) >= 2;
        }
    }
}

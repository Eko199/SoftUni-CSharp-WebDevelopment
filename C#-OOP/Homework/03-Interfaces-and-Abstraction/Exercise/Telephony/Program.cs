namespace Telephony
{
    using System;

    using Models;
    using Models.Interfaces;

    public class Program
    {
        static void Main(string[] args)
        {
            IPhone stationaryPhone = new StationaryPhone();
            ISmartphone smartphone = new Smartphone();

            string[] phoneNumbers = Console.ReadLine().Split();
            string[] urls = Console.ReadLine().Split();

            foreach (string phoneNumber in phoneNumbers)
            {
                try
                {
                    if (phoneNumber.Length == 10)
                        Console.WriteLine(smartphone.Call(phoneNumber));
                    else if (phoneNumber.Length == 7)
                        Console.WriteLine(stationaryPhone.Call(phoneNumber));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            foreach (string url in urls)
            {
                try
                {
                    Console.WriteLine(smartphone.Browse(url));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}

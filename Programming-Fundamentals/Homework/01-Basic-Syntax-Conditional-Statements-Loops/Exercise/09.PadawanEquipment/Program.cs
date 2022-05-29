using System;

namespace _09.PadawanEquipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double lightsaberPrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            double lightsaberCost = lightsaberPrice * Math.Ceiling(students * 1.1);
            double robeCost = robePrice * students;
            double beltCost = beltPrice * (students - students / 6);
            double price = lightsaberCost + robeCost + beltCost;

            if (price <= money)
                Console.WriteLine($"The money is enough - it would cost {price:f2}lv.");
            else
                Console.WriteLine($" John will need {(price - money):f2}lv more.");
        }
    }
}

using System;

namespace PetsFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double food = double.Parse(Console.ReadLine());
            int dogFoodSum = 0, catFoodSum = 0;
            double biscuitsEaten = 0;

            for (int i = 0; i < days; i++)
            {
                int dogFood = int.Parse(Console.ReadLine());
                int catFood = int.Parse(Console.ReadLine());

                dogFoodSum += dogFood;
                catFoodSum += catFood;

                if ((i+1) % 3 == 0)
                    biscuitsEaten += 0.1 * (dogFood + catFood);
            }

            int eatenFood = dogFoodSum + catFoodSum;
            Console.WriteLine($"Total eaten biscuits: {Math.Round(biscuitsEaten)}gr.");
            Console.WriteLine($"{100.0*eatenFood/food:f2}% of the food has been eaten.");
            Console.WriteLine($"{100.0*dogFoodSum/eatenFood:f2}% eaten from the dog.");
            Console.WriteLine($"{100.0*catFoodSum/eatenFood:f2}% eaten from the cat.");
        }
    }
}

namespace WildFarm
{
    using System;
    using System.Collections.Generic;

    using Factories;
    using Models.Animals;
    using Models.Food;

    public class Program
    {
        private static readonly AnimalFactory animalFactory = new AnimalFactory();

        static void Main(string[] args)
        {
            var animals = new List<Animal>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                Animal animal = BuildAnimalUsingFactory(command.Split());
                Food food = GetFood(Console.ReadLine().Split());

                Console.WriteLine(animal.AskForFood());

                try
                {
                    animal.Eat(food);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }

                animals.Add(animal);
            }

            animals.ForEach(Console.WriteLine);
        }

        private static Animal BuildAnimalUsingFactory(string[] animalInfo) 
            => animalInfo[0] switch
            {
                "Cat" or "Tiger" => animalFactory.CreateMammal(animalInfo[0], animalInfo[1],
                    double.Parse(animalInfo[2]),
                    animalInfo[3], animalInfo[4]),
                "Dog" or "Mouse" => animalFactory.CreateMammal(animalInfo[0], animalInfo[1],
                    double.Parse(animalInfo[2]), animalInfo[3]),
                "Owl" or "Hen" => animalFactory.CreateBird(animalInfo[0], animalInfo[1], double.Parse(animalInfo[2]),
                    double.Parse(animalInfo[3]))
            };

        private static Food GetFood(string[] foodInfo)
        {
            int foodQuantity = int.Parse(foodInfo[1]);

            return foodInfo[0] switch
            {
                "Vegetable" => new Vegetable(foodQuantity),
                "Fruit" => new Fruit(foodQuantity),
                "Meat" => new Meat(foodQuantity),
                "Seeds" => new Seeds(foodQuantity)
            };
        }
    }
}

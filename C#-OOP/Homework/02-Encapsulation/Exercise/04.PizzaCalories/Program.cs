using System;

namespace _04.PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string name = Console.ReadLine().Split()[1];
                string[] doughArgs = Console.ReadLine().Split();
                var pizza = new Pizza(name, new Dough(doughArgs[1], doughArgs[2], double.Parse(doughArgs[3])));

                string command;
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] cmdArgs = command.Split();
                    pizza.AddTopping(new Topping(cmdArgs[1], double.Parse(cmdArgs[2])));
                }

                Console.WriteLine(pizza);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}

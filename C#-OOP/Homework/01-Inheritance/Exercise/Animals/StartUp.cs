using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var animals = new List<Animal>();

            string command;
            while ((command = Console.ReadLine()) != "Beast!")
            {
                string[] animalInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    bool needsGender = command != "Tomcat" && command != "Kitten";

                    if (animalInfo.Length != 3 && (needsGender || animalInfo.Length != 2))
                        throw new ArgumentException("Invalid input!");

                    string name = animalInfo[0];
                    int age = int.Parse(animalInfo[1]);
                    string gender = needsGender ? animalInfo[2] : null;

                    if (needsGender && gender != "Male" && gender != "Female")
                        throw new ArgumentException("Invalid input!");

                    animals.Add(command switch
                        {
                            "Dog" => new Dog(name, age, gender),
                            "Cat" => new Cat(name, age, gender),
                            "Frog" => new Frog(name, age, gender),
                            "Tomcat" => new Tomcat(name, age),
                            "Kitten" => new Kitten(name, age),
                            _ => throw new ArgumentException("Invalid input!")
                        });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            animals.ForEach(Console.WriteLine);
        }
    }
}

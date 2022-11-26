namespace WildFarm.Factories
{
    using Models.Animals;

    public class AnimalFactory
    {
        public Mammal CreateMammal(string type, string name, double weight, string livingRegion, string breed = null)
            => type switch
            {
                "Cat" => new Cat(name, weight, livingRegion, breed),
                "Tiger" => new Tiger(name, weight, livingRegion, breed),
                "Mouse" => new Mouse(name, weight, livingRegion),
                "Dog" => new Dog(name, weight, livingRegion)
            };

        public Bird CreateBird(string type, string name, double weight, double wingSize)
            => type switch
            {
                "Owl" => new Owl(name, weight, wingSize),
                "Hen" => new Hen(name, weight, wingSize)
            };
    }
}

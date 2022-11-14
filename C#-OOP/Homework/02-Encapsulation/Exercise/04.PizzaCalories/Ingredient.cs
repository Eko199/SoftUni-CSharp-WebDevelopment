namespace _04.PizzaCalories
{
    public class Ingredient
    {
        private const double CaloriesPerGram = 2;

        protected virtual double Weight { get; init; }

        public virtual double Calories() => Weight * CaloriesPerGram;
    }
}

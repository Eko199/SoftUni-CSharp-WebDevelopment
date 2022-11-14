namespace _04.PizzaCalories
{
    public static class ExceptionMessages
    {
        public const string InvalidDoughTypeMessage = "Invalid type of dough.";
        public const string InvalidDoughWeightMessage = "Dough weight should be in the range [1..200].";

        public const string InvalidToppingTypeMessage = "Cannot place {0} on top of your pizza.";
        public const string InvalidToppingWeightMessage = "{0} weight should be in the range [1..50].";

        public const string InvalidPizzaNameMessage = "Pizza name should be between 1 and 15 symbols.";
        public const string InvalidPizzaToppingsCountMessage = "Number of toppings should be in range [0..10].";
    }
}

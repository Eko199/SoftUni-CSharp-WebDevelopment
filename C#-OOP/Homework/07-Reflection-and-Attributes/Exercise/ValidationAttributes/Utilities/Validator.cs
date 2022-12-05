namespace ValidationAttributes.Utilities
{
    using System.Linq;

    using Attributes;

    public static class Validator
    {
        public static bool IsValid(object obj)
            => obj.GetType()
                .GetProperties()
                .All(p => p
                    .GetCustomAttributes(false)
                    .OfType<MyValidationAttribute>()
                    .All(validationAttr => validationAttr
                        .IsValid(p.GetValue(obj))));
    }
}